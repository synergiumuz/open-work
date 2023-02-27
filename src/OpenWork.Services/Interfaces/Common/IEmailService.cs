using System.Threading.Tasks;

namespace OpenWork.Services.Interfaces.Common;

public interface IEmailService
{
	public Task<bool> SendCode(string email, int code);
}
