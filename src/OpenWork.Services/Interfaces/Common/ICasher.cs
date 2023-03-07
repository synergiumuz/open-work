using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWork.Services.Interfaces.Common
{
	public interface ICasher
	{
		public void Place(string key, int value, double seconds);
		public int? Get(string key);
	}
}
