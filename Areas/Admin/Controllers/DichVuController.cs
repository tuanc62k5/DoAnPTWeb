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
    }
}