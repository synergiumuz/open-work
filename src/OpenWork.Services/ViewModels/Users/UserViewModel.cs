using OpenWork.Domain.Common;
using OpenWork.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWork.Services.ViewModels.Users
{
	public class UserViewModel : BaseEntity
	{
		public string Email { get; set; } = string.Empty;

		public static implicit operator UserViewModel(User entity)
		{
			return new UserViewModel()
			{
				Id = entity.Id,
				Email = entity.Email,
			};
		}
	}

}
