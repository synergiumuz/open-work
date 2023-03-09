﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OpenWork.Services.Dtos.Users;
using OpenWork.Services.Interfaces;

namespace OpenWork.Api.Controllers;
[ApiController]
[Route("comments")]
public class CommentsController : ControllerBase
{
	private readonly ICommentService _service;

	public CommentsController(ICommentService service)
	{
		_service = service;
	}
	[HttpPost]
	[Authorize(Roles = "User, Admin")]
	public async Task<IActionResult> PostAsync([FromBody] CommentCreateDto dto)
	{
		return Ok(await _service.PostAsync(dto));
	}
	[HttpGet("user/{userId}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> GetByUserAsync(long userId, [FromQuery] int page)
	{
		return Ok(await _service.GetByUserAsync(userId, page));
	}
	[HttpGet("worker/{workerId}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> GetByWorkerAsync(long workerId, [FromQuery] int page)
	{
		return Ok(await _service.GetByWorkerAsync(workerId, page));
	}
	[HttpDelete("{id}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> DeleteAsync(long id)
	{
		return Ok(await _service.DeleteAsync(id));
	}
}
