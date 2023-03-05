using System.Threading.Tasks;

using OpenWork.DataAccess.Interfaces.Common;

namespace OpenWork.DataAccess.Interfaces;

public interface IUnitOfWork
{
	public IBusynessRepository Busynesses { get; }
	public ICategoryRepository Categories { get; }
	public ICommentRepository Comments { get; }
	public ISkillRepository Skills { get; }
	public IUserRepository Users { get; }
	public IWorkerRepository Workers { get; }
	public Task<int> SaveChangesAsync();
}
