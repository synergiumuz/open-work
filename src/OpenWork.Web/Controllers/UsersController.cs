using Microsoft.AspNetCore.Mvc;
using OpenWork.Services.Dtos;

namespace OpenWork.Web.Controllers
{
    [Route("users")]
    public class UsersController : Controller
    {
        [HttpGet("login")]
        public ViewResult Login()
        {
            return View("Login");
        }

        [HttpGet("register")]
        public ViewResult Register()
        {
            return View("Register");
        }
        [HttpGet("Email")]
        public ViewResult Email()
        {
            return View("EmailV");
        }
    }
}
