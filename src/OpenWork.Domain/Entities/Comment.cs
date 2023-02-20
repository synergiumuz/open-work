using OpenWork.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWork.Domain.Entities
{
	public class Comment : Auditable
	{
		public long UserId { get; set; }

		public virtual User User { get; set; } = default!;

		public long WorkerId { get; set; }

		public virtual Worker Worker { get; set; } = default!;

		public string Content { get; set; } = String.Empty;

		public bool Satisfied { get; set; }
	}
}
