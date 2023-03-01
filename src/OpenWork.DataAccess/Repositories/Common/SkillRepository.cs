using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using OpenWork.DataAccess.DbContexts;
using OpenWork.DataAccess.Interfaces.Common;
using OpenWork.Domain.Entities;

namespace OpenWork.DataAccess.Repositories.Common;

public class SkillRepository : BasicRepository<Skill>, ISkillRepository
{
	public SkillRepository(AppDbContext context) : base(context)
	{
	}

	public IQueryable<Skill> GetByCategory(long categoryId)
	{
		return _set.Where(c => c.CategoryId == categoryId).Include(x => x.Category).AsNoTracking();
	}
	public override IQueryable<Skill> GetAll()
	{
		return base.GetAll().Include(x => x.Category).AsNoTracking();
	}
	public override async Task<Skill> GetAsync(long id)
	{
		Skill result = await base.GetAsync(id);
		if(result is not null)
			await _context.Entry(result).Reference(x => x.Category).LoadAsync();
		return result;
	}
}
