using Microsoft.EntityFrameworkCore;

using OpenWork.Domain.Entities;

namespace OpenWork.DataAccess.DbContexts;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{

	}
	public virtual DbSet<Business> Businesses { get; set; } = default!;
	public virtual DbSet<Category> Categories { get; set; } = default!;
	public virtual DbSet<Comment> Comments { get; set; } = default!;
	public virtual DbSet<Sphere> Spheres { get; set; } = default!;
	public virtual DbSet<User> Users { get; set; } = default!;
	public virtual DbSet<Worker> Workers { get; set; } = default!;
}
