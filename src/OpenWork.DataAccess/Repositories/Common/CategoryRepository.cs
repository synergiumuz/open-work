using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using OpenWork.DataAccess.DbContexts;
using OpenWork.DataAccess.Interfaces.Common;
using OpenWork.Domain.Entities;

namespace OpenWork.DataAccess.Repositories.Common;

public class CategoryRepository : BasicRepository<Category>, ICategoryRepository
{
	public CategoryRepository(AppDbContext context) : base(context)
	{
	}
	public override IQueryable<Category> GetAll()
	{
		return base.GetAll().Include(x => x.Skills).AsNoTracking();
	}
	public override async Task<Category> GetAsync(long id)
	{
		Category result = await base.GetAsync(id);
		if(result is not null)
			await _context.Entry(result).Collection(x => x.Skills).LoadAsync();
		return result;
	}
}
