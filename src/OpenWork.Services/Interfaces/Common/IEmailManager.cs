using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWork.Services.Interfaces.Common
{
	public interface IEmailManager
	{
		public Task<bool> SendCode(string email, int code);
	}
}
