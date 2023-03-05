using System.Linq;
using System.Threading.Tasks;

using OpenWork.Domain.Entities;

namespace OpenWork.DataAccess.Interfaces.Common;

public interface ICommentRepository : IBasicRepository<Comment>
{
	public IQueryable<Comment> GetByUser(long userId);
	public IQueryable<Comment> GetByWorker(long workerId);
	public Task<Comment> GetAsync(long userId, long workerId);
}
