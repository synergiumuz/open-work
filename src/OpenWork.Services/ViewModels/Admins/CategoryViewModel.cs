using OpenWork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWork.Services.ViewModels.Admins
{
	public class CategoryViewModel
	{
		public List<Sphere> Spheres { get; set; } = new List<Sphere>();

		public static implicit operator CategoryViewModel(Category entity)
		{
			return new CategoryViewModel()
			{
				Spheres =entity.Spheres.ToList(),
			};
		}
	}
}
