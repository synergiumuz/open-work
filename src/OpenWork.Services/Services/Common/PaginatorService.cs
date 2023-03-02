using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OpenWork.Services.Common.Utils;
using OpenWork.Services.Interfaces.Common;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWork.Services.Services.Common;

public class PaginatorService : IPaginatorService
{
	private readonly IHttpContextAccessor _accessor;

	public PaginatorService(IHttpContextAccessor httpContextAccessor)
	{
		_accessor = httpContextAccessor;
	}

	public async Task<IEnumerable<T>> PaginateAsync<T>(IQueryable<T> obj, PaginationParams @params)
	{
		int totalitems = await obj.CountAsync();


		PaginationMetaData paginationMetaData = new PaginationMetaData()
		{
			CurrentPage = @params.Number,
			PageSize = @params.Size,
			TotalItems = totalitems,
			TotalPages = (int)Math.Ceiling(totalitems / (double)@params.Size),
			HasPrevious = @params.Number > 0,
		};
		paginationMetaData.HasNext = paginationMetaData.CurrentPage < paginationMetaData.TotalPages;



		string json = JsonConvert.SerializeObject(paginationMetaData);

		_accessor.HttpContext.Response.Headers.Add("X-Pagination", json);

		return await obj.Skip(@params.Number * @params.Size - @params.Size)
						  .Take(@params.Size)
						  .ToListAsync();

	}

}
