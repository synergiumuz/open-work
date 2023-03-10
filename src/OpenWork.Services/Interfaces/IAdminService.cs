using System.Threading.Tasks;

namespace OpenWork.Services.Interfaces;

public interface IAdminService
{
	public Task<bool> BanAsync(string email);
	public Task<bool> MakeAdminAsync(long userId);
	public Task<bool> ResetAsync();
}
