using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenWork.DataAccess.Interfaces.Common;
using OpenWork.Services.Dtos.Workers;
using OpenWork.Services.Interfaces;

namespace OpenWork.Services.Services;

public class WorkerService : IWorkerService
{
	private readonly IWorkerRepository _repository;

	public WorkerService(IWorkerRepository repository)
	{
		_repository = repository;
	}

	public Task<bool> DeleteAsync()
	{
		throw new NotImplementedException();
	}

	public Task<string> LoginAsync(WorkerLoginDto dto)
	{
		var worker = _repository.GetAsync(dto.Email);
		if(worker is null)
		{
			
		}
		throw new NotImplementedException();
	}

	public Task<bool> RegisterAsync(WorkerRegisterDto dto)
	{
		throw new NotImplementedException();
	}

	public Task<bool> UpdateAsync(WorkerRegisterDto dto)
	{
		throw new NotImplementedException();
	}
}
