using System;
using System.Collections.Generic;

using OpenWork.Domain.Common;
namespace OpenWork.Domain.Entities;

public class Worker : Auditable
{
	public string Name { get; set; } = string.Empty;

	public string Surname { get; set; } = string.Empty;

	public string Email { get; set; } = string.Empty;

	public bool EmailVerified { get; set; }

	public string Phone { get; set; } = string.Empty;

	public bool PhoneVerified { get; set; }

	public string Password { get; set; } = string.Empty;

	public DateTime LastSeen { get; set; }

	public string Image { get; set; } = string.Empty;

	public bool Banned { get; set; }

	public virtual IList<Busyness> Busynesses { get; set; } = new List<Busyness>();
	public virtual IList<Skill> Skills { get; set; } = new List<Skill>();
	public virtual IList<Comment> Comments { get; set; } = new List<Comment>();
}
