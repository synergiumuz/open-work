using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using OpenWork.DataAccess.Interfaces;
using OpenWork.Domain.Entities;
using OpenWork.Services.Common.Utils;
using OpenWork.Services.Dtos.Admins;
using OpenWork.Services.Interfaces;
using OpenWork.Services.Interfaces.Common;
using OpenWork.Services.ViewModels.Admins;

namespace OpenWork.Services.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly IUnitOfWork _repository;
		private readonly IPaginatorService _paginator;
		private int _pageSize = 20;

		public CategoryService(IUnitOfWork repository, IPaginatorService paginator)
		{
			_repository = repository;
			_paginator = paginator;
		}

		public async Task<bool> CreateAsync(CategoryCreateDto dto)
		{
			Category category = new Category
			{
				Name = dto.Name
			};
			_repository.Categories.Add(category);
			return await _repository.SaveChangesAsync() > 0;
		}

		public async Task<bool> DeleteAsync(long id)
		{
			_ = await _repository.Categories.DeleteAsync(id);
			return await _repository.SaveChangesAsync() > 0;
		}

		public async Task<IEnumerable<CategoryViewModel>> GetAllAsync(int page)
		{
			return (await _paginator.PaginateAsync(_repository.Categories.GetAll(), new PaginationParams(_pageSize, page))).Select(x => (CategoryViewModel)x);
		}

		public async Task<CategoryViewModel> GetAsync(long id)
		{
			Category category = await _repository.Categories.GetAsync(id);
			return category;
		}

		public async Task<bool> UpdateAsync(long id, CategoryCreateDto dto)
		{
			Category entity = await _repository.Categories.GetAsync(id);
			entity.Name = dto.Name;
			_repository.Categories.Update(entity);
			return await _repository.SaveChangesAsync() > 0;
		}
	}
}
