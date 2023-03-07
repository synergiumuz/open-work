using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OpenWork.Services.Dtos.Users;
using OpenWork.Services.Interfaces;

namespace OpenWork.Api.Controllers;

[Route("users")]
[ApiController]
public class UsersController : Controller
{
	private readonly IUserService _service;


	public UsersController(IUserService service)
	{
		_service = service;
	}



	[HttpPost("register")]
	[AllowAnonymous]
	public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterDto dto)
	{
		return Ok(await _service.RegisterAsync(dto));
	}

	[HttpPost("login")]
	[AllowAnonymous]
	public async Task<IActionResult> LoginAsync([FromBody] UserLoginDto dto)
	{
		return Ok(await _service.LoginAsync(dto));
	}

	[HttpDelete]
	[Authorize(Roles = "Admin, User")]
	public async Task<IActionResult> DeleteAsync()
	{
		return Ok(await _service.DeleteAsync());
	}

	[HttpPut]
	[Authorize(Roles = "Admin, User")]
	public async Task<IActionResult> UpdateAsync([FromBody] UserRegisterDto dto)
	{
		return Ok(await _service.UpdateAsync(dto));
	}

	[HttpGet("base/{id}")]
	[Authorize(Roles = "Admin, User")]
	public async Task<IActionResult> GetBaseAsync(long id)
	{
		return Ok(await _service.GetBaseAsync(id));
	}

	[HttpGet("{id}")]
	[Authorize(Roles = "Admin, User")]
	public async Task<IActionResult> GetAsync(long id)
	{
		return Ok(await _service.GetAsync(id));
	}

	[HttpGet]
	[Authorize("Admin")]
	public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
	{
		return Ok(await _service.GetAllAsync(page));
	}
}
