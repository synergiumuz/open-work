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
	protected readonly AppDbContext _context;
	protected readonly DbSet<T> _set;

	public BasicRepository(AppDbContext context)
	{
		_set = context.Set<T>();
		_context = context;
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

	public virtual IQueryable<T> GetAll()
	{
		return _set.AsQueryable();
	}

	public virtual async Task<T> GetAsync(long id)
	{
		return await _set.FindAsync(id);
	}

	public bool Update(T entity)
	{
		_ = _set.Update(entity);
		return true;
	}
}
