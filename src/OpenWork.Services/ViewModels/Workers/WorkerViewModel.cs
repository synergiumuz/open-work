using OpenWork.Domain.Entities;

namespace OpenWork.Services.ViewModels.Workers;

public class WorkerViewModel : WorkerBaseViewModel
{
	public string Email { get; set; } = string.Empty;

	public string Phone { get; set; } = string.Empty;

	//may be List
	public string Spheres { get; set; } = string.Empty;

	//may be List
	public string Comments { get; set; } = string.Empty;

	public static implicit operator WorkerViewModel(Worker entity)
	{
		return new WorkerViewModel()
		{
			Id = entity.Id,
			Name = entity.Name,
			Email = entity.Email,
			Phone = entity.Phone,
			Surname = entity.Surname,
		};
	}
}
