using System;
using System.Threading.Tasks;

using OpenWork.DataAccess.Interfaces;
using OpenWork.Domain.Entities;
using OpenWork.Services.Dtos.Users;
using OpenWork.Services.Interfaces;
using OpenWork.Services.Interfaces.Common;
using OpenWork.Services.Interfaces.Security;

namespace OpenWork.Services.Services;

public class UserService : IUserService
{
	private readonly IUnitOfWork _repository;
	private readonly IIdentityService _identity;
	private readonly IHasher _hasher;
	private readonly IAuthManager _auth;


	public UserService(IUnitOfWork repository, IIdentityService identity, IHasher hasher, IAuthManager auth)
	{
		_repository = repository;
		_identity = identity;
		_hasher = hasher;
		_auth = auth;
	}

	public async Task<bool> DeleteAsync()
	{
		_ = await _repository.Users.DeleteAsync(_identity.Id);
		return await _repository.SaveChangesAsync() > 0;
	}

	public async Task<string> LoginAsync(UserLoginDto dto)
	{
		User entity = await _repository.Users.GetAsync(dto.Email);
		if(entity is null)
			throw new Exception("User not found");
		if(!_hasher.Verify(entity.Password, dto.Password, entity.Email))
			throw new Exception("Invalid password");
		return _auth.GenerateToken(entity);
	}

	public async Task<bool> RegisterAsync(UserRegisterDto dto)
	{
		User entity = dto;
		entity.Password = _hasher.Hash(dto.Password, dto.Email);
		_ = _repository.Users.Add(entity);
		return await _repository.SaveChangesAsync() > 0;
	}

	public async Task<bool> UpdateAsync(UserRegisterDto dto)
	{
		User entity = dto;
		entity.Password = _hasher.Hash(dto.Password, dto.Email);
		entity.Id = _identity.Id;
		_ = _repository.Users.Update(entity);
		return await _repository.SaveChangesAsync() > 0;
	}
}
