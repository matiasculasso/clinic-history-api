using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ClinicHistoryApi.Entities;

namespace ClinicHistoryApi.Services.Intefaces
{
	public interface IGenericService
	{
		Task<T> Get<T>(int id, string includeProperties = "") where T : BaseEntity;

		Task<int> Create<T>(T entity) where T : BaseEntity;

		Task<int> Update<T>(T entity) where T : BaseEntity;

		int Delete<T>(int id) where T : BaseEntity;		

		int Delete<T>(T entity) where T : BaseEntity;

		Task<int> Count<T>(Expression<Func<T, bool>> filter = null) where T : BaseEntity;		

		Task<T[]> Find<T>(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "") where T : BaseEntity;

		Task<T[]> GetAll<T>() where T : BaseEntity;
	}
}