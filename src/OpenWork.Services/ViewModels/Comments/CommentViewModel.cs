using System;
using System.Linq;

using OpenWork.Domain.Common;
using OpenWork.Domain.Entities;
using OpenWork.Services.ViewModels.Users;
using OpenWork.Services.ViewModels.Workers;

namespace OpenWork.Services.ViewModels.Comments;

public class CommentViewModel : BaseEntity
{
	public string Content { get; set; } = string.Empty;

	public UserBaseViewModel User { get; set; }

	public WorkerBaseViewModel Worker { get; set; }

	public DateTime Created { get; set; }

	public bool Satisfied { get; set; }

	public static implicit operator CommentViewModel(Comment entity)
	{
		var vm = new CommentViewModel
		{
			Content = entity.Content,
			Satisfied = entity.Satisfied,
			Created = entity.CreatedAt,
			Id = entity.Id,
			User = entity.User,
			Worker = entity.Worker,
		};
		vm.Worker.Rating = entity.Worker.Comments.Average(x => x.Satisfied ? 1 : 0) * 5;
		return vm;
	}
}
