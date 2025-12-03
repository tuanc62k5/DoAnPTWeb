using DoAn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DoAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BaoTriThietBiController : Controller
    {
        private readonly DataContext _context;
        public BaoTriThietBiController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var bttbList = _context.BaoTriThietBis.Include(x => x.ThietBi).OrderBy(x => x.BTTB_ID).ToList();
            return View(bttbList);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var bttb = _context.BaoTriThietBis.Include(x => x.ThietBi).FirstOrDefault(x => x.BTTB_ID == id);

            if (bttb == null)
                return NotFound();
            return View(bttb);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var delbttb = _context.BaoTriThietBis.Find(id);
            if (delbttb == null)
                return NotFound();
            _context.BaoTriThietBis.Remove(delbttb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            ViewBag.tbList = new SelectList(_context.ThietBis, "TB_ID", "TB_TenThietBi");
            return View();
        }

        [HttpPost]
        public IActionResult Create(tblBaoTriThietBi bttb)
        {
            if (ModelState.IsValid)
            {
                _context.BaoTriThietBis.Add(bttb);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tbList = new SelectList(_context.ThietBis, "TB_ID", "TB_TenThietBi", bttb.TB_ID);
            return View(bttb);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var bttb = _context.BaoTriThietBis.Find(id);
            if (bttb == null)
                return NotFound();

            var tbList = _context.ThietBis.Select(tb => new SelectListItem
            {
                Text = tb.TB_TenThietBi,
                Value = tb.TB_ID.ToString()
            }).ToList();

            tbList.Insert(0, new SelectListItem
            {
                Text = "-- Chọn thiết bị --",
                Value = ""
            });
            ViewBag.tbList = tbList;

            return View(bttb);
        }

        [HttpPost]
        public IActionResult Edit(tblBaoTriThietBi bttb)
        {
            if (ModelState.IsValid)
            {
                _context.BaoTriThietBis.Update(bttb);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            var tbList = _context.ThietBis.Select(tb => new SelectListItem
            {
                Text = tb.TB_TenThietBi,
                Value = tb.TB_ID.ToString()
            }).ToList();

            tbList.Insert(0, new SelectListItem
            {
                Text = "-- Chọn thiết bị --",
                Value = ""
            });

            ViewBag.tbList = tbList;

            return View(bttb);
        }
    }
}