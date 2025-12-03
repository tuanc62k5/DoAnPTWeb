using DoAn.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DichVuController : Controller
    {
        private readonly DataContext _context;
        public DichVuController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var dvList = _context.DichVus.OrderBy(dv => dv.DV_ID).ToList();
            return View(dvList);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var dv = _context.DichVus.Find(id);
            if (dv == null)
                return NotFound();
            return View(dv);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deldv = _context.DichVus.Find(id);
            if (deldv == null)
                return NotFound();
            _context.DichVus.Remove(deldv);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(tblDichVu dv)
        {
            if (ModelState.IsValid)
            {
                _context.DichVus.Add(dv);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dv);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var dv = _context.DichVus.Find(id);
            if (dv == null)
                return NotFound();

            return View(dv);
        }

        [HttpPost]
        public IActionResult Edit(tblDichVu dv)
        {
            if (ModelState.IsValid)
            {
                _context.DichVus.Update(dv);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dv);
        }
    }
}