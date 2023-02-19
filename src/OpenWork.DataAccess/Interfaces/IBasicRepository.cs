using System;
using OpenWork.Domain.Common;

namespace OpenWork.DataAccess.Interfaces;

public interface IBasicRepository<T> where T : BaseEntity
{
	public Task<bool> CreateAsync(T entity);
	public Task<bool> UpdateAsync(T entity);
	public Task<bool> DeleteAsync(long id);
	public Task<T> GetAsync(long id);
}
