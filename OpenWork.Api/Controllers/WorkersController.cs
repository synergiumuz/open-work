using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenWork.Services.Dtos.Users;
using OpenWork.Services.Dtos.Workers;
using OpenWork.Services.Interfaces;
using OpenWork.Services.Services;

namespace OpenWork.Api.Controllers
{
	[Route("workers")]
	[ApiController]
	public class WorkersController : ControllerBase
	{
		private readonly IWorkerService _workerService;

		public WorkersController(IWorkerService workerService)
		{
			_workerService = workerService;
		}

		[HttpPost("Register")]
		public async Task<IActionResult> RegisterAsync([FromForm] WorkerRegisterDto dto)
		{
			return Ok(await _workerService.RegisterAsync(dto));
		}

		[HttpPost("Login")]
		public async Task<IActionResult> LoginAsync([FromForm] WorkerLoginDto dto)
		{
			return Ok(await _workerService.LoginAsync(dto));
		}

		[HttpDelete("")]
		[Authorize]
		public async Task<IActionResult> DeleteAsync()
		{
			return Ok(await _workerService.DeleteAsync());
		}

		[HttpPut("update")]
		public async Task<IActionResult> UpdateAsync([FromForm] WorkerRegisterDto dto)
		{
			return Ok(await _workerService.UpdateAsync(dto));
		}

	}
}
