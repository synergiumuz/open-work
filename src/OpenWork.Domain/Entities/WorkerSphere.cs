using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWork.Domain.Entities
{
	public class WorkerSphere
	{
		public long WorkerId { get; set; }

		public virtual Worker Worker { get; set; }

		public long SphereId { get; set; }

		public virtual Sphere Sphere { get; set; }
	}
}
