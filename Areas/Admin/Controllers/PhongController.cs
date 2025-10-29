using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DoAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PhongController : Controller
    {
        private readonly DataContext _context;
        public PhongController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var phongList = _context.Phongs.Include(p => p.Toa).OrderBy(p => p.P_ID).ToList();
            return View(phongList);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var p = _context.Phongs.Find(id);
            if (p == null)
                return NotFound();
            return View(p);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var delPhong = _context.Phongs.Find(id);
            if (delPhong == null)
                return NotFound();
            _context.Phongs.Remove(delPhong);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            ViewBag.toaList = new SelectList(_context.Toas, "T_ID", "T_TenToa");
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(tblPhong p)
        {
            if (ModelState.IsValid)
            {
                _context.Phongs.Add(p);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.toaList = new SelectList(_context.Toas, "T_ID", "T_TenToa", p.T_ID);
            return View(p);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var p = _context.Phongs.Find(id);
            if (p == null)
                return NotFound();

            var toaList = _context.Toas.Select(t => new SelectListItem
            {
                Text = t.T_TenToa,
                Value = t.T_ID.ToString()
            }).ToList();

            toaList.Insert(0, new SelectListItem
            {
                Text = "-- Chọn tòa KTX --",
                Value = ""
            });
            ViewBag.toaList = toaList;

            return View(p);
        }

        [HttpPost]
        public IActionResult Edit(tblPhong p)
        {
            if (ModelState.IsValid)
            {
                _context.Phongs.Update(p);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            var phongList = _context.Toas.Select(t => new SelectListItem
            {
                Text = t.T_TenToa,
                Value = t.T_ID.ToString()
            }).ToList();

            phongList.Insert(0, new SelectListItem
            {
                Text = "-- Chọn tòa KTX --",
                Value = ""
            });

            ViewBag.phongList = phongList;

            return View(p);
        }
    }
}