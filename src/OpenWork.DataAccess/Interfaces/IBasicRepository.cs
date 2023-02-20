using OpenWork.Domain.Common;

namespace OpenWork.DataAccess.Interfaces;

public interface IBasicRepository<T> where T : BaseEntity
{
	public Task<bool> AddAsync(T entity);
	public Task<bool> UpdateAsync(T entity);
	public Task<bool> DeleteAsync(long id);
	public Task<T> GetAsync(long id);
	public IQueryable<T> GetALl();
}
