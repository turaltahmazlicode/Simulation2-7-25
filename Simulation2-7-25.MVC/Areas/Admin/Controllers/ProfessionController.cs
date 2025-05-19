using Microsoft.AspNetCore.Mvc;
using Simulation2_7_25.BL.Services.Concretes;

namespace Simulation2_7_25.MVC.Areas.Admin.Controllers;
public class ProfessionController : Controller
{
    public ProfessionController(ProfessionService professionService,DoctorService doctorService)
    {
        _professionService = professionService;
        _doctorService = doctorService;
    }

    private readonly ProfessionService _professionService;
    private readonly DoctorService _doctorService;

    public IActionResult Index()
    {
        return View();
    }
}
