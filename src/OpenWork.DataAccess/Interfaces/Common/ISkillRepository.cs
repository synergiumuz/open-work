using System.Linq;

using OpenWork.Domain.Entities;

namespace OpenWork.DataAccess.Interfaces.Common;

public interface ISkillRepository : IBasicRepository<Skill>
{
	public IQueryable<Skill> GetByCategory(long categoryId);
}
