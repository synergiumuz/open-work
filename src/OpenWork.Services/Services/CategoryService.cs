using OpenWork.DataAccess.Interfaces;
using OpenWork.Domain.Entities;
using OpenWork.Services.Common.Utils;
using OpenWork.Services.Dtos.Admins;
using OpenWork.Services.Interfaces;
using OpenWork.Services.Interfaces.Common;
using OpenWork.Services.ViewModels.Admins;
using OpenWork.Services.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

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
			return (await _paginator.PaginateAsync(_repository.Categories.GetAll(), new PaginationParams(_pageSize, page))).Select(
				x => new CategoryViewModel
				{
					Skills = x.Skills.ToList(),
				}
			);
		}

		public async Task<CategoryViewModel> GetAsync(long id)
		{
			Category category = await _repository.Categories.GetAsync(id);
			return new CategoryViewModel
			{
				Skills = category.Skills.ToList(),
			};
		}

		public async Task<bool> UpdateAsync(CategoryCreateDto dto)
		{
			Category category = dto;
			_ = _repository.Categories.Update(category);
			return await _repository.SaveChangesAsync() > 0;
		}
	}
}
