using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace OpenWork.Services.Interfaces.Common
{
	public interface IFileService
	{
		public Task<string> SaveImageAsync(IFormFile image);
	}
}
