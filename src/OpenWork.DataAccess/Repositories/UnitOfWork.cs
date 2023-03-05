using System.Threading.Tasks;

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
		Busynesses = new BusynessRepository(_context);
		Categories = new CategoryRepository(_context);
		Comments = new CommentRepository(_context);
		Skills = new SkillRepository(_context);
		Workers = new WorkerRepository(_context);
	}

	public IBusynessRepository Busynesses { get; }

	public ICategoryRepository Categories { get; }

	public ICommentRepository Comments { get; }

	public ISkillRepository Skills { get; }

	public IUserRepository Users { get; }

	public IWorkerRepository Workers { get; }

	public async Task<int> SaveChangesAsync()
	{
		return await _context.SaveChangesAsync();
	}
}
