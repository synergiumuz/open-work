using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using OpenWork.DataAccess.Interfaces;
using OpenWork.Domain.Entities;
using OpenWork.Services.Common.Utils;
using OpenWork.Services.Dtos.Users;
using OpenWork.Services.Interfaces;
using OpenWork.Services.Interfaces.Common;
using OpenWork.Services.Interfaces.Security;
using OpenWork.Services.ViewModels.Users;

namespace OpenWork.Services.Services;

public class UserService : IUserService
{
	private readonly IUnitOfWork _repository;
	private readonly IIdentityService _identity;
	private readonly IHasher _hasher;
	private readonly IAuthManager _auth;
	private readonly IPaginatorService _paginator;
	private readonly int _pageSize = 20;


	public UserService(IUnitOfWork repository, IIdentityService identity, IHasher hasher, IAuthManager auth, IPaginatorService paginator)
	{
		_repository = repository;
		_identity = identity;
		_hasher = hasher;
		_auth = auth;
		_paginator = paginator;
	}

	public async Task<bool> DeleteAsync()
	{
		_ = await _repository.Users.DeleteAsync(_identity.Id);
		return await _repository.SaveChangesAsync() > 0;
	}

	public async Task<IEnumerable<UserBaseViewModel>> GetAllAsync(int page)
	{
		return (await _paginator.PaginateAsync(_repository.Users.GetAll(), new PaginationParams(_pageSize, page))).Select(
				x => new UserBaseViewModel
				{
					Surname = x.Surname,
					Admin = x.Admin,
					Id = x.Id,
					Name = x.Name,
				}
			);
	}

	public async Task<UserViewModel> GetAsync(long id)
	{
		User entity = await _repository.Users.GetAsync(id);
		return new UserViewModel
		{
			Email = entity.Email,
			Id = entity.Id,
			Surname = entity.Surname,
			Admin = entity.Admin,
			Name = entity.Name,
		};
	}

	public async Task<UserBaseViewModel> GetBaseAsync(long id)
	{
		User entity = await _repository.Users.GetAsync(id);
		return new UserBaseViewModel
		{
			Surname = entity.Surname,
			Admin = entity.Admin,
			Id = entity.Id,
			Name = entity.Name,
		};
	}

	public async Task<string> LoginAsync(UserLoginDto dto)
	{
		User entity = await _repository.Users.GetAsync(dto.Email);
		if(entity is not null)
			if(entity.Banned)
				throw new Exception("Banned");
			else if(_hasher.Verify(entity.Password, dto.Password, entity.Email))
				return _auth.GenerateToken(entity);
			else
				throw new Exception("Invalid password");
		else
			throw new Exception("User not found");
	}

	public async Task<bool> RegisterAsync(UserRegisterDto dto)
	{
		User result = await _repository.Users.GetAsync(dto.Email);
		if(result is not null)
			if(result.Banned)
				throw new Exception("Banned");
			else
				throw new Exception("Already exists");
		User entity = dto;
		entity.Password = _hasher.Hash(dto.Password, dto.Email);
		_ = _repository.Users.Add(entity);
		return await _repository.SaveChangesAsync() > 0;
	}

	public async Task<bool> UpdateAsync(UserRegisterDto dto)
	{
		User entity = await _repository.Users.GetAsync(_identity.Id);
		entity.Surname = dto.Surname;
		entity.EmailVerified = dto.Email == entity.Email;
		entity.Email = dto.Email;
		entity.Name = dto.Name;
		entity.Password = _hasher.Hash(dto.Password, dto.Email);
		_ = _repository.Users.Update(entity);
		return await _repository.SaveChangesAsync() > 0;
	}
}
