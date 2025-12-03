using DoAn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DoAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ThietBiPhongController : Controller
    {
        private readonly DataContext _context;
        public ThietBiPhongController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tbpList = _context.ThietBiPhongs.Include(t => t.Phong).Include(t => t.ThietBi).OrderBy(t => t.TBP_ID).ToList();
            return View(tbpList);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var tbp = _context.ThietBiPhongs.Include(x => x.Phong).Include(x => x.ThietBi).FirstOrDefault(x => x.TBP_ID == id);

            if (tbp == null)
                return NotFound();

            return View(tbp);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var delTbp = _context.ThietBiPhongs.Find(id);
            if (delTbp == null)
                return NotFound();

            _context.ThietBiPhongs.Remove(delTbp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            ViewBag.phongList = new SelectList(_context.Phongs, "P_ID", "P_TenPhong");
            ViewBag.tbList = new SelectList(_context.ThietBis, "TB_ID", "TB_TenThietBi");
            return View();
        }

        [HttpPost]
        public IActionResult Create(tblThietBiPhong tbp)
        {
            if (ModelState.IsValid)
            {
                _context.ThietBiPhongs.Add(tbp);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.phongList = new SelectList(_context.Phongs, "P_ID", "P_TenPhong", tbp.P_ID);
            ViewBag.tbList = new SelectList(_context.ThietBis, "TB_ID", "TB_TenThietBi", tbp.TB_ID);
            return View(tbp);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var tbp = _context.ThietBiPhongs.Find(id);
            if (tbp == null)
                return NotFound();

            ViewBag.phongList = new SelectList(_context.Phongs, "P_ID", "P_TenPhong", tbp.P_ID);
            ViewBag.tbList = new SelectList(_context.ThietBis, "TB_ID", "TB_TenThietBi", tbp.TB_ID);

            return View(tbp);
        }

        [HttpPost]
        public IActionResult Edit(tblThietBiPhong tbp)
        {
            if (ModelState.IsValid)
            {
                _context.ThietBiPhongs.Update(tbp);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.phongList = new SelectList(_context.Phongs, "P_ID", "P_TenPhong", tbp.P_ID);
            ViewBag.tbList = new SelectList(_context.ThietBis, "TB_ID", "TB_TenThietBi", tbp.TB_ID);

            return View(tbp);
        }
    }
}
