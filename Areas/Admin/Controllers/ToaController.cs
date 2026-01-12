using DoAn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DoAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ToaController : Controller
    {
        private readonly DataContext _context;
        public ToaController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var toaList = _context.Toas.Include(t => t.CoSo).OrderBy(t => t.T_ID).ToList();

            var SoPhong = _context.Phongs.Where(p => p.T_ID != null).GroupBy(p => p.T_ID!.Value).ToDictionary(g => g.Key, g => g.Count());

            ViewBag.SoPhong = SoPhong;

            return View(toaList);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var t = _context.Toas.Find(id);
            if (t == null)
                return NotFound();
            return View(t);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var delToa = _context.Toas.Find(id);
            if (delToa == null)
                return NotFound();
            _context.Toas.Remove(delToa);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            ViewBag.csList = new SelectList(_context.CoSos, "CS_ID", "CS_TenCoSo");
            return View();

        }
        [HttpPost]
        public IActionResult Create(tblToa t)
        {
            if (ModelState.IsValid)
            {
                t.T_NgayTao = DateTime.Now;
                _context.Toas.Add(t);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.csList = new SelectList(_context.CoSos, "CS_ID", "CS_TenCoSo", t.CS_ID);
            return View(t);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var t = _context.Toas.Find(id);
            if (t == null)
                return NotFound();

            var csList = _context.CoSos.Select(cs => new SelectListItem
            {
                Text = cs.CS_TenCoSo,
                Value = cs.CS_ID.ToString()
            }).ToList();

            csList.Insert(0, new SelectListItem
            {
                Text = "-- Chọn cơ sở --",
                Value = ""
            });
            ViewBag.csList = csList;

            return View(t);
        }

        [HttpPost]
        public IActionResult Edit(tblToa t)
        {
            if (ModelState.IsValid)
            {
                _context.Toas.Update(t);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            var toaList = _context.CoSos.Select(cs => new SelectListItem
            {
                Text = cs.CS_TenCoSo,
                Value = cs.CS_ID.ToString()
            }).ToList();

            toaList.Insert(0, new SelectListItem
            {
                Text = "-- Chọn cơ sở --",
                Value = ""
            });

            ViewBag.toaList = toaList;

            return View(t);
        }
    }
}