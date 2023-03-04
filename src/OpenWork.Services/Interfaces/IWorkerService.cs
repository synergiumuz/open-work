using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using OpenWork.Services.Dtos.Workers;
using OpenWork.Services.ViewModels.Users;
using OpenWork.Services.ViewModels.Workers;

namespace OpenWork.Services.Interfaces;

public interface IWorkerService
{
	public Task<string> LoginAsync(WorkerLoginDto dto);

	public Task<bool> RegisterAsync(WorkerRegisterDto dto);

	public Task<bool> UpdateAsync(WorkerRegisterDto dto);

	public Task<bool> DeleteAsync();

	public Task<WorkerBaseViewModel> GetBaseAsync(long id);

	public Task<WorkerViewModel> GetAsync(long id);

	public Task<IEnumerable<WorkerBaseViewModel>> SearchAsync(SearchDto dto, int page);

	public Task<IEnumerable<WorkerBaseViewModel>> GetAllAsync(int page);
}
