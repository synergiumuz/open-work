using OpenWork.Domain.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OpenWork.Domain.Entities
{
	public class User : BaseEntity
	{
		public string Name { get; set; } = string.Empty;

		public string Surname { get; set; } = string.Empty;

		public string Email { get; set; } = string.Empty;

		public bool EmailVerified { get; set; }

		public string Password { get; set; } = string.Empty;

		public virtual IList<Comment> Comments { get; set; }
	}
}
