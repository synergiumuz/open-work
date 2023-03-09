using System.Collections.Generic;
using System.Threading.Tasks;

using OpenWork.Services.Dtos.Users;
using OpenWork.Services.ViewModels.Comments;

namespace OpenWork.Services.Interfaces;

public interface ICommentService
{
	public Task<bool> PostAsync(CommentCreateDto dto);
	public Task<bool> DeleteAsync(long id);
	public Task<IEnumerable<CommentViewModel>> GetByUserAsync(long userId, int page);
	public Task<IEnumerable<CommentViewModel>> GetByWorkerAsync(long workerId, int page);
}
