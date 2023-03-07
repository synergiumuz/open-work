using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OpenWork.Services.Dtos.Common;
using OpenWork.Services.Interfaces.Common;

namespace OpenWork.Api.Controllers;
[ApiController]
[Route("confirm")]
[AllowAnonymous]
public class ConfirmationController : ControllerBase
{
	private readonly IConfirmationService _service;

	public ConfirmationController(IConfirmationService service)
	{
		_service = service;
	}
	[HttpGet("{email}")]
	public async Task<IActionResult> SendAsync(string email)
	{
		return Ok(await _service.SendAsync(email));
	}
	[HttpPost("email")]
	public async Task<IActionResult> ConfirmAsync([FromBody] EmailConfirmDto dto)
	{
		return Ok(await _service.ConfirmAsync(dto));
	}
	[HttpPost("phone")]
	public async Task<IActionResult> ConfirmAsync([FromBody] PhoneConfirmDto dto)
	{
		return Ok(await _service.ConfirmAsync(dto));
	}
}
