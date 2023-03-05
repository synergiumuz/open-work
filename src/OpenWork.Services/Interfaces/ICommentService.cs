using System.Collections.Generic;
using System.Threading.Tasks;

using OpenWork.Domain.Entities;
using OpenWork.Services.Dtos.Users;

namespace OpenWork.Services.Interfaces;

public interface ICommentService
{
	public Task<bool> CreateAsync(CommentCreateDto dto);
	public Task<bool> UpdateAsync(CommentCreateDto dto);
	public Task<IEnumerable<Comment>> GetByUserAsync(long userId, int page);
	public Task<IEnumerable<Comment>> GetByWorkerAsync(long workerId, int page);
}
