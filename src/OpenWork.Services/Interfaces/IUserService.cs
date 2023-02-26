using System.Threading.Tasks;

using OpenWork.Services.Dtos.Users;

namespace OpenWork.Services.Interfaces;

public interface IUserService
{
	public Task<bool> RegisterAsync(UserRegisterDto dto);

	public Task<string> LoginAsync(UserLoginDto dto);

	public Task<bool> DeleteAsync();

	public Task<bool> UpdateAsync(UserRegisterDto dto);
}
