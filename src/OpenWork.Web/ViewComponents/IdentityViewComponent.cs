using Microsoft.AspNetCore.Mvc;
using OpenWork.Services.Interfaces.Common;
using OpenWork.Services.ViewModels.Users;

namespace OpenWork.Web.ViewComponents
{
	public class IdentityViewComponent : ViewComponent
	{
		private readonly IIdentityService _identityService;

		public IdentityViewComponent(IIdentityService identityService)
		{
			this._identityService = identityService;
		}
		public IViewComponentResult Invoke()
		{
			UserViewModel model = new UserViewModel()
			{
				Id = _identityService.Id,
				Email = _identityService.Email
			};
			return View(model);
		}
	}
}
