using OpenWork.Domain.Entities;

namespace OpenWork.Services.Interfaces.Security
{
	public interface IAuthManager
	{
		public string GenerateToken(User user);
		public string GenerateToken(Worker worker);
	}
}
