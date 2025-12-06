using Microsoft.AspNetCore.Mvc;

namespace DoAn.Areas.Admin.Controllers;

[Area("Admin")]
public class HomeController : Controller
{
    [ResponseCache(NoStore = true, Duration = 0)]
    public IActionResult Index()
    {
        // Check if user is logged in
        if (HttpContext.Session.GetInt32("TK_ID") == null)
        {
            return RedirectToAction("Index", "DangNhap", new { area = "" });
        }
        HttpContext.Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate, max-age=0";
        HttpContext.Response.Headers["Pragma"] = "no-cache";
        HttpContext.Response.Headers["Expires"] = "0";
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "DangNhap", new { area = "" });
    }
}