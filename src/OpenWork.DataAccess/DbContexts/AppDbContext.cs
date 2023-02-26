using Microsoft.EntityFrameworkCore;

using OpenWork.Domain.Entities;

namespace OpenWork.DataAccess.DbContexts;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{

	}
	public virtual DbSet<Busyness> Businesses { get; } = default!;
	public virtual DbSet<Category> Categories { get; } = default!;
	public virtual DbSet<Comment> Comments { get; } = default!;
	public virtual DbSet<Skill> Spheres { get; } = default!;
	public virtual DbSet<User> Users { get; } = default!;
	public virtual DbSet<Worker> Workers { get; } = default!;
}
