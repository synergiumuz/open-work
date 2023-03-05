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
	public async Task<IActionResult> CreateAsync(CommentCreateDto dto)
	{
		return Ok(await _service.CreateAsync(dto));
	}
	[HttpPut]
	public async Task<IActionResult> UpdateAsync(CommentCreateDto dto)
	{
		return Ok(await _service.UpdateAsync(dto));
	}
	[HttpGet("user/{userId}")]
	public async Task<IActionResult> GetByUserAsync(long userId, [FromQuery] int page)
	{
		return Ok(await _service.GetByUserAsync(userId, page));
	}
	[HttpGet("worker/{workerId}")]
	public async Task<IActionResult> GetByWorkerAsync(long workerId, [FromQuery] int page)
	{
		return Ok(await _service.GetByWorkerAsync(workerId, page));
	}
}
