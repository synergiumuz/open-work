using System.Collections.Generic;

using OpenWork.Domain.Common;

namespace OpenWork.Domain.Entities;

public class Category : BaseEntity
{
	public string Name { get; set; } = string.Empty;
	public virtual IList<Skill> Skills { get; set; } = new List<Skill>();
}
