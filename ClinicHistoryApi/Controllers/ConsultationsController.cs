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
	[Authorize(AuthenticationSchemes = "Bearer", Policy = "patients")]
	[Produces("application/json")]	
	public class ConsultationsController : Controller
    {
		private readonly IGenericService _genericService;
		private readonly IMapper _mapper;
		
		public ConsultationsController(IGenericService genericService, IMapper mapper)
        {
			_genericService = genericService;
			_mapper = mapper;
		}

		[HttpGet("api/consultations/{patientId}")]
		public async Task<ConsultationModel[]> Get(int patientId)
		{			
			var consultations = await  _genericService.Find<Consultation>(
				x => x.PatientId == patientId,
				y => y.OrderByDescending(z => z.Date));

			var result = _mapper.Map<ConsultationModel[]>(consultations);
			return result.ToArray();
		}
	}
}