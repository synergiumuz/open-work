using System.Threading.Tasks;

using OpenWork.Services.Dtos.Common;

namespace OpenWork.Services.Interfaces.Common;

public interface IConfirmationService
{
	public Task<bool> SendAsync(string email);

	public Task<bool> ConfirmAsync(EmailConfirmDto dto);
}
