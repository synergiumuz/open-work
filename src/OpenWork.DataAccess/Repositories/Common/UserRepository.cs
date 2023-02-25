using System;
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
		var entity = await _set.FirstOrDefaultAsync(x => x.Email == email);
		return entity is null ? throw new Exception("User not found") : entity;
	}
}
