using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ClinicHistoryApi.Entities;
using ClinicHistoryApi.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ClinicHistoryApi.Service
{
	public class GenericService : IGenericService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly DbContext _ctx;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public GenericService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
		{
			_unitOfWork = unitOfWork;
			_ctx = unitOfWork.Context;
			_httpContextAccessor = httpContextAccessor;
		}

		public virtual async Task<T> Get<T>(int id, string includeProperties = "") where T : BaseEntity
		{
			IQueryable<T> query = _ctx.Set<T>();

			foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}

			return await query.SingleAsync(x => x.Id == id);
		}

		public virtual async Task<int> Create<T>(T entity) where T : BaseEntity
		{
			if (entity == null)
				throw new ArgumentNullException(nameof(entity));

			if (entity is IAuditableEntity)
			{
				entity.GetType().GetProperty("CreatedOn").SetValue(entity, DateTime.Now);
				entity.GetType().GetProperty("CreatedBy").SetValue(entity, _httpContextAccessor.HttpContext.User.Identity.Name);
			}

			await _ctx.Set<T>().AddAsync(entity);
			await _unitOfWork.CommitAsync();
			return entity.Id;
		}

		public virtual async Task<int> Update<T>(T entity) where T : BaseEntity
		{
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}

			_ctx.Entry(entity).State = EntityState.Modified;

			if (entity is IAuditableEntity)
			{
				entity.GetType().GetProperty("UpdatedOn").SetValue(entity, DateTime.Now);
				entity.GetType().GetProperty("UpdatedBy").SetValue(entity, _httpContextAccessor.HttpContext.User.Identity.Name);
			}
			
			return await _unitOfWork.CommitAsync();
		}

		public virtual async Task<int> Count<T>(Expression<Func<T, bool>> filter = null) where T : BaseEntity
		{
			IQueryable<T> query = _ctx.Set<T>();

			if (filter != null)
			{
				query = query.Where(filter);
			}

			return await query.CountAsync();
		}

		public virtual int Delete<T>(int id) where T : BaseEntity
		{
			var entityToDelete =  Get<T>(id).Result;
			if (entityToDelete == null)
			{
				throw new ArgumentNullException("entity");
			}
			_ctx.Set<T>().Remove(entityToDelete);
			return _unitOfWork.Commit();
		}

		public virtual int Delete<T>(T entity) where T : BaseEntity
		{
			if (entity == null) throw new ArgumentNullException(nameof(entity));
			_ctx.Set<T>().Remove(entity);
			return _unitOfWork.Commit();
		}
		
		public virtual async Task<T[]> Find<T>(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "") where T : BaseEntity
		{
			IQueryable<T> query = _ctx.Set<T>();

			if (filter != null)
			{
				query = query.Where(filter);
			}

			foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}

			if (orderBy != null)
			{
				query = orderBy(query);				
			}
			return await query.ToArrayAsync();
		}

		public virtual async Task<T[]> GetAll<T>() where T : BaseEntity
		{
			return await _ctx
				.Set<T>()
				.ToArrayAsync();
		}
	}
}
