using System.Threading.Tasks;

using OpenWork.Services.Dtos.Common;

namespace OpenWork.Services.Interfaces.Common;

public interface IConfirmationService
{
	public Task<bool> SendCode(string email);

	public Task<bool> ConfirmCode(EmailConfirmDto dto);

}
