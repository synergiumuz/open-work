using System.Threading.Tasks;

using OpenWork.DataAccess.Interfaces;
using OpenWork.Domain.Entities;
using OpenWork.Services.Dtos.Admins;
using OpenWork.Services.Interfaces;
using OpenWork.Services.Interfaces.Common;

namespace OpenWork.Services.Services;

public class SkillService : ISkillService
{
	private readonly IUnitOfWork _repository;
	private readonly IIdentityService _identity;

	public SkillService(IUnitOfWork repository, IIdentityService identity)
	{
		_repository = repository;
		_identity = identity;
	}

	public async Task<bool> AddAsync(long skillId)
	{
		Worker entity = await _repository.Workers.GetAsync(_identity.Id);
		entity.Skills.Add(await _repository.Skills.GetAsync(skillId));
		return await _repository.SaveChangesAsync() > 0;
	}

	public async Task<bool> CreateAsync(SkillCreateDto dto)
	{
		Skill entity = new()
		{
			CategoryId = dto.CategoryId,
			Description = dto.Description,
			Name = dto.Name,
		};
		_repository.Skills.Add(entity);
		return await _repository.SaveChangesAsync() > 0;
	}

	public async Task<bool> DeleteAsync(long id)
	{
		await _repository.Skills.DeleteAsync(id);
		return await _repository.SaveChangesAsync() > 0;
	}

	public async Task<bool> RemoveAsync(long skillId)
	{
		Worker entity = await _repository.Workers.GetAsync(_identity.Id);
		_ = entity.Skills.Remove(await _repository.Skills.GetAsync(skillId));
		return await _repository.SaveChangesAsync() > 0;
	}

	public async Task<bool> UpdateAsync(SkillCreateDto dto, long id)
	{
		Skill entity = await _repository.Skills.GetAsync(id);
		entity.Name = dto.Name;
		entity.Description = dto.Description;
		entity.CategoryId = dto.CategoryId;
		_repository.Skills.Update(entity);
		return await _repository.SaveChangesAsync() > 0;
	}
}
