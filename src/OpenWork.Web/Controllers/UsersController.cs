using Microsoft.AspNetCore.Mvc;

using OpenWork.Services.Common.Exceptions;
using OpenWork.Services.Dtos.Users;
using OpenWork.Services.Interfaces;

namespace OpenWork.Web.Controllers
{
	[Route("users")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("login")]
        public ViewResult Login()
        {
            return View("Login");
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(UserLoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string token = await _userService.LoginAsync(loginDto);
                    HttpContext.Response.Cookies.Append("X-Access-Token", token, new CookieOptions()
                    {
                        HttpOnly = true,
                        SameSite = SameSiteMode.Strict
                    });
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                catch (ModelErrorException modelError)
                {
                    ModelState.AddModelError(modelError.Property, modelError.Message);
                    return Login();
                }
                catch
                {
                    return Login();
                }
            }
            else return Login();
        }

        [HttpGet("register")]
        public ViewResult Register()
        {
            return View("Register");

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            if (ModelState.IsValid)
            {
                bool result = await _userService.RegisterAsync(userRegisterDto);
                if (result)
                {
                    return RedirectToAction("login", "users", new { area = "" });
                }
                else
                {
                    return Register();
                }
            }
            else return Register();
        }

        [HttpGet("Email")]
        public ViewResult Email()
        {
            return View("EmailV");
        }
    }
}
