using System.Linq;

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
		return _set.Where(c => c.CategoryId == categoryId);
	}
}
