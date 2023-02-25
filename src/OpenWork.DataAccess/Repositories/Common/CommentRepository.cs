using System.Linq;

using OpenWork.DataAccess.DbContexts;
using OpenWork.DataAccess.Interfaces.Common;
using OpenWork.Domain.Entities;

namespace OpenWork.DataAccess.Repositories.Common;

public class CommentRepository : BasicRepository<Comment>, ICommentRepository
{
	public CommentRepository(AppDbContext context) : base(context)
	{
	}

	public IQueryable<Comment> GetByUser(long userId)
	{
		return _set.Where(x => x.UserId == userId);
	}

	public IQueryable<Comment> GetByWorker(long workerId)
	{
		return _set.Where(x=> x.WorkerId == workerId);
	}
}
