using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OpenWork.Services.Dtos.Workers;
using OpenWork.Services.Interfaces;

namespace OpenWork.Api.Controllers;
[ApiController]
[Route("busynesses")]
public class BusynessesController : Controller
{
	private readonly IBusynessService _service;

	public BusynessesController(IBusynessService service)
	{
		_service = service;
	}

	[HttpPost]
	[Authorize(Roles = "Worker")]
	public async Task<IActionResult> CreateAsync([FromBody] BusynessCreateDto dto)
	{
		return Ok(await _service.CreateAsync(dto));
	}

	[HttpDelete("{id}")]
	[Authorize(Roles = "Worker")]
	public async Task<IActionResult> DeleteAsync(long id)
	{
		return Ok(await _service.DeleteAsync(id));
	}

	[HttpGet("{workerId}")]
	[Authorize(Roles = "User, Admin, Worker")]
	public async Task<IActionResult> GetAllAsync(long workerId, [FromQuery] int page = 1)
	{
		return Ok(await _service.GetAllAsync(workerId, page));
	}

	[HttpPut]
	[Authorize(Roles = "User, Admin, Worker")]
	public async Task<IActionResult> SearchAsync([FromBody] BusynessSearchDto dto, [FromQuery] int page = 1)
	{
		return Ok(await _service.SearchAsync(dto, page));
	}
}
