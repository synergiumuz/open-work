using OpenWork.Domain.Common;

namespace OpenWork.DataAccess.Interfaces;

public interface IBasicRepository<T> where T : BaseEntity
{
	public bool Add(T entity);
	public bool Update(T entity);
	public Task<bool> DeleteAsync(long id);
	public Task<T> GetAsync(long id);
	public IQueryable<T> GetAll();
}
