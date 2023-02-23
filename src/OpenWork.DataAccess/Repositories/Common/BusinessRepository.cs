using OpenWork.DataAccess.DbContexts;
using OpenWork.DataAccess.Interfaces.Common;
using OpenWork.Domain.Entities;

namespace OpenWork.DataAccess.Repositories.Common;

public class BusinessRepository : BasicRepository<Busyness>, IBusinessRepository
{
	public BusinessRepository(AppDbContext context) : base(context)
	{
	}
}
