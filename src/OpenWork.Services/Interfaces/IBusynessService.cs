using System.Collections.Generic;
using System.Threading.Tasks;

using OpenWork.Domain.Entities;
using OpenWork.Services.Dtos.Workers;

namespace OpenWork.Services.Interfaces;

public interface IBusynessService
{
	public Task<bool> CreateAsync(BusynessCreateDto dto);
	public Task<bool> DeleteAsync(long id);
	public Task<IEnumerable<Busyness>> GetAllAsync(int page);
	public Task<IEnumerable<Busyness>> SearchAsync(BusynessSearchDto dto, int page);
}
