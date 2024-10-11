using System.Data.Common;
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

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    public class Order
    {
        public int column { get; set; }
        public string dir { get; set; }
    }
    public class Search
    {
        public string value { get; set; }
        public bool regex { get; set; }
    }

    public class DataTableRequest
    {
        public int draw { get; set; }
        public List<Order> order { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public Search search { get; set; }
    }

    [HttpPost]
    [Route("Home/GetUsersData")]
    public JsonResult GetUsersData([FromBody] DataTableRequest request)
    {
        var column = request.order[0].column;
        var dir = request.order[0].dir;
        var search = request.search.value;
        var Data = _data.GetUsersData(column, dir, search);
        return Json(new { data = Data });
    }
    [HttpPost]
    [Route("Home/GetProductsData")]
    public JsonResult GetProductsData([FromBody] DataTableRequest request)
    {
        var column = request.order[0].column;
        var dir = request.order[0].dir;
        var search = request.search.value;
        var Data = _data.GetProductsData(column, dir, search);
        return Json(new { data = Data });
    }
    [HttpPost]
    [Route("Home/GetShopCarData")]
    public JsonResult GetShopCarData([FromBody] DataTableRequest request)
    {
        var column = request.order[0].column;
        var dir = request.order[0].dir;
        var search = request.search.value;
        var Data = _data.GetShopCarData(column, dir, search);
        return Json(new { data = Data });
    }
    [HttpPost]
    [Route("Home/GetJoin")]
    public JsonResult GetJoin([FromBody] DataTableRequest request)
    {
        var column = request.order[0].column;
        var dir = request.order[0].dir;
        var search = request.search.value;
        var Data = _data.GetJoin(column, dir, search);
        return Json(new { data = Data });
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
