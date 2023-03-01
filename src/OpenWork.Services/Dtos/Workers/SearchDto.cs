using System.Collections.Generic;

using OpenWork.Domain.Entities;
namespace OpenWork.Services.Dtos.Workers;

public class SearchDto
{
	public IEnumerable<Skill> AllowedSkills { get; set; } = new List<Skill>();

	public SortOptions SortOptions { get; set; }
}

public enum SortOptions
{
	None = 0,
	AscendingOnline = 1,
	DescendingOnline = 2,
	AscendingRating = 3,
	DescendingRating = 4,
	AscendingExperience = 5,
	DescendingExperience = 6,
}