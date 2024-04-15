using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly Data _data;
    public HomeController(ILogger<HomeController> logger, Data data)
    {
        _logger = logger;
        _data = data;
    }

    public IActionResult Index()
    {
        var Data = _data.GetData();
        return View(Data);
    }

    [HttpPost]
    public IActionResult Index(string field, string value)
    {
        var Data = _data.SelectData(field, value);
        return Json(Data);
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
