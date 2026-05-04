using CSE4500.Models;
using Microsoft.AspNetCore.Mvc;

public class DogController : Controller
{
    public IActionResult CheckIn()
    {
        return View();
    }
    public IActionResult DogList()
    {
        return View();
    }
    public IActionResult EnrollmentCensus()
    {
        return View();
    }
    public IActionResult Register()
    {
        return View();
    }
    public IActionResult CheckOut()

    {
        return View();
    }
    private readonly ApplicationDbContext _context;

    public DogController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult TestConnection()
    {
        var dogs = _context.DogRegistrations.ToList();
        return View(dogs);
    }
}
