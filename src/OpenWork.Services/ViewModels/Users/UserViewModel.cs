using OpenWork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWork.Services.ViewModels.Users
{
	public class UserViewModel
	{
		public string Email { get; set; } = string.Empty;

		public static implicit operator UserViewModel(User entity)
		{
			return new UserViewModel()
			{
				Email = entity.Email,
			};
		}
	}
				
}
