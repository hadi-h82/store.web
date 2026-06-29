using Application.Services.Account;
using Domain.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace store.web.Controllers;

[AutoValidateAntiforgeryToken]

public class AccountController : Controller
{


    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }



    [HttpGet("Register")]
    public IActionResult Register()
    {

        return View();
    }


    [HttpPost("Register")]
    [ValidateAntiForgeryToken]
    public IActionResult Register(RegisterDTO register)
    {
        if (ModelState.IsValid)
        {
            if (_userService.IsEmailExsit(register.Email))
            {
                ModelState.AddModelError("Email", "ایمیل وارد شده تکراری است");
                return View(register);  
            }
            var res = _userService.CreateUser(register);
            if (res)
            {
                return Redirect("Login?registerUser=true");
            }
            return Redirect("Login");
        }
        return View(register);
    }




    [HttpGet("Login")]
    public IActionResult Login(bool registerUser = false)
    {
        ViewBag.register = registerUser;
        return View();
    }


    [HttpPost("Login")]
    [ValidateAntiForgeryToken]
    public IActionResult Login(LoginDTO login)
    {

        if (ModelState.IsValid)
        {
            var user = _userService.LoginUser(login);
            if (user != null)
            {

                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Email)
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var properties = new AuthenticationProperties
                {
                    IsPersistent = login.RememberMe
                };
                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity),
                    properties);
                return Redirect("/");

            }
            ModelState.AddModelError("Email", "کاربری یافت نشد!");
            return View(login);
        }
        ModelState.AddModelError("Email", "خطای نامشخص");
        return View(login);
    }

    [HttpGet("Logout")]
    public IActionResult Logout()
    {
        if(!User.Identity.IsAuthenticated) return Redirect("/");
        HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
        return Redirect("/");
    }

    [HttpGet("AccesDenied")]
    public IActionResult AccesDenied()
    {
        return View();
    }
}


