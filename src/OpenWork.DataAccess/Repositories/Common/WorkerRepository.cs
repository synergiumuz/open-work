using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using OpenWork.DataAccess.DbContexts;
using OpenWork.DataAccess.Interfaces.Common;
using OpenWork.Domain.Entities;

namespace OpenWork.DataAccess.Repositories.Common;

public class WorkerRepository : BasicRepository<Worker>, IWorkerRepository
{
	public WorkerRepository(AppDbContext context) : base(context)
	{
	}

	public async Task<Worker> GetAsync(string email)
	{
		Worker? entity = await _set.FirstOrDefaultAsync(x => x.Email == email);
		return entity is null ? throw new Exception("Worker not found") : entity;
	}
}
