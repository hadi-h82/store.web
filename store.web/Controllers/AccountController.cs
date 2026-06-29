using Application.Services.Account;
using Domain.Account;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet("Logout")]
    public IActionResult Logout()
    {
        return View();
    }

    [HttpGet("AccesDenied")]
    public IActionResult AccesDenied()
    {
        return View();
    }
}


