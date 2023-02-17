using OpenWork.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWork.Domain.Entities
{
	public class Sphere : BaseEntity
	{
		public string Name { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;

		public long CategoryId { get; set; }

		public virtual Category Category { get; set; }
	}
}
