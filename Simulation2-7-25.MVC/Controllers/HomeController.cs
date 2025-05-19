using Microsoft.AspNetCore.Mvc;

namespace Simulation2_7_25.MVC.Controllers;
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
