

using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using OpenWork.DataAccess.DbContexts;
using OpenWork.DataAccess.Interfaces.Common;
using OpenWork.Domain.Entities;

namespace OpenWork.DataAccess.Repositories.Common;

public class WorkerRepository : BasicRepository<Worker>, IWorkerRepository
{
	public WorkerRepository(AppDbContext context) : base(context)
	{
	}

	public async Task<Worker> GetAsync(string email)
	{
		Worker result = await _set.FirstOrDefaultAsync(x => x.Email == email);
		if(result is not null)
		{
			await _context.Entry(result).Collection(x => x.Comments).LoadAsync();
			await _context.Entry(result).Collection(x => x.Busynesses).LoadAsync();
		}
		return result;

	}
	public override async Task<Worker> GetAsync(long id)
	{
		Worker result = await _set.FindAsync(id);
		if(result is not null)
		{
			await _context.Entry(result).Collection(x => x.Comments).LoadAsync();
			await _context.Entry(result).Collection(x => x.Busynesses).LoadAsync();
		}
		return result;
	}
	public override IQueryable<Worker> GetAll()
	{
		return base.GetAll().Include(x => x.Comments).Include(x => x.Busynesses).AsNoTracking();
	}
}
