using OpenWork.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	}
}
