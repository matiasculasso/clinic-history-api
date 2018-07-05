using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClinicHistoryApi.Entities;
using ClinicHistoryApi.Models.Entities;
using ClinicHistoryApi.Services.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ClinicHistoryApi.Controllers
{	
	[Authorize(AuthenticationSchemes = "Bearer", Policy = "patients")]
	[Produces("application/json")]	
	public class PatientsController : Controller
    {
		private readonly IGenericService _genericService;
		private readonly IMapper _mapper;

		public PatientsController(IGenericService genericService, IMapper mapper)
        {
			_genericService = genericService;
			_mapper = mapper;
		}

		[HttpGet("api/patients/")]
		public async Task<PatientGridModel[]> Get(string filter)
		{
			if (string.IsNullOrEmpty(filter))
				return new PatientGridModel[0];

			var patients = await  _genericService.Find<Patient>(
				x => x.Name.Contains(filter) ||
					x.LastName.Contains(filter) ||
					x.IdentificationNumber.Contains(filter) ||
					x.ConsultationReason.Contains(filter) ||
					x.Diagnostic.Name.Contains(filter),
				y => y.OrderBy(z => z.LastName).ThenBy(z => z.Name),
				"Diagnostic");

			var result = _mapper.Map<PatientGridModel[]>(patients);
			return result.ToArray();
		}

		[HttpGet("api/patients/{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var patient = await _genericService.Get<Patient>(id, "Diagnostic,SocialSecurity");
			if (patient == null)
				return NotFound();

			var model = _mapper.Map<PatientEditModel>(patient);
			return Ok(model);
		}

		[HttpPost("api/patients")]
		public async Task<IActionResult> Post([FromBody]PatientEditModel model)
		{
			var patient = MapModelToEntity(model);
						
			await _genericService.Create(patient);

			MapAndCreateConsultation(patient, model.Consultation);

			return Ok(patient.Id);
		}

		[HttpPut("api/patients")]
		public async Task<IActionResult> Put([FromBody]PatientEditModel model)
		{
			var patient = MapModelToEntity(model);

			await _genericService.Update(patient);

			MapAndCreateConsultation(patient, model.Consultation);

			return Ok(patient.Id);
		}

		[HttpPut("api/patients/{id}")]
		public IActionResult Delete(int id)
		{
			var patient = _genericService.Get<Patient>(id).Result;
			if (patient == null)
				return NotFound();
			
			return Ok(_genericService.Delete(patient));
		}

		private Patient MapModelToEntity(PatientEditModel model)
		{
			var patient = _mapper.Map<Patient>(model);

			if(model.SocialSecurityId.HasValue)
			{
				patient.SocialSecurity = _genericService.Get<SocialSecurity>(model.SocialSecurityId.Value).Result;
			}

			if (model.DiagnosticId.HasValue)
			{
				patient.Diagnostic = _genericService.Get<Diagnostic>(model.DiagnosticId.Value).Result;
			}
			return patient;
		}
		 
		private void MapAndCreateConsultation (Patient patient, ConsultationModel model)
		{
			if (model == null)
				return;

			var consultation = new Consultation(patient, DateTime.Now, model.ComplementaryMethodRequested,
				model.Length, model.Weight, model.Alimentation, model.Comments, model.DefecatoryHabit,
				model.Evolution, model.SchoolPerformance, model.PhysicalExam, model.PhysicalActivity);
			
			var consultationId =  _genericService.Create(consultation).Result;

			if (model.ComplementaryMethodRequested)
			{
				var complement = new Complement(consultationId, DateTime.Now);
				_genericService.Create(complement);
			}
		}

	}
}