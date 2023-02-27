using OpenWork.Domain.Common;
using OpenWork.Domain.Entities;

namespace OpenWork.Services.ViewModels.Users;

public class UserBaseViewModel : BaseEntity
{
	public string Name { get; set; } = string.Empty;

	public string Surname { get; set; } = string.Empty;

	public bool Admin { get; set; }

	public static implicit operator UserBaseViewModel(User entity)
	{
		return new UserBaseViewModel()
		{
			Id = entity.Id,
			Name = entity.Name,
			Surname = entity.Surname,
			Admin = entity.Admin,
		};
	}
}
