using OpenWork.DataAccess.DbContexts;
using OpenWork.DataAccess.Interfaces.Common;
using OpenWork.Domain.Entities;

namespace OpenWork.DataAccess.Repositories.Common;

public class CategoryRepository : BasicRepository<Category>, ICategoryRepository
{
	public CategoryRepository(AppDbContext context) : base(context)
	{
	}
}
