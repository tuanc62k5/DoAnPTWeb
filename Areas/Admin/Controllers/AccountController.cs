using DoAn.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly DataContext _context;
        public AccountController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var tkList = _context.TaiKhoans.OrderBy(tk => tk.TK_ID).ToList();
            return View(tkList);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var tk = _context.TaiKhoans.Find(id);
            if (tk == null)
                return NotFound();
            return View(tk);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var delAccount = _context.TaiKhoans.Find(id);
            if (delAccount == null)
                return NotFound();
            _context.TaiKhoans.Remove(delAccount);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(tblTaiKhoan tk)
        {
            if (ModelState.IsValid)
            {
                _context.TaiKhoans.Add(tk);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tk);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var tk = _context.TaiKhoans.Find(id);
            if (tk == null)
                return NotFound();

            return View(tk);
        }

        [HttpPost]
        public IActionResult Edit(tblTaiKhoan tk)
        {
            if (ModelState.IsValid)
            {
                _context.TaiKhoans.Update(tk);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tk);
        }

    }
}