using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using OpenWork.DataAccess.Interfaces;
using OpenWork.Domain.Entities;
using OpenWork.Services.Common.Utils;
using OpenWork.Services.Dtos.Users;
using OpenWork.Services.Interfaces;
using OpenWork.Services.Interfaces.Common;

namespace OpenWork.Services.Services;

public class CommentService : ICommentService
{
	private readonly IUnitOfWork _repository;
	private readonly IPaginatorService _paginator;
	private readonly IIdentityService _identity;
	private readonly int _pageSize = 20;

	public CommentService(IUnitOfWork repository, IPaginatorService paginator, IIdentityService identity)
	{
		_repository = repository;
		_paginator = paginator;
		_identity = identity;
	}

	public async Task<bool> CreateAsync(CommentCreateDto dto)
	{
		Comment comment = new Comment
		{
			Satisfied = dto.Satisfied,
			Content = dto.Content,
			CreatedAt = DateTime.Now,
			UserId = _identity.Id,
			WorkerId = dto.WorkerId,
		};
		_repository.Comments.Add(comment);
		return await _repository.SaveChangesAsync() > 0;
	}

	public Task<IEnumerable<Comment>> GetByUserAsync(long userId, int page)
	{
		return _paginator.PaginateAsync(_repository.Comments.GetByUser(userId), new PaginationParams(_pageSize, page));
	}

	public Task<IEnumerable<Comment>> GetByWorkerAsync(long workerId, int page)
	{
		return _paginator.PaginateAsync(_repository.Comments.GetByWorker(workerId), new PaginationParams(_pageSize, page));
	}

	public async Task<bool> UpdateAsync(CommentCreateDto dto)
	{
		Comment comment = await _repository.Comments.GetAsync(_identity.Id, dto.WorkerId);
		comment.Satisfied = dto.Satisfied;
		comment.Content = dto.Content;
		_repository.Comments.Update(comment);
		return await _repository.SaveChangesAsync() > 0;
	}
}
