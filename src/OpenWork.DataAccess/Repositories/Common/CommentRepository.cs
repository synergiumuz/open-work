using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

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
		return _set.Where(x => x.UserId == userId).Include(x => x.User).Include(x => x.Worker).AsNoTracking();
	}

	public IQueryable<Comment> GetByWorker(long workerId)
	{
		return _set.Where(x => x.WorkerId == workerId).Include(x => x.User).Include(x => x.Worker).AsNoTracking();
	}
	public override IQueryable<Comment> GetAll()
	{
		return base.GetAll().Include(x => x.User).Include(x => x.Worker).AsNoTracking();
	}
	public override async Task<Comment> GetAsync(long id)
	{
		Comment result = await base.GetAsync(id);
		if(result is not null)
		{
			await _context.Entry(result).Reference(x => x.User).LoadAsync();
			await _context.Entry(result).Reference(x => x.Worker).LoadAsync();
		}
		return result;
	}

	public async Task<Comment> GetAsync(long userId, long workerId)
	{
		return await _set.FirstOrDefaultAsync(x => x.UserId == userId && x.WorkerId == workerId);
	}
}
