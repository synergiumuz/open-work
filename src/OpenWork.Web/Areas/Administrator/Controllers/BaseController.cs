using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace OpenWork.Web.Areas.Administrator.Controllers;
[Area("administrator")]
[Authorize(Roles = "Admin")]
public class BaseController : Controller
{
   
}
