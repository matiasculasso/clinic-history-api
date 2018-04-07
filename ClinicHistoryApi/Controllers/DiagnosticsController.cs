﻿using Microsoft.AspNetCore.Mvc;
using ClinicHistoryApi.Entities;
using ClinicHistoryApi.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;


namespace ClinicHistoryApi.Auth.Controllers
{
	// [Authorize(AuthenticationSchemes = "Bearer", Policy = "patients")]
	[AllowAnonymous]
	[Produces("application/json")]	
	public class DiagnosticsController : Controller
    {
		private readonly IGenericService _genericService;
		
		public DiagnosticsController(IGenericService genericService)
        {
			_genericService = genericService;		}
		
		[HttpGet("api/diagnostics/")]		
		public async Task<Diagnostic[]> Get(string filter)
		{			
			// TODO: Add filter by name			

			var result = _genericService.Find<Diagnostic>(
				x => string.IsNullOrEmpty(filter) || x.Name.Contains(filter),					
				y => y.OrderBy(z => z.Name));

			return  await result;
		}
	}
}