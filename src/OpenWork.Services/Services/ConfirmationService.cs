using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Caching.Memory;

using OpenWork.DataAccess.Interfaces;
using OpenWork.Domain.Entities;
using OpenWork.Services.Dtos.Common;
using OpenWork.Services.Interfaces.Common;

namespace OpenWork.Services.Services;

internal class ConfirmationService : IConfirmationService
{
	private readonly IUnitOfWork _repository;
	private readonly IMemoryCache _cache;
	private readonly IEmailService _email;

	public ConfirmationService(IUnitOfWork repository, IMemoryCache cache, IEmailService email)
	{
		_repository = repository;
		_cache = cache;
		_email = email;
	}

	public async Task<bool> ConfirmAsync(EmailConfirmDto dto)
	{
		if(_cache.TryGetValue(dto.Email, out int code))
			if(code != dto.Code)
				throw new Exception("Invalid code");
			else
			{
				Worker worker = await _repository.Workers.GetAsync(dto.Email);
				User user = await _repository.Users.GetAsync(dto.Email);
				if(worker is null && user is null)
					throw new Exception("Email not found");
				if(worker is not null)
				{
					worker.EmailVerified = true;
					_repository.Workers.Update(worker);
				}
				if(user is not null)
				{
					user.EmailVerified = true;
					_repository.Users.Update(user);
				}
				return await _repository.SaveChangesAsync() > 0;
			}
		else
			throw new Exception("Code lifetime expired");
	}

	public async Task<bool> SendAsync(string email)
	{
		Random rndm = new Random();
		int code = rndm.Next(100_000, 1_000_000);
		_cache.Set(email, code);
		await _email.SendCodeAsync(email, code);
		return true;
	}
}
