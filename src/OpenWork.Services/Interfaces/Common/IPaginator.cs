using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using OpenWork.Services.Common.Pagination;

namespace OpenWork.Services.Interfaces.Common;

public interface IPaginator
{
	public Task<IEnumerable<T>> PaginateAsync<T>(IQueryable<T> obj, PaginationParams @params);
}
