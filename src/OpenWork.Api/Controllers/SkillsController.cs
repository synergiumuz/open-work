using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

	[HttpPost]
	public async Task<IActionResult> AddAsync(long id)
	{
		return Ok(await _service.AddAsync(id));
	}

	[HttpDelete]
	public async Task<IActionResult> RemoveAsync(long id)
	{
		return Ok(await _service.RemoveAsync(id));
	}
}
