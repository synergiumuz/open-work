using Microsoft.AspNetCore.Mvc;

namespace OpenWork.Web.Areas.Administrator.Controllers;

public class HomeController : BaseController
{
	public IActionResult Index()
	{
		return View();
	}
}
