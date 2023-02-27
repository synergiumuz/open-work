using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWork.Services.Interfaces.Common;

public interface IIdentityService
{
	public long Id { get; }
	public string Email { get; }

}