using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAn.Models;
using Microsoft.AspNetCore.Mvc;

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
            var toaList = _context.Toas.OrderBy(t => t.T_ID).ToList();
            return View(toaList);
        }
    }
}