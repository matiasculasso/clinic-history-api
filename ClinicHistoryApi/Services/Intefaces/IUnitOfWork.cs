using ClinicHistoryApi.Data;
using System;
using System.Threading.Tasks;

namespace ClinicHistoryApi.Service.Interfaces
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
