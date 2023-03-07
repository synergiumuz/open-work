using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OpenWork.Services.Dtos.Admins;
using OpenWork.Services.Interfaces;

namespace OpenWork.Api.Controllers;
[ApiController]
[Route("skills")]
public class SkillsController : Controller
{
	private readonly ISkillService _service;

	public SkillsController(ISkillService service)
	{
		_service = service;
	}

	[HttpPatch("add/{id}")]
	[Authorize(Roles = "Worker")]
	public async Task<IActionResult> AddAsync(long id)
	{
		return Ok(await _service.AddAsync(id));
	}

	[HttpPatch("remove/{id}")]
	[Authorize(Roles = "Worker")]
	public async Task<IActionResult> RemoveAsync(long id)
	{
		return Ok(await _service.RemoveAsync(id));
	}
	[HttpPost]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> CreateAsync([FromBody] SkillCreateDto dto)
	{
		return Ok(await _service.CreateAsync(dto));
	}
	[HttpDelete("{id}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> DeleteAsync(long id)
	{
		return Ok(await _service.DeleteAsync(id));
	}
	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateAsync([FromBody] SkillCreateDto dto, long id)
	{
		return Ok(await _service.UpdateAsync(dto, id));
	}
}
