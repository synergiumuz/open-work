using System.Threading.Tasks;

namespace OpenWork.Services.Interfaces;

public interface ISkillService
{
	public Task<bool> AddAsync(long skillId);
	public Task<bool> RemoveAsync(long skillId);
}
