using Microsoft.AspNetCore.Mvc;

namespace OpenWork.Web.Controllers
{
    [Route("accounts")]
    public class AccountsController : Controller
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
