using System;

namespace OpenWork.Domain.Common;

public class Auditable : BaseEntity
{
	public DateTime CreatedAt { get; set; }
}
