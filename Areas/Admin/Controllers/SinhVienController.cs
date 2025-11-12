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
    public class SinhVienController : Controller
    {
        private readonly DataContext _context;
        public SinhVienController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var svList = _context.SinhViens.Include(sv => sv.Phong).Include(sv => sv.TaiKhoan).OrderBy(sv => sv.SV_ID).ToList();
            return View(svList);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var sv = _context.SinhViens.Find(id);
            if (sv == null)
                return NotFound();
            return View(sv);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var delSinhVien = _context.SinhViens.Find(id);
            if (delSinhVien == null)
                return NotFound();
            _context.SinhViens.Remove(delSinhVien);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public IActionResult Create()
        {
        return View();
        }
        [HttpPost]
        public IActionResult Create(tblSinhVien sv)
        {
            if (!string.IsNullOrWhiteSpace(sv.TenPhong))
            {
                var phong = _context.Phongs.FirstOrDefault(p => p.P_TenPhong == sv.TenPhong);
                if (phong != null)
                {
                    sv.P_ID = phong.P_ID;
                }
                else
                {
                    ModelState.AddModelError(nameof(sv.TenPhong), "Phòng này ko tồn tại trong danh sách!");
                }
            }

            if (!string.IsNullOrWhiteSpace(sv.TenDangNhap))
            {
                var tk = _context.TaiKhoans.FirstOrDefault(tk => tk.TK_TenDangNhap == sv.TenDangNhap);
                if (tk != null)
                {
                    sv.TK_ID = tk.TK_ID;
                }
                else
                {
                    ModelState.AddModelError(nameof(sv.TenDangNhap), "tài khoản ko tồn tại trong danh sách!");
                }
            }

            if (ModelState.IsValid)
            {
                _context.SinhViens.Add(sv);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sv);
        }
        
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var sv = _context.SinhViens.Find(id);
            if (sv == null)
            {
                return NotFound();
            }

            sv.TenPhong = sv.Phong?.P_TenPhong;
            sv.TenDangNhap = sv.TaiKhoan?.TK_TenDangNhap;

            return View(sv);
        }
        [HttpPost]
        public IActionResult Edit(tblSinhVien sv)
        {
            if (!string.IsNullOrWhiteSpace(sv.TenPhong))
            {
                var input = sv.TenPhong.Trim().ToLower();
                var phong = _context.Phongs.FirstOrDefault(p => (p.P_TenPhong ?? "").Trim().ToLower() == input);
                if (phong != null)
                {
                    sv.P_ID = phong.P_ID;
                }
                else
                {
                    ModelState.AddModelError(nameof(sv.TenPhong), "Phòng này không tồn tại trong danh sách!");
                }
            }

            if (!string.IsNullOrWhiteSpace(sv.TenDangNhap))
            {
                var inputTk = sv.TenDangNhap.Trim().ToLower();
                var tk = _context.TaiKhoans.FirstOrDefault(t => (t.TK_TenDangNhap ?? "").Trim().ToLower() == inputTk);
                if (tk != null)
                {
                    sv.TK_ID = tk.TK_ID;
                }
                else
                {
                    ModelState.AddModelError(nameof(sv.TenDangNhap), "Tài khoản này không tồn tại trong danh sách!");
                }
            }

            if (ModelState.IsValid)
            {
                _context.SinhViens.Update(sv);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            sv.Phong = _context.Phongs.FirstOrDefault(p => p.P_ID == sv.P_ID);
            sv.TaiKhoan = _context.TaiKhoans.FirstOrDefault(t => t.TK_ID == sv.TK_ID);
            sv.TenPhong = sv.TenPhong ?? sv.Phong?.P_TenPhong;
            sv.TenDangNhap = sv.TenDangNhap ?? sv.TaiKhoan?.TK_TenDangNhap;

            return View(sv);
        }
    }
}