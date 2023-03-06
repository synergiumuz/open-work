using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OpenWork.Services.Dtos.Admins;
using OpenWork.Services.Interfaces;

namespace OpenWork.Api.Controllers;
[ApiController]
[Route("skills")]
[Authorize(Roles = "Worker")]
public class SkillsController : Controller
{
	private readonly ISkillService _service;

	public SkillsController(ISkillService service)
	{
		_service = service;
	}

	[HttpPatch("add")]
	public async Task<IActionResult> AddAsync(long id)
	{
		return Ok(await _service.AddAsync(id));
	}

	[HttpPatch("remove")]
	public async Task<IActionResult> RemoveAsync(long id)
	{
		return Ok(await _service.RemoveAsync(id));
	}
	[HttpPost]
	public async Task<IActionResult> CreateAsync(SkillCreateDto dto)
	{
		return Ok(await _service.CreateAsync(dto));
	}
	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteAsync(long id)
	{
		return Ok(await _service.DeleteAsync(id));
	}
}
