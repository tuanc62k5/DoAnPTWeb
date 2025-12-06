using Microsoft.AspNetCore.Mvc;
using DoAn.Models;
using Microsoft.AspNetCore.Http;

namespace DoAn.Controllers
{
    public class DangNhapController : Controller
    {
        private readonly DataContext _context;
        private readonly ILogger<DangNhapController> _logger;

        public DangNhapController(DataContext context, ILogger<DangNhapController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string tk_TenDangNhap, string tk_MatKhau)
        {
            if (string.IsNullOrEmpty(tk_TenDangNhap) || string.IsNullOrEmpty(tk_MatKhau))
            {
                ViewBag.ThongBao = "Vui lòng nhập tên đăng nhập và mật khẩu!";
                return View();
            }

            // Kiểm tra tài khoản trong database
            var taiKhoan = _context.TaiKhoans.FirstOrDefault(x =>
                x.TK_TenDangNhap == tk_TenDangNhap && 
                x.TK_MatKhau == tk_MatKhau);

            if (taiKhoan == null)
            {
                ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không chính xác!";
                return View();
            }

            // Lưu thông tin đăng nhập vào Session
            HttpContext.Session.SetInt32("TK_ID", taiKhoan.TK_ID);
            if (!string.IsNullOrEmpty(taiKhoan.TK_TenDangNhap))
            {
                HttpContext.Session.SetString("TK_TenDangNhap", taiKhoan.TK_TenDangNhap);
            }
            if (!string.IsNullOrEmpty(taiKhoan.TK_HoVaTen))
            {
                HttpContext.Session.SetString("TK_HoVaTen", taiKhoan.TK_HoVaTen);
            }
            HttpContext.Session.SetInt32("TK_QuyenHan", taiKhoan.TK_QuyenHan ?? 0);

            // Chuyển hướng theo quyền hạn
            if (taiKhoan.TK_QuyenHan == 0)
            {
                // Admin
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            else
            {
                // Sinh viên
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "DangNhap");
        }
    }
}
