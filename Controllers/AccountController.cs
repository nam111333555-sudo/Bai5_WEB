using BookDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookDB.Controllers;

public class AccountController : Controller
{
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        TempData["AccountMessage"] = $"Đăng nhập thành công với {model.Email}";
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        TempData["AccountMessage"] = "Đăng ký thành công. Vui lòng đăng nhập để tiếp tục.";
        return RedirectToAction("Login");
    }
}
