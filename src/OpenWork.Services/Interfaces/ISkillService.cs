using System.Threading.Tasks;

using OpenWork.Services.Dtos.Admins;

namespace OpenWork.Services.Interfaces;

public interface ISkillService
{
	public Task<bool> AddAsync(long skillId);
	public Task<bool> RemoveAsync(long skillId);
	public Task<bool> CreateAsync(SkillCreateDto dto);
	public Task<bool> UpdateAsync(SkillCreateDto dto, long id);
	public Task<bool> DeleteAsync(long id);
}
