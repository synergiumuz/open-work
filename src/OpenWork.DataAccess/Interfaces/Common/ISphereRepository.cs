using System.Linq;

using OpenWork.Domain.Entities;

namespace OpenWork.DataAccess.Interfaces.Common;

public interface ISphereRepository : IBasicRepository<Sphere>
{
	public IQueryable<Sphere> GetByCategory(long categoryId);
}
