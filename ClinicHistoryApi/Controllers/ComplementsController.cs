using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClinicHistoryApi.Entities;
using ClinicHistoryApi.Models.Entities;
using ClinicHistoryApi.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicHistoryApi.Controllers
{
	[AllowAnonymous]
	//[Authorize(AuthenticationSchemes = "Bearer", Policy = "patients")]
	[Produces("application/json")]
	public class ComplementsController : Controller
	{
		private readonly IGenericService _genericService;
		private readonly IMapper _mapper;

		public ComplementsController(IGenericService genericService, IMapper mapper)
		{
			_genericService = genericService;
			_mapper = mapper;
		}

		[HttpGet("api/complements/complementary-methods")]
		public async Task<NameModel[]> GetComplementaryMethdos()
		{
			var complementaryMethods = await _genericService.GetAll<ComplementaryMethod>();
			return complementaryMethods.Select(x => new NameModel { Id = x.Id, Name = x.Name })
				.OrderBy(x => x.Name)
				.ToArray();
		}

		[HttpGet("api/complements/laboratories")]
		public async Task<NameModel[]> GetLabs()
		{
			var labs = await _genericService.GetAll<Laboratory>();
			return labs.Select(x => new NameModel { Id = x.Id, Name = x.Name })
				.OrderBy(x => x.Name)
				.ToArray();
		}

		[HttpGet("api/complements/{patientId}")]
		public async Task<ComplementModel[]> Get(int patientId)
		{
			var consultations = await _genericService.Find<Consultation>(
				x => x.PatientId == patientId,
				y => y.OrderBy(z => z.Date));

			var complements = await _genericService.Find<Complement>(
					x => consultations.Any(y => y.Id == x.ConsultationId),
				includeProperties: "ComplementaryMethods,LaboratoryInstances");

			var result = complements.OrderBy(x => x.Date)
				.Select(x => new ComplementModel
				{
					Id = x.Id,
					ConsultationId = x.ConsultationId,
					Date = x.Date.ToString("dd-MM-yyyy"),
					ComplementaryMethods = x.ComplementaryMethods.Select(y => new ComplementaryMethodInstanceModel
					{
						Id = y.Id,
						ComplementaryMethodId = y.ComplementaryMethodId,
						Value = y.Value
					}).ToArray(),
					LaboratoryModels = x.LaboratoryInstances.Select(z => new LaboratoryInstanceModel()
					{
						Id = z.Id,
						LaboratoryId = z.LaboratoryId,
						Value = z.Value
					}).ToArray()
				}).OrderBy(x => x.Date).ToArray();

			return result;
		}
	}
}