using System.Threading.Tasks;

using OpenWork.Domain.Entities;

namespace OpenWork.DataAccess.Interfaces.Common;

public interface IUserRepository : IBasicRepository<User>
{
	public Task<User> GetAsync(string email);
}
