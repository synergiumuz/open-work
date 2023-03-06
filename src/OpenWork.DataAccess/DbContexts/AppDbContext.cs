using Microsoft.EntityFrameworkCore;

using OpenWork.DataAccess.Configurations;
using OpenWork.Domain.Entities;

namespace OpenWork.DataAccess.DbContexts;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{

	}
	public virtual DbSet<Busyness> Busynesses { get; } = default!;
	public virtual DbSet<Category> Categories { get; } = default!;
	public virtual DbSet<Comment> Comments { get; } = default!;
	public virtual DbSet<Skill> Skills { get; } = default!;
	public virtual DbSet<User> Users { get; } = default!;
	public virtual DbSet<Worker> Workers { get; } = default!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfiguration(new SuperAdminConfiguration());
	}
}
