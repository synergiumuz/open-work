using System.Collections.Generic;

using OpenWork.Domain.Common;

namespace OpenWork.Domain.Entities;

public class Skill : BaseEntity
{
	public string Name { get; set; } = string.Empty;

	public string Description { get; set; } = string.Empty;

	public long CategoryId { get; set; }

	public virtual Category Category { get; set; } = new Category();

	public virtual IList<Worker> Workers { get; set; } = new List<Worker>();
}
