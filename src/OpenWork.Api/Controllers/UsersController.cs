using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OpenWork.Services.Dtos.Users;
using OpenWork.Services.Interfaces;

namespace OpenWork.Api.Controllers;

[Route("users")]
[ApiController]
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

	[HttpDelete]
	[Authorize(Roles = "Admin, User")]
	public async Task<IActionResult> DeleteAsync()
	{
		return Ok(await _userService.DeleteAsync());
	}

	[HttpPut("update")]
	public async Task<IActionResult> UpdateAsync([FromForm] UserRegisterDto dto)
	{
		return Ok(await _userService.UpdateAsync(dto));
	}
}
