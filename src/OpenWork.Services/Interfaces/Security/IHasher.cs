using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWork.Services.Interfaces
{
	public interface IHasher
	{
		public string Hash(string password, string salt);
		public bool Verify(string hash, string password, string salt);

	}
}
