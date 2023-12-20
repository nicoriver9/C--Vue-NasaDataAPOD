using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using nasadataweb.Models;

namespace nasadataweb.Controllers;

[Route("api/nasa")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController>? _logger;

    // public HomeController(ILogger<HomeController> logger)
    // {
    //     _logger = logger;
    // }

    // public IActionResult Index()
    // {
    //     return View();
    // }

    public HomeController(NasaApodService nasaApodService)
    {
        _nasaApodService = nasaApodService;
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private readonly NasaApodService _nasaApodService;

    [HttpGet("GetApodList")]
     public async Task<IActionResult> Index()
    {
        int count = 5; // Número deseado de objetos
        var apodList = await _nasaApodService.GetApodListAsync(count);

        // Puedes pasar la lista a la vista o al modelo de vista
        // return View(apodList);
        return Json(apodList);
    }
}
