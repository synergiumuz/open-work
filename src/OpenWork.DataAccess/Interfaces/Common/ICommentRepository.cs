using OpenWork.Domain.Entities;

namespace OpenWork.DataAccess.Interfaces.Common;

public interface ICommentRepository : IBasicRepository<Comment>
{
	public IQueryable<Comment> GetByUser(long userId);
	public IQueryable<Comment> GetByWorker(long workerId);
}
