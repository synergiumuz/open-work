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
using OpenWork.Services.ViewModels.Comments;

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

	public async Task<bool> DeleteAsync(long id)
	{
		await _repository.Comments.DeleteAsync(id);
		return await _repository.SaveChangesAsync() > 0;
	}

	public async Task<IEnumerable<CommentViewModel>> GetByUserAsync(long userId, int page)
	{
		return (await _paginator.PaginateAsync(_repository.Comments.GetByUser(userId), new PaginationParams(_pageSize, page))).Select(x => (CommentViewModel)x);
	}

	public async Task<IEnumerable<CommentViewModel>> GetByWorkerAsync(long workerId, int page)
	{
		return (await _paginator.PaginateAsync(_repository.Comments.GetByWorker(workerId), new PaginationParams(_pageSize, page))).Select(x => (CommentViewModel)x);
	}

	public async Task<bool> PostAsync(CommentCreateDto dto)
	{
		Comment result = await _repository.Comments.GetAsync(_identity.Id, dto.WorkerId);
		if(result is null)
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
		result.Satisfied = dto.Satisfied;
		result.Content = dto.Content;
		_repository.Comments.Update(result);
		return await _repository.SaveChangesAsync() > 0;
	}
}
