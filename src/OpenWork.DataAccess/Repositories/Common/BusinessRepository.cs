using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using OpenWork.DataAccess.DbContexts;
using OpenWork.DataAccess.Interfaces.Common;
using OpenWork.Domain.Entities;

namespace OpenWork.DataAccess.Repositories.Common;

public class BusinessRepository : BasicRepository<Busyness>, IBusinessRepository
{
	public BusinessRepository(AppDbContext context) : base(context)
	{
	}
	public override IQueryable<Busyness> GetAll()
	{
		return base.GetAll().Include(x => x.Worker).AsNoTracking();
	}
	public override async Task<Busyness> GetAsync(long id)
	{
		Busyness result = await base.GetAsync(id);
		if(result is not null)
			await _context.Entry(result).Reference(x => x.Worker).LoadAsync();
		return result;
	}
}
