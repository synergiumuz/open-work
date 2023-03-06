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

	public async Task<bool> BanUser(long userId)
	{
		User entity = await _repository.Users.GetAsync(userId);
		entity.Banned = true;
		_repository.Users.Update(entity);
		return await _repository.SaveChangesAsync() > 0;
	}

	public async Task<bool> BanWorker(long workerId)
	{
		Worker entity = await _repository.Workers.GetAsync(workerId);
		entity.Banned = true;
		_repository.Workers.Update(entity);
		return await _repository.SaveChangesAsync() > 0;
	}

	public async Task<bool> MakeAdmin(long userId)
	{
		if(_identity.Id != 13)
			throw new Exception("Not super admin");
		User entity = await _repository.Users.GetAsync(userId);
		entity.Admin = true;
		_repository.Users.Update(entity);
		return await _repository.SaveChangesAsync() > 0;
	}
}
