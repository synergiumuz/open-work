using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using OpenWork.DataAccess.DbContexts;
using OpenWork.DataAccess.Interfaces;
using OpenWork.Domain.Common;

namespace OpenWork.DataAccess.Repositories;

public class BasicRepository<T> : IBasicRepository<T> where T : BaseEntity
{
	protected readonly DbSet<T> _set;

	public BasicRepository(AppDbContext context)
	{
		_set = context.Set<T>();
	}

	public bool Add(T entity)
	{
		_ = _set.Add(entity);
		return true;
	}

	public async Task<bool> DeleteAsync(long id)
	{
		_ = _set.Remove(await GetAsync(id));
		return true;
	}

	public IQueryable<T> GetAll()
	{
		return _set.AsQueryable();
	}

	public async Task<T> GetAsync(long id)
	{
		T? entity = await GetAsync(id);
		return entity is null ? throw new Exception("Entity Not Found") : entity;
	}

	public bool Update(T entity)
	{
		_ = _set.Update(entity);
		return true;
	}
}
