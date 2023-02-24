using OpenWork.Services.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWork.Services.Interfaces
{
    public interface IUserService
	{
		public Task<bool> RegisterAsync(UserRegisterDto dto);

		public Task<string> LoginAsync(UserLoginDto dto);

	}
}
