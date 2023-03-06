using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.IdentityModel.Tokens;

using OpenWork.DataAccess.Interfaces;
using OpenWork.Domain.Entities;
using OpenWork.Services.Common.Utils;
using OpenWork.Services.Dtos.Workers;
using OpenWork.Services.Interfaces;
using OpenWork.Services.Interfaces.Common;
using OpenWork.Services.Interfaces.Security;
using OpenWork.Services.ViewModels.Workers;
namespace OpenWork.Services.Services;

public class WorkerService : IWorkerService
{
	private readonly IFileService _filer;
	private readonly IUnitOfWork _repository;
	private readonly IHasher _hasher;
	private readonly IAuthManager _auth;
	private readonly IIdentityService _identity;
	private readonly IPaginatorService _paginator;
	private int _pageSize = 20;

	public WorkerService(IUnitOfWork repository, IHasher hasher, IAuthManager auth, IIdentityService identity, IPaginatorService paginator, IFileService filer)
	{
		_filer = filer;
		_repository = repository;
		_hasher = hasher;
		_auth = auth;
		_identity = identity;
		_paginator = paginator;
	}

	public async Task<bool> DeleteAsync()
	{
		_ = await _repository.Workers.DeleteAsync(_identity.Id);
		return await _repository.SaveChangesAsync() > 0;
	}

	public async Task<IEnumerable<WorkerBaseViewModel>> SearchAsync(SearchDto dto, int page)
	{
		return (await
			_paginator.PaginateAsync(
				_repository.Workers.GetAll().Where(
					wrk => wrk.Skills.Any(
						skl => dto.AllowedSkillsId.Any(id => id == skl.Id)
					)
				)
			, new PaginationParams(_pageSize, page))).Select(
				wrk => new WorkerBaseViewModel
				{
					Id = wrk.Id,
					Surname = wrk.Surname,
					LastSeen = wrk.LastSeen,
					Name = wrk.Name,
					Rating = wrk.Comments.Average(x => x.Satisfied ? 1 : 0) * 5
				}
			);
	}

	public async Task<WorkerViewModel> GetAsync(long id)
	{
		Worker entity = await _repository.Workers.GetAsync(id);
		if(entity is null)
			throw new Exception("Worker not found");
		return new WorkerViewModel
		{
			Skills = entity.Skills,
			Surname = entity.Surname,
			LastSeen = entity.LastSeen,
			Comments = entity.Comments,
			Email = entity.Email,
			Id = entity.Id,
			Name = entity.Name,
			Phone = entity.Phone,
			Rating = entity.Comments.IsNullOrEmpty() ? null : entity.Comments.Average(x => x.Satisfied ? 1 : (double)0) * 5
		};
	}

	public async Task<WorkerBaseViewModel> GetBaseAsync(long id)
	{
		Worker entity = await _repository.Workers.GetAsync(id);
		return new WorkerBaseViewModel
		{
			Id = entity.Id,
			Surname = entity.Surname,
			LastSeen = entity.LastSeen,
			Name = entity.Name,
			Rating = entity.Comments.Average(x => x.Satisfied ? 1 : 0) * 5
		};
	}

	public async Task<string> LoginAsync(WorkerLoginDto dto)
	{
		Worker entity = await _repository.Workers.GetAsync(dto.Email);
		if(entity is not null)
			if(entity.Banned)
				throw new Exception("Banned");
			else if(_hasher.Verify(entity.Password, dto.Password, entity.Email))
				return _auth.GenerateToken(entity);
			else
				throw new Exception("Invalid password");
		else
			throw new Exception("Worker not found");
	}

	public async Task<bool> RegisterAsync(WorkerRegisterDto dto)
	{
		Worker entity = dto;
		entity.Password = _hasher.Hash(dto.Password, dto.Email);
		if(dto.Image is not null)
			entity.Image = await _filer.SaveImageAsync(dto.Image);
		_ = _repository.Workers.Add(entity);
		return await _repository.SaveChangesAsync() > 0;
	}

	public async Task<bool> UpdateAsync(WorkerRegisterDto dto)
	{
		Worker entity = await _repository.Workers.GetAsync(_identity.Id);
		if(dto.Image is not null)
			entity.Image = await _filer.SaveImageAsync(dto.Image);
		entity.PhoneVerified = entity.Phone == dto.Phone;
		entity.Phone = dto.Phone;
		entity.EmailVerified = entity.Email == dto.Email;
		entity.LastSeen = DateTime.Now;
		entity.Email = dto.Email;
		entity.Name = dto.Name;
		entity.Surname = dto.Surname;
		entity.Password = _hasher.Hash(dto.Password, dto.Email);
		_ = _repository.Workers.Update(entity);
		return await _repository.SaveChangesAsync() > 0;
	}

	public async Task<IEnumerable<WorkerBaseViewModel>> GetAllAsync(int page)
	{
		return (await
			_paginator.PaginateAsync(
				_repository.Workers.GetAll()
			, new PaginationParams(_pageSize, page))).Select(
				wrk => new WorkerBaseViewModel
				{
					Id = wrk.Id,
					Surname = wrk.Surname,
					LastSeen = wrk.LastSeen,
					Name = wrk.Name,
					Rating = wrk.Comments.Average(x => x.Satisfied ? 1 : 0) * 5
				}
			);
	}
}
