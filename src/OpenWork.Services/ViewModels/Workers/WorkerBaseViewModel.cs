using System;

using OpenWork.Domain.Common;
using OpenWork.Domain.Entities;

namespace OpenWork.Services.ViewModels.Workers;

public class WorkerBaseViewModel : BaseEntity
{
	public string Name { get; set; } = string.Empty;

	public string Surname { get; set; } = string.Empty;

	public DateTime LastSeen { get; set; }

	public double? Rating { get; set; }

	public static implicit operator WorkerBaseViewModel(Worker entity)
	{
		return new WorkerBaseViewModel()
		{
			Id = entity.Id,
			Name = entity.Name,
			Surname = entity.Surname,
			LastSeen = entity.LastSeen,
		};
	}
}
