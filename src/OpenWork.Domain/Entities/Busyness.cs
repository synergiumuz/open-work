using System;

using OpenWork.Domain.Common;

namespace OpenWork.Domain.Entities;

public class Busyness : BaseEntity
{
	public long WorkerId { get; set; }

	public virtual Worker Worker { get; set; } = default!;

	public DateTime Start { get; set; }

	public DateTime End { get; set; }

}
