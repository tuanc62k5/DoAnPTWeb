using DoAn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DoAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DichVuPhongController : Controller
    {
        private readonly DataContext _context;
        public DichVuPhongController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var dvpList = _context.DichVuPhongs.Include(dvp => dvp.Phong).Include(dvp => dvp.DichVu).OrderBy(dvp => dvp.DVP_ID).ToList();
            return View(dvpList);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var dvp = _context.DichVuPhongs.Include(x => x.Phong).Include(x => x.DichVu).FirstOrDefault(x => x.DVP_ID == id);

            if (dvp == null)
                return NotFound();
            return View(dvp);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deldvp = _context.DichVuPhongs.Find(id);
            if (deldvp == null)
                return NotFound();
            _context.DichVuPhongs.Remove(deldvp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            ViewBag.phongList = new SelectList(_context.Phongs, "P_ID", "P_TenPhong");
            ViewBag.dvList = new SelectList(_context.DichVus, "DV_ID", "DV_TenDichVu");
            return View();
        }

        [HttpPost]
        public IActionResult Create(tblDichVuPhong dvp)
        {
            if (ModelState.IsValid)
            {
                _context.DichVuPhongs.Add(dvp);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.phongList = new SelectList(_context.Phongs, "P_ID", "P_TenPhong", dvp.P_ID);
            ViewBag.dvList = new SelectList(_context.DichVus, "DV_ID", "DV_TenDichVu", dvp.DV_ID);
            return View(dvp);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var dvp = _context.DichVuPhongs.Find(id);
            if (dvp == null)
                return NotFound();

            ViewBag.phongList = new SelectList(_context.Phongs, "P_ID", "P_TenPhong", dvp.P_ID);
            ViewBag.dvList = new SelectList(_context.DichVus, "DV_ID", "DV_TenDichVu", dvp.DV_ID);

            return View(dvp);
        }

        [HttpPost]
        public IActionResult Edit(tblDichVuPhong dvp)
        {
            if (ModelState.IsValid)
            {
                _context.DichVuPhongs.Update(dvp);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.phongList = new SelectList(_context.Phongs, "P_ID", "P_TenPhong", dvp.P_ID);
            ViewBag.dvList = new SelectList(_context.DichVus, "DV_ID", "DV_TenDichVu", dvp.DV_ID);

            return View(dvp);
        }
    }
}
