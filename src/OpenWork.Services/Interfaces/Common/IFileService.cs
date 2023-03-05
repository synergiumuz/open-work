using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace OpenWork.Services.Interfaces.Common
{
	public interface IFileService
	{
		public Task<string> SaveImageAsync(IFormFile image);
	}
}
