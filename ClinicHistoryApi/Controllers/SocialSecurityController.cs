using System.Linq;
using System.Threading.Tasks;
using ClinicHistoryApi.Entities;
using ClinicHistoryApi.Models.Entities;
using ClinicHistoryApi.Services.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicHistoryApi.Controllers
{
	[Authorize(AuthenticationSchemes = "Bearer", Policy = "patients")]
	[Produces("application/json")]	
	public class SocialSecurityController : Controller
    {
		private readonly IGenericService _genericService;
		
		public SocialSecurityController(IGenericService genericService)
        {
			_genericService = genericService;		}
		
		[HttpGet("api/social-securities/")]		
		public async Task<SocialSecurity[]> Get(string filter)
		{						
			var result = _genericService.Find<SocialSecurity>(
				x => string.IsNullOrEmpty(filter) || x.Name.Contains(filter),					
				y => y.OrderBy(z => z.Name));
			return await result;
		}

	    [HttpPost("api/social-securities")]
	    public async Task<IActionResult> Post([FromBody]NamedModel model)
	    {
		    var socialSecurity = new SocialSecurity {Name = model.Name};
		    var id = await _genericService.Create(socialSecurity);
		    return Ok(id);
	    }
	}
}