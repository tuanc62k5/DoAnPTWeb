using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DoAn.Models;

namespace DoAn.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [ResponseCache(NoStore = true, Duration = 0)]
    public IActionResult Index()
    {
        // Check if user is logged in
        if (HttpContext.Session.GetInt32("TK_ID") == null)
        {
            return RedirectToAction("Index", "DangNhap");
        }
        HttpContext.Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate, max-age=0";
        HttpContext.Response.Headers["Pragma"] = "no-cache";
        HttpContext.Response.Headers["Expires"] = "0";
        return View();
    }

    [ResponseCache(NoStore = true, Duration = 0)]
    public IActionResult Privacy()
    {
        // Check if user is logged in
        if (HttpContext.Session.GetInt32("TK_ID") == null)
        {
            return RedirectToAction("Index", "DangNhap");
        }
        HttpContext.Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate, max-age=0";
        HttpContext.Response.Headers["Pragma"] = "no-cache";
        HttpContext.Response.Headers["Expires"] = "0";
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
