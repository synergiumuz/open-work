using OpenWork.Domain.Entities;

namespace OpenWork.DataAccess.Interfaces.Common;

public interface IWorkerRepository : IBasicRepository<Worker>
{
	public Task<Worker> GetAsync(string email);
}
