using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using OpenWork.DataAccess.DbContexts;
using OpenWork.DataAccess.Interfaces;
using OpenWork.Domain.Entities;
using OpenWork.Services.Interfaces;
using OpenWork.Services.Interfaces.Common;

namespace OpenWork.Services.Services;

public class AdminService : IAdminService
{
	private readonly IUnitOfWork _repository;
	private readonly AppDbContext _db;
	private readonly IIdentityService _identity;

	public AdminService(IUnitOfWork repository, IIdentityService identity, AppDbContext db)
	{
		_repository = repository;
		_identity = identity;
		_db = db;
	}

	public async Task<bool> BanAsync(string email)
	{
		User user = await _repository.Users.GetAsync(email);
		Worker worker = await _repository.Workers.GetAsync(email);
		if(user is null && worker is null)
			throw new Exception("Email not found");
		if(user is not null)
		{
			user.Banned = true;
			_repository.Users.Update(user);
		}
		if(worker is not null)
		{
			worker.Banned = true;
			_repository.Workers.Update(worker);
		}
		return await _repository.SaveChangesAsync() > 0;
	}

	public async Task<bool> MakeAdminAsync(long userId)
	{
		if(_identity.Id != 1)
			throw new Exception("Not super admin");
		User entity = await _repository.Users.GetAsync(userId);
		entity.Admin = true;
		_repository.Users.Update(entity);
		return await _repository.SaveChangesAsync() > 0;
	}

	public async Task<bool> ResetAsync()
	{
		if(_identity.Id != 1)
			throw new Exception("Not superadmin");
		return await _db.Database.ExecuteSqlRawAsync("truncate public.\"Busynesses\" cascade;\r\ntruncate public.\"Categories\" cascade;\r\ntruncate public.\"Comments\" cascade;\r\ntruncate public.\"SkillWorker\" cascade;\r\ntruncate public.\"Skills\" cascade;\r\ntruncate public.\"Users\" cascade;\r\ntruncate public.\"Workers\" cascade;\r\ninsert into public.\"Users\"(\"Id\", \"Name\", \"Surname\",\"Admin\", \"Banned\", \"Email\", \"EmailVerified\", \"Password\") values\r\n(1, 'Admin', 'Admin', true, false, 'khamidov357@gmail.com', true, 'nQlxzFWIQ6Lp49C2vm9B9VvJdMkI3460HMK+GTxeMwc=');\r\ninsert into public.\"Workers\"(\"Name\", \"Surname\", \"Banned\", \"Email\", \"LastSeen\", \"CreatedAt\", \"EmailVerified\", \"Id\", \"Image\", \"Password\", \"Phone\", \"PhoneVerified\") values\r\n('Admin', 'Admin', false, 'khamidov357@gmail.com', '1/1/0001', '1/1/0001', true, 1, '', 'nQlxzFWIQ6Lp49C2vm9B9VvJdMkI3460HMK+GTxeMwc=', '+998930090415', true);") > 0;
	}
}
