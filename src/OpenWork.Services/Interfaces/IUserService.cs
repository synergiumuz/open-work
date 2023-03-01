using System.Collections.Generic;
using System.Threading.Tasks;

using OpenWork.Services.Dtos.Users;
using OpenWork.Services.ViewModels.Users;

namespace OpenWork.Services.Interfaces;

public interface IUserService
{
	public Task<bool> RegisterAsync(UserRegisterDto dto);

	public Task<string> LoginAsync(UserLoginDto dto);

	public Task<bool> DeleteAsync();

	public Task<bool> UpdateAsync(UserRegisterDto dto);

	public Task<UserBaseViewModel> GetBaseAsync(long id);

	public Task<UserViewModel> GetAsync(long id);

	public Task<IEnumerable<UserBaseViewModel>> GetAllAsync(int page);
}
