using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OpenWork.Services.Interfaces;

namespace OpenWork.Api.Controllers;
[ApiController]
[Authorize(Roles = "Admin")]
[Route("admin")]
public class AdminsController : ControllerBase
{
	private readonly IAdminService _service;

	public AdminsController(IAdminService service)
	{
		_service = service;
	}

	[HttpDelete("{email}")]
	public async Task<IActionResult> BanAsync(string email)
	{
		return Ok(await _service.BanAsync(email));
	}
	[HttpPost("{id}")]
	public async Task<IActionResult> MakeAdminAsync(long id)
	{
		return Ok(await _service.MakeAdminAsync(id));
	}
	[HttpDelete("reset")]
	public async Task<IActionResult> ResetAsync()
	{
		return Ok(await _service.ResetAsync());
	}
}
