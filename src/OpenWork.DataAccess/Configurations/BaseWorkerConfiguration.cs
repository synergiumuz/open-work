using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OpenWork.Domain.Entities;

namespace OpenWork.DataAccess.Configurations;

public class BaseWorkerConfiguration : IEntityTypeConfiguration<Worker>
{
	public void Configure(EntityTypeBuilder<Worker> builder)
	{
		builder.HasData(new Worker()
		{
			Name = "Admin",
			Surname = "Admin",
			Banned = false,
			Email = "khamidov357@gmail.com",
			Skills = new List<Skill>(),
			LastSeen = DateTime.MinValue,
			Busynesses = new List<Busyness>(),
			Comments = new List<Comment>(),
			CreatedAt = DateTime.MinValue,
			EmailVerified = true,
			Id = 1,
			Image = "",
			Password = "nQlxzFWIQ6Lp49C2vm9B9VvJdMkI3460HMK+GTxeMwc=",
			Phone = "+998930090415",
			PhoneVerified = true,
		});
	}
}
