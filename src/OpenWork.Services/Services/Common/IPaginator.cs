using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using OpenWork.Services.Common.Pagination;
using OpenWork.Services.Interfaces.Common;

namespace OpenWork.Services.Services.Common;

public class Paginator : IPaginator
{
	public Task<IEnumerable<T>> PaginateAsync<T>(IQueryable<T> obj, PaginationParams @params)
	{
		throw new System.NotImplementedException();
	}
}
