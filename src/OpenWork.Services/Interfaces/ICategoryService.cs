using OpenWork.Services.Dtos.Admins;
using OpenWork.Services.ViewModels.Admins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWork.Services.Interfaces
{
	public interface ICategoryService
	{
		public Task<bool> UpdateAsync(long id, CategoryCreateDto dto);

		public Task<bool> DeleteAsync(long id);

		public Task<bool> CreateAsync(CategoryCreateDto dto);

		public Task<CategoryViewModel> GetAsync(long id);

		public Task<IEnumerable<CategoryViewModel>> GetAllAsync(int page);
	}
}
