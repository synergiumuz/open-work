using System.Collections.Generic;
using System.Linq;

using OpenWork.Domain.Common;
using OpenWork.Domain.Entities;

namespace OpenWork.Services.ViewModels.Admins;

public class CategoryViewModel : BaseEntity
{
	public List<Skill> Skills { get; set; } = new List<Skill>();

	public static implicit operator CategoryViewModel(Category entity)
	{
		return new CategoryViewModel()
		{
			Id = entity.Id,
			Skills = entity.Skills.ToList(),
		};
	}
}
