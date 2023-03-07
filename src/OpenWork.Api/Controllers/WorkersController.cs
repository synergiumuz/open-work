using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OpenWork.Services.Dtos.Workers;
using OpenWork.Services.Interfaces;

namespace OpenWork.Api.Controllers;

[Route("workers")]
[ApiController]
public class WorkersController : ControllerBase
{
	private readonly IWorkerService _service;
	public WorkersController(IWorkerService service)
	{
		_service = service;
	}
	[HttpGet]
	[Authorize(Roles = "User, Worker, Admin")]
	public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
	{
		return Ok(await _service.GetAllAsync(page));
	}

	[HttpPost("search")]
	[Authorize(Roles = "User, Worker, Admin")]
	public async Task<IActionResult> SearchAsync([FromBody] SearchDto dto, [FromQuery] int page = 1)
		=> Ok(await _service.SearchAsync(dto, page));

	[HttpGet("{id}")]
	[Authorize(Roles = "User, Worker, Admin")]
	public async Task<IActionResult> GetAsync(long id)
		=> Ok(await _service.GetAsync(id));

	[HttpPost("register")]
	[AllowAnonymous]
	public async Task<IActionResult> RegisterAsync([FromForm] WorkerRegisterDto dto)
	{
		return Ok(await _service.RegisterAsync(dto));
	}

	[HttpPost("login")]
	[AllowAnonymous]
	public async Task<IActionResult> LoginAsync([FromBody] WorkerLoginDto dto)
	{
		return Ok(await _service.LoginAsync(dto));
	}

	[HttpDelete]
	[Authorize(Roles = "Worker")]
	public async Task<IActionResult> DeleteAsync()
	{
		return Ok(await _service.DeleteAsync());
	}

	[HttpPut]
	public async Task<IActionResult> UpdateAsync([FromForm] WorkerRegisterDto dto)
	{
		return Ok(await _service.UpdateAsync(dto));
	}

}
