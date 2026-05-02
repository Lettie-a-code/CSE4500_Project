using Microsoft.AspNetCore.Mvc;

namespace CSE4500.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult DailyReport()
        {
            return View();
        }
    }
}