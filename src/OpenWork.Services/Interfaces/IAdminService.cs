using System.Threading.Tasks;

namespace OpenWork.Services.Interfaces;

public interface IAdminService
{
	public Task<bool> BanWorker(long workerId);
	public Task<bool> BanUser(long userId);
	public Task<bool> MakeAdmin(long userId);
}
