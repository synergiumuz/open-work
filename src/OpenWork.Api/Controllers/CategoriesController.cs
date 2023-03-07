using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OpenWork.Services.Dtos.Admins;
using OpenWork.Services.Interfaces;

namespace OpenWork.Api.Controllers;

[ApiController]
[Route("categories")]
public class CategoriesController : Controller
{
	private readonly ICategoryService _service;

	public CategoriesController(ICategoryService service)
	{
		_service = service;
	}

	[HttpGet]
	[Authorize(Roles = "User, Worker, Admin")]
	public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
	{
		return Ok(await _service.GetAllAsync(page));
	}

	[HttpGet("{id}")]
	[Authorize(Roles = "User, Worker, Admin")]
	public async Task<IActionResult> GetAsync(long id)
		=> Ok(await _service.GetAsync(id));


	[HttpDelete("{id}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> DeleteAsync(long id)
	{
		return Ok(await _service.DeleteAsync(id));
	}

	[HttpPost]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> CreateAsync([FromBody] CategoryCreateDto dto)
	{
		return Ok(await _service.CreateAsync(dto));
	}

	[HttpPut("{id}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> UpdateAsync([FromBody] CategoryCreateDto dto, long id)
	{
		return Ok(await _service.UpdateAsync(id, dto));
	}
}
