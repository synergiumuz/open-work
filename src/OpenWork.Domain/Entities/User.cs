using System.Collections.Generic;

using OpenWork.Domain.Common;

namespace OpenWork.Domain.Entities;

public class User : BaseEntity
{
	public string Name { get; set; } = string.Empty;

	public string Surname { get; set; } = string.Empty;

	public string Email { get; set; } = string.Empty;

	public bool EmailVerified { get; set; }

	public string Password { get; set; } = string.Empty;

	public bool Banned { get; set; }

	public bool Admin { get; set; }

	public virtual IList<Comment> Comments { get; set; } = new List<Comment>();
}
