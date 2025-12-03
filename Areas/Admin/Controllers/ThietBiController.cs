using DoAn.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ThietBiController : Controller
    {
        private readonly DataContext _context;
        public ThietBiController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var tbList = _context.ThietBis.OrderBy(tb => tb.TB_ID).ToList();
            return View(tbList);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var tb = _context.ThietBis.Find(id);
            if (tb == null)
                return NotFound();
            return View(tb);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deltb = _context.ThietBis.Find(id);
            if (deltb == null)
                return NotFound();
            _context.ThietBis.Remove(deltb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(tblThietBi tb)
        {
            if (ModelState.IsValid)
            {
                _context.ThietBis.Add(tb);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var tb = _context.ThietBis.Find(id);
            if (tb == null)
                return NotFound();

            return View(tb);
        }

        [HttpPost]
        public IActionResult Edit(tblThietBi tb)
        {
            if (ModelState.IsValid)
            {
                _context.ThietBis.Update(tb);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb);
        }
    }
}