using OpenWork.DataAccess.DbContexts;
using OpenWork.DataAccess.Interfaces;
using OpenWork.DataAccess.Interfaces.Common;
using OpenWork.DataAccess.Repositories.Common;

namespace OpenWork.DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork
{
	private readonly AppDbContext _context;

	public UnitOfWork(AppDbContext context)
	{
		_context = context;
		Users = new UserRepository(_context);
	}

	public IBusinessRepository Businesses => throw new NotImplementedException();

	public ICategoryRepository Categories => throw new NotImplementedException();

	public ICommentRepository Comments => throw new NotImplementedException();

	public ISphereRepository Spheres => throw new NotImplementedException();

	public IUserRepository Users { get; }

	public IWorkerRepository Workers => throw new NotImplementedException();

	public async Task<int> SaveChanges()
	{
		return await _context.SaveChangesAsync();
	}
}
