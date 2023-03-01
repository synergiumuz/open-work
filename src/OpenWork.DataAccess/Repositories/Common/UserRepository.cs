using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using OpenWork.DataAccess.DbContexts;
using OpenWork.DataAccess.Interfaces.Common;
using OpenWork.Domain.Entities;

namespace OpenWork.DataAccess.Repositories.Common;

public class UserRepository : BasicRepository<User>, IUserRepository
{
	public UserRepository(AppDbContext context) : base(context)
	{

	}

	public async Task<User> GetAsync(string email)
	{
		User result = await _set.FirstOrDefaultAsync(x => x.Email == email);
		if(result is not null)
		{
			await _context.Entry(result).Collection(x => x.Comments).LoadAsync();
		}
		return result;
	}
	public override IQueryable<User> GetAll()
	{
		return base.GetAll().Include(x => x.Comments).AsNoTracking();
	}
	public override async Task<User> GetAsync(long id)
	{
		User result = await base.GetAsync(id);
		if(result is not null)
		{
			await _context.Entry(result).Collection(x => x.Comments).LoadAsync();
		}
		return result;
	}
}
