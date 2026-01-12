using DoAn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DoAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HopDongController : Controller
    {
        private readonly DataContext _context;
        public HopDongController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var hdList = _context.HopDongs.Include(hd => hd.SinhVien).Include(hd => hd.Phong).OrderBy(hd => hd.HD_ID).ToList();
            return View(hdList);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var hd = _context.HopDongs.Include(x => x.SinhVien).Include(x => x.Phong).FirstOrDefault(x => x.HD_ID == id);

            if (hd == null)
                return NotFound();

            return View(hd);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var delhd = _context.HopDongs.Find(id);
            if (delhd == null)
                return NotFound();

            _context.HopDongs.Remove(delhd);
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
        public IActionResult Create(tblHopDong hd)
        {
            if (ModelState.IsValid)
            {
                _context.HopDongs.Add(hd);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.svList = new SelectList(_context.SinhViens, "SV_ID", "SV_HoTen", hd.SV_ID);
            ViewBag.phongList = new SelectList(_context.Phongs, "P_ID", "P_TenPhong", hd.P_ID);
            return View(hd);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var hd = _context.HopDongs.Find(id);
            if (hd == null)
                return NotFound();

            ViewBag.svList = new SelectList(_context.SinhViens, "SV_ID", "SV_HoTen", hd.SV_ID);
            ViewBag.phongList = new SelectList(_context.Phongs, "P_ID", "P_TenPhong", hd.P_ID);

            return View(hd);
        }

        [HttpPost]
        public IActionResult Edit(tblHopDong hd)
        {
            if (ModelState.IsValid)
            {
                _context.HopDongs.Update(hd);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.svList = new SelectList(_context.SinhViens, "SV_ID", "SV_HoTen", hd.SV_ID);
            ViewBag.phongList = new SelectList(_context.Phongs, "P_ID", "P_TenPhong", hd.P_ID);

            return View(hd);
        }
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var hd = _context.HopDongs.Include(x => x.SinhVien).Include(x => x.Phong).FirstOrDefault(x => x.HD_ID == id);

            if (hd == null)
                return NotFound();

            return View(hd);
        }
    }
}
