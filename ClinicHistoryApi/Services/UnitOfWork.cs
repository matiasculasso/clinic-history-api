using System;
using System.Threading.Tasks;
using ClinicHistoryApi.Data;
using ClinicHistoryApi.Services.Intefaces;

namespace ClinicHistoryApi.Services
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly EntitiesDbContext _ctx;

		public UnitOfWork(EntitiesDbContext ctx)
		{
			this._ctx = ctx;
		}

		public EntitiesDbContext Context => _ctx;

		public int Commit()
		{
			return _ctx.SaveChanges();
		}

		public Task<int> CommitAsync()
		{
			return _ctx.SaveChangesAsync();
		}

		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					_ctx.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
