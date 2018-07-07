using System.Linq;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ClinicHistoryApi.Services
{
	public class RemoveAuthFiltersProvider : IFilterProvider
	{
		public int Order => -1500;

		public void OnProvidersExecuted(FilterProviderContext context)
		{
		}

		public void OnProvidersExecuting(FilterProviderContext context)
		{
			// remove authorize filters
			var authFilters = context.Results.Where(x =>
				x.Descriptor.Filter.GetType() == typeof(AuthorizeFilter)).ToList();
			foreach (var f in authFilters)
			{
				context.Results.Remove(f);
			}
		}
	}
}