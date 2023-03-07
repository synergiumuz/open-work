using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OpenWork.Domain.Entities;

namespace OpenWork.DataAccess.Configurations;

public class SuperAdminConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.HasData(new User()
		{
			Id = 1,
			Name = "Admin",
			Surname = "Admin",
			Admin = true,
			Banned = false,
			Email = "khamidov357@gmail.com",
			EmailVerified = true,
			Password = "nQlxzFWIQ6Lp49C2vm9B9VvJdMkI3460HMK+GTxeMwc=",
		});
	}
}
