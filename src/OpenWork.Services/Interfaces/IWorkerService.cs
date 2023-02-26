using System.Threading.Tasks;

using OpenWork.Services.Dtos.Workers;

namespace OpenWork.Services.Interfaces;

public interface IWorkerService
{
	public Task<string> LoginAsync(WorkerLoginDto dto);

	public Task<bool> RegisterAsync(WorkerRegisterDto dto);

	public Task<bool> UpdateAsync(WorkerRegisterDto dto);

	public Task<bool> DeleteAsync();
}
