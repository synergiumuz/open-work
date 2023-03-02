using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using OpenWork.Services.Common.Utils;

namespace OpenWork.Services.Interfaces.Common;

public interface IPaginatorService
{
	public Task<IEnumerable<T>> PaginateAsync<T>(IQueryable<T> obj, PaginationParams @params);
}
