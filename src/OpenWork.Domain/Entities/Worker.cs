using System;
using System.Collections.Generic;

using OpenWork.Domain.Common;
namespace OpenWork.Domain.Entities
{
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

		public int Pros { get; set; }

		public int Cons { get; set; }

		public bool Banned{ get; set; }

		public virtual IList<Busyness> Businesses { get; set; } = new List<Busyness>(); 
		public virtual IList<Sphere> Spheres { get; set; } = new List<Sphere>(); 
		public virtual IList<Comment> Comments { get; set; } = new List<Comment>();
	}
}
