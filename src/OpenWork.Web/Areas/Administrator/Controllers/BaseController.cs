using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OpenWork.Web.Areas.Administrator.Controllers;
[Area("administrator")]
[Authorize(Roles = "Admin")]
public class BaseController : Controller
{

}
