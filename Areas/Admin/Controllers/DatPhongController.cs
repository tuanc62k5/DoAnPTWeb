using DoAn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DoAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DatPhongController : Controller
    {
        private readonly DataContext _context;
        public DatPhongController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var dpList = _context.DatPhongs.Include(dp => dp.SinhVien).Include(dp => dp.Phong).OrderBy(dp => dp.DP_ID).ToList();
            return View(dpList);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var dp = _context.DatPhongs.Include(x => x.SinhVien).Include(x => x.Phong).FirstOrDefault(x => x.DP_ID == id);

            if (dp == null)
                return NotFound();

            return View(dp);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deldp = _context.DatPhongs.Find(id);
            if (deldp == null)
                return NotFound();

            _context.DatPhongs.Remove(deldp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            ViewBag.svList = new SelectList(_context.SinhViens, "SV_ID", "SV_HoTen");
            ViewBag.phongList = new SelectList(_context.Phongs, "P_ID", "P_TenPhong");
            return View();
        }

        [HttpPost]
        public IActionResult Create(tblDatPhong dp)
        {
            if (ModelState.IsValid)
            {
                _context.DatPhongs.Add(dp);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.svList = new SelectList(_context.SinhViens, "SV_ID", "SV_HoTen", dp.SV_ID);
            ViewBag.phongList = new SelectList(_context.Phongs, "P_ID", "P_TenPhong", dp.P_ID);
            return View(dp);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var dp = _context.DatPhongs.Find(id);
            if (dp == null)
                return NotFound();

            ViewBag.svList = new SelectList(_context.SinhViens, "SV_ID", "SV_HoTen", dp.SV_ID);
            ViewBag.phongList = new SelectList(_context.Phongs, "P_ID", "P_TenPhong", dp.P_ID);

            return View(dp);
        }

        [HttpPost]
        public IActionResult Edit(tblDatPhong dp)
        {
            if (ModelState.IsValid)
            {
                _context.DatPhongs.Update(dp);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.svList = new SelectList(_context.SinhViens, "SV_ID", "SV_HoTen", dp.SV_ID);
            ViewBag.phongList = new SelectList(_context.Phongs, "P_ID", "P_TenPhong", dp.P_ID);

            return View(dp);
        }
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var dp = _context.DatPhongs.Include(x => x.SinhVien).Include(x => x.Phong).FirstOrDefault(x => x.DP_ID == id);

            if (dp == null)
                return NotFound();

            return View(dp);
        }
    }
}
