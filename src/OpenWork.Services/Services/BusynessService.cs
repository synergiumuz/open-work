using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenWork.DataAccess.Interfaces;
using OpenWork.Domain.Entities;
using OpenWork.Services.Common.Utils;
using OpenWork.Services.Dtos.Workers;
using OpenWork.Services.Interfaces;
using OpenWork.Services.Interfaces.Common;

namespace OpenWork.Services.Services;

public class BusynessService : IBusynessService
{
	private readonly IUnitOfWork _repository;
	private readonly IIdentityService _identity;
	private readonly IPaginatorService _paginator;
	private readonly int _pageSize = 20;

	public BusynessService(IUnitOfWork repository, IIdentityService identity, IPaginatorService paginator)
	{
		_repository = repository;
		_identity = identity;
		_paginator = paginator;
	}

	public async Task<bool> CreateAsync(BusynessCreateDto dto)
	{
		Busyness entity = new()
		{
			Start = dto.Start,
			End = dto.End,
			WorkerId = _identity.Id
		};
		_repository.Busynesses.Add(entity);
		return await _repository.SaveChangesAsync() > 0;
	}

	public async Task<bool> DeleteAsync(long id)
	{
		await _repository.Busynesses.DeleteAsync(id);
		return await _repository.SaveChangesAsync() > 0;
	}

	public Task<IEnumerable<Busyness>> GetAllAsync(long workerId, int page)
	{
		return _paginator.PaginateAsync(_repository.Busynesses.GetAll().Where(x => x.WorkerId == workerId), new PaginationParams(_pageSize, page));
	}

	public Task<IEnumerable<Busyness>> SearchAsync(BusynessSearchDto dto, int page)
	{
		return _paginator.PaginateAsync(_repository.Busynesses.GetAll()
			.Where(x => x.WorkerId == dto.WorkerId)
			.Where(x => DateOnly.FromDateTime(x.Start) > dto.FromDate && DateOnly.FromDateTime(x.End) < dto.FromDate && TimeOnly.FromDateTime(x.Start) > dto.FromTime && TimeOnly.FromDateTime(x.End) < dto.ToTime)
			, new PaginationParams(_pageSize, page));
	}
}
