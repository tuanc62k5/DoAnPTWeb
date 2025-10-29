using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoSoController : Controller
    {
        private readonly DataContext _context;
        public CoSoController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var csList = _context.CoSos.OrderBy(cs => cs.CS_ID).ToList();
            return View(csList);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var cs = _context.CoSos.Find(id);
            if (cs == null)
                return NotFound();
            return View(cs);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var delCoSo = _context.CoSos.Find(id);
            if (delCoSo == null)
                return NotFound();
            _context.CoSos.Remove(delCoSo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            var csList = (from cs in _context.CoSos
                          select new SelectListItem()
                          {
                              Text = cs.CS_TenCoSo,
                              Value = cs.CS_ID.ToString()
                          }).ToList();
            csList.Insert(0, new SelectListItem()
            {
                Text = "--- select coso ---",
                Value = "0"
            });
            ViewBag.csList = csList;
            return View();
        }
        [HttpPost]
        public IActionResult Create(tblCoSo cs)
        {
            if (ModelState.IsValid)
            {
                _context.CoSos.Add(cs);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cs);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var cs = _context.CoSos.Find(id);
            if (cs == null)
                return NotFound();

            var csList = (from coso in _context.CoSos
                          select new SelectListItem()
                          {
                              Text = coso.CS_TenCoSo,
                              Value = coso.CS_ID.ToString()
                          }).ToList();
            csList.Insert(0, new SelectListItem()
            {
                Text = "--- select coso ---",
                Value = "0"
            });
            ViewBag.csList = csList;
            return View(cs);
        }
        [HttpPost]
        public IActionResult Edit(tblCoSo cs)
        {
            if (ModelState.IsValid)
            {
                _context.CoSos.Update(cs);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cs);
        }
    }
}