using System;
using System.Threading.Tasks;

using OpenWork.DataAccess.Interfaces;
using OpenWork.Domain.Entities;
using OpenWork.Services.Interfaces;
using OpenWork.Services.Interfaces.Common;

namespace OpenWork.Services.Services;

public class AdminService : IAdminService
{
	private readonly IUnitOfWork _repository;
	private readonly IIdentityService _identity;

	public AdminService(IUnitOfWork repository, IIdentityService identity)
	{
		_repository = repository;
		_identity = identity;
	}

	public async Task<bool> BanAsync(string email)
	{
		User user = await _repository.Users.GetAsync(email);
		Worker worker = await _repository.Workers.GetAsync(email);
		if(user is null && worker is null)
			throw new Exception("Email not found");
		if(user is not null)
		{
			user.Banned = true;
			_repository.Users.Update(user);
		}
		if(worker is not null)
		{
			worker.Banned = true;
			_repository.Workers.Update(worker);
		}
		return await _repository.SaveChangesAsync() > 0;
	}

	public async Task<bool> MakeAdminAsync(long userId)
	{
		if(_identity.Id != 13)
			throw new Exception("Not super admin");
		User entity = await _repository.Users.GetAsync(userId);
		entity.Admin = true;
		_repository.Users.Update(entity);
		return await _repository.SaveChangesAsync() > 0;
	}
}
