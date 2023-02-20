using OpenWork.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWork.Domain.Entities
{
	public class Business : BaseEntity
	{
		public long WorkerId { get; set; }

		public virtual Worker Worker { get; set; } = default!;

		public DateTime Start { get; set; }

		public DateTime End { get; set; }

	}
}
