using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace CSE4500.Controllers
{
    public class DashboardController: Controller
    {
    [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return View();
        }

        [Authorize(Roles = "Technician")]
        public IActionResult Employee()
        {
            return View();
        }
        //Redirect to home page once permission has beeen granted
        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
                return RedirectToAction("Admin");

            if (User.IsInRole("Technician"))
                return RedirectToAction("Employee");

            return RedirectToAction("AccessDenied");
        }
    }

}



