using OpenWork.DataAccess.Interfaces.Common;

namespace OpenWork.DataAccess.Interfaces;

public interface IUnitOfWork
{
	public IBusinessRepository Businesses { get; }
	public ICategoryRepository Categories { get; }
	public ICommentRepository Comments { get; }
	public ISphereRepository Spheres { get; }
	public IUserRepository Users { get; }
	public IWorkerRepository Workers { get; }
}
