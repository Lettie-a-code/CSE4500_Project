using CSE4500.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

// Class is responsible for directing user to appropriate view based on credentials
public class AccountController : Controller
{
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginViewModel vm)
    {
        Console.WriteLine($"Email: {vm.Email}, Password: {vm.Password}");

        if (!ModelState.IsValid)
        {
            Console.WriteLine("ModelState is INVALID");
            return View(vm);
        }

        string? role = null;

        if (vm.Email == "admin@dogcare.com" && vm.Password == "Admin123")
        {
            role = "Admin";
        }
        else if (vm.Email == "tech@dogcare.com" && vm.Password == "Tech123")
        {
            role = "Technician";
        }

        if (role != null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, vm.Email),
                new Claim(ClaimTypes.Role, role)
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            if (role == "Admin")
                return RedirectToAction("Admin", "Dashboard");

            if (role == "Technician")
                return RedirectToAction("Employee", "Dashboard");
        }

        ModelState.AddModelError("", "Invalid email or password.");
        return View(vm);
    }
}