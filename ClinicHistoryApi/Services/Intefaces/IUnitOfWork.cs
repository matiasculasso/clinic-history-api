using System;
using System.Threading.Tasks;
using ClinicHistoryApi.Data;

namespace ClinicHistoryApi.Services.Intefaces
{
	public interface IUnitOfWork : IDisposable
	{
		EntitiesDbContext Context { get; }
		/// <summary>
		/// Saves all pending changes
		/// </summary>
		/// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
		int Commit();
		Task<int> CommitAsync();
	}
}
