using System.Linq;

using OpenWork.DataAccess.DbContexts;
using OpenWork.DataAccess.Interfaces.Common;
using OpenWork.Domain.Entities;

namespace OpenWork.DataAccess.Repositories.Common;

public class SphereRepository : BasicRepository<Sphere>, ISphereRepository
{
	public SphereRepository(AppDbContext context) : base(context)
	{
	}

	public IQueryable<Sphere> GetByCategory(long categoryId)
	{
		return _set.Where(c => c.CategoryId == categoryId);
	}
}
