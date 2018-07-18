using System.Linq;
using System.Threading.Tasks;
using ClinicHistoryApi.Data;
using ClinicHistoryApi.Entities;
using ClinicHistoryApi.Models.Entities;
using ClinicHistoryApi.Services.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicHistoryApi.Controllers
{
	[Authorize(AuthenticationSchemes = "Bearer", Policy = "patients")]
	[Produces("application/json")]
	public class ComplementsController : Controller
	{
		private readonly IGenericService _genericService;
		private readonly EntitiesDbContext _dbContext;

		public ComplementsController(IGenericService genericService, EntitiesDbContext dbContext)
		{
			_genericService = genericService;
			_dbContext = dbContext;

		}

		[HttpGet("api/complements/complementary-methods")]
		public async Task<NamedModel[]> GetComplementaryMethdos()
		{
			var complementaryMethods = await _genericService.GetAll<ComplementaryMethod>();
			return complementaryMethods.Select(x => new NamedModel { Id = x.Id, Name = x.Name })
				.OrderBy(x => x.Name)
				.ToArray();
		}

		[HttpGet("api/complements/laboratories")]
		public async Task<NamedModel[]> GetLabs()
		{
			var labs = await _genericService.GetAll<Laboratory>();
			return labs.Select(x => new NamedModel { Id = x.Id, Name = x.Name })
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

		[HttpPost("api/complements/{patientId}")]
		public async Task<IActionResult> Post(int patientId, [FromBody]ComplementEditModel[] model)
		{
			var complements = await _genericService.Find<Complement>(
				x => model.Any(y => y.Id == x.Id),
				includeProperties: "ComplementaryMethods,LaboratoryInstances");

			using (var dbTransacton = _dbContext.Database.BeginTransaction())
			{
				foreach (var comp in complements)
				{					
					comp.ComplementaryMethods.Clear();
					comp.LaboratoryInstances.Clear();

					// adding complementary method
					var compMethods = model.First(x => x.Id == comp.Id)
						.ComplementaryMethods
						.Select(x => new ComplementaryMethodInstance(x.ComplementaryMethodId, x.Value))
						.ToArray();
						
					comp.ComplementaryMethods.AddRange(compMethods);


					// adding labs
					var labs = model.First(x => x.Id == comp.Id)
						.Laboratories
						.Select(x => new LaboratoryInstance(x.LaboratoryId, x.Value))
						.ToArray();

					comp.LaboratoryInstances.AddRange(labs);
				}
				await _dbContext.SaveChangesAsync();
				dbTransacton.Commit();
			}
			return Ok();
		}
	}
}