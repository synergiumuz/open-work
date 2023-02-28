using System;
using System.Threading.Tasks;

using OpenWork.DataAccess.Interfaces;
using OpenWork.Domain.Entities;
using OpenWork.Services.Dtos.Workers;
using OpenWork.Services.Interfaces;
using OpenWork.Services.Interfaces.Common;
using OpenWork.Services.Interfaces.Security;

namespace OpenWork.Services.Services;

public class WorkerService : IWorkerService
{
	private readonly IUnitOfWork _repository;
	private readonly IHasher _hasher;
	private readonly IAuthManager _auth;
	private readonly IIdentityService _identity;

	public WorkerService(IUnitOfWork repository, IHasher hasher, IAuthManager auth, IIdentityService identity)
	{
		_repository = repository;
		_hasher = hasher;
		_auth = auth;
		_identity = identity;
	}

	public async Task<bool> DeleteAsync()
	{
		_ = await _repository.Workers.DeleteAsync(_identity.Id);
		return await _repository.SaveChangesAsync() > 0;
	}

	public async Task<string> LoginAsync(WorkerLoginDto dto)
	{
		Worker entity = await _repository.Workers.GetAsync(dto.Email);
		if(entity is null)
			throw new Exception("Worker not found");
		if(!_hasher.Verify(entity.Password, dto.Password, entity.Email))
			throw new Exception("Invalid password");
		return _auth.GenerateToken(entity);
	}

	public async Task<bool> RegisterAsync(WorkerRegisterDto dto)
	{
		Worker entity = dto;
		entity.Password = _hasher.Hash(dto.Password, dto.Email);
		_ = _repository.Workers.Add(entity);
		return await _repository.SaveChangesAsync() > 0;
	}

	public async Task<bool> UpdateAsync(WorkerRegisterDto dto)
	{
		Worker entity = dto;
		entity.Password = _hasher.Hash(dto.Password, dto.Email);
		entity.Id = _identity.Id;
		_ = _repository.Workers.Update(entity);
		return await _repository.SaveChangesAsync() > 0;
	}
}
