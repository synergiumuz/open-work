using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenWork.Services.Dtos.Admins;
using OpenWork.Services.Dtos.Users;
using OpenWork.Services.Interfaces;
using OpenWork.Services.Services;
using System.Data;

namespace OpenWork.Api.Controllers;

[ApiController]
[Route("categories")]
[Authorize(Roles = "Admin")]
public class CategoriesController : Controller
{
	private readonly ICategoryService _service;

	public CategoriesController(ICategoryService service)
	{
		_service = service;
	}

	[HttpGet("all")]
	public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
	{
		return Ok(await _service.GetAllAsync(page));
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetAsync(long id)
		=> Ok(await _service.GetAsync(id));


	[HttpDelete]
	public async Task<IActionResult> DeleteAsync([FromForm] long id)
	{
		return Ok(await _service.DeleteAsync(id));
	}

	[HttpPost]
	public async Task<IActionResult> CreateAsync([FromForm] CategoryCreateDto dto)
	{
		return Ok(await _service.CreateAsync(dto));
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateAsync([FromForm] CategoryCreateDto dto, long id)
	{
		return Ok(await _service.UpdateAsync(id, dto));
	}
}
