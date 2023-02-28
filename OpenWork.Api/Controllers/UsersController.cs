using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using OpenWork.Services.Common.Exceptions;
using OpenWork.Services.Dtos.Users;
using OpenWork.Services.Interfaces;

namespace OpenWork.Api.Controllers
{
	[Route("users")]

	public class UsersController : Controller
	{
		private readonly IUserService _userService;
		public UsersController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpPost("register")]
		[AllowAnonymous]
		public async Task<IActionResult> RegisterAsync([FromForm] UserRegisterDto dto)
		{
			return Ok(await _userService.RegisterAsync(dto));
		}

		[HttpPost("login")]
		[AllowAnonymous]
		public async Task<IActionResult> LoginAsync([FromForm] UserLoginDto dto)
		{
			return Ok(await _userService.LoginAsync(dto));
		}
	}
}
