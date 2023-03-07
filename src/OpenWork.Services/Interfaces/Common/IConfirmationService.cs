using OpenWork.Services.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWork.Services.Interfaces.Common
{
	public interface IConfirmationService
	{
		public Task<long> SendCode(string email);

		public Task<bool> ConfirmCode(EmailConfirmDto dto);

	}
}
