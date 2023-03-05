using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OpenWork.Services.Dtos.Workers;
using OpenWork.Services.Interfaces;

namespace OpenWork.Api.Controllers;
[ApiController]
[Route("busynesses")]
[Authorize(Roles = "Worker")]
public class BusynessesController : Controller
{
	private readonly IBusynessService _service;

	public BusynessesController(IBusynessService service)
	{
		_service = service;
	}

	[HttpPost]
	public async Task<IActionResult> CreateAsync(BusynessCreateDto dto)
	{
		return Ok(await _service.CreateAsync(dto));
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteAsync(long id)
	{
		return Ok(await _service.DeleteAsync(id));
	}

	[HttpGet("{workerId}")]
	public async Task<IActionResult> GetAllAsync(long workerId, [FromQuery] int page = 1)
	{
		return Ok(await _service.GetAllAsync(workerId, page));
	}

	[HttpPut]
	public async Task<IActionResult> SearchAsync(BusynessSearchDto dto, [FromQuery] int page = 1)
	{
		return Ok(await _service.SearchAsync(dto, page));
	}
}
