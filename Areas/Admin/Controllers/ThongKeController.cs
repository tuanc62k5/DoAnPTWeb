using DoAn.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace DoAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ThongKeController : Controller
    {
        private readonly DataContext _context;
        public ThongKeController(DataContext context)
        {
            _context = context;
        }

        // ViewModel chính
        public class ThongKeKTX
        {
            // Sinh viên
            public int TongSinhVien { get; set; }
            public int SoNam { get; set; }
            public int SoNu { get; set; }

            // Phòng & Dịch vụ
            public int TongPhong { get; set; }
            public int TongBanGhiDichVu { get; set; }
            public List<ServiceSummaryDto> ServiceDetails { get; set; } = new();

            // Thiết bị
            public int TongLoaiThietBi { get; set; }
            public int TongThietBiDaGiao { get; set; }
            public List<EquipmentSummaryDto> EquipmentDetails { get; set; } = new();
            public int TongThietBiDuocBaoTri { get; set; }      // sum BTTB_SoLuong
            public decimal TongChiPhiBaoTri { get; set; }       // sum BTTB_ChiPhi
        }

        // DTO dịch vụ: tên, tổng số lượng, tổng thành tiền
        public class ServiceSummaryDto
        {
            public string TenDichVu { get; set; } = "";
            public int TongSoLuong { get; set; }
            public decimal TongThanhTien { get; set; }
        }

        // DTO thiết bị: tên, tổng số lượng đã giao
        public class EquipmentSummaryDto
        {
            public string TenThietBi { get; set; } = "";
            public int TongSoLuongGiao { get; set; }
        }

        // GET: /Admin/ThongKe/Index
        public IActionResult Index()
        {
            // ===== SINH VIÊN =====
            var svList = _context.SinhViens.ToList();
            int tongSv = svList.Count;
            int soNam = svList.Count(x => (x.SV_GioiTinh ?? "").Trim().ToLower() == "nam");
            int soNu = svList.Count(x => (x.SV_GioiTinh ?? "").Trim().ToLower() == "nữ");

            // ===== PHÒNG =====
            int tongPhong = _context.Phongs.Count();

            // ===== DỊCH VỤ =====
            // lấy tất cả bản ghi dịch vụ và bảng dịch vụ để lấy tên
            var dvpList = _context.DichVuPhongs.ToList(); // có P_ID, DV_ID, DVP_SoLuong, DVP_ThanhTien
            var allDichVu = _context.DichVus.ToList();   // có DV_ID, DV_TenDichVu

            int tongBanGhiDichVu = dvpList.Count;

            var serviceGroups = dvpList
                .GroupBy(d =>
                {
                    var name = allDichVu.FirstOrDefault(x => x.DV_ID == (d.DV_ID ?? 0))?.DV_TenDichVu;
                    return string.IsNullOrEmpty(name) ? "Không xác định" : name;
                })
                .OrderBy(g => g.Key)
                .Select(g => new ServiceSummaryDto
                {
                    TenDichVu = g.Key!,
                    TongSoLuong = g.Sum(x => x.DVP_SoLuong ?? 0),
                    TongThanhTien = g.Sum(x => x.DVP_ThanhTien ?? 0)
                })
                .ToList();

            // ===== THIẾT BỊ =====
            var tbpList = _context.ThietBiPhongs.ToList(); // TBP_SoLuongGiao, TB_ID
            var allThietBi = _context.ThietBis.ToList();   // TB_ID, TB_Ten

            int tongLoaiThietBi = allThietBi.Count;
            int tongThietBiDaGiao = tbpList.Sum(x => x.TBP_SoLuongGiao ?? 0);

            var equipmentGroups = tbpList
                .GroupBy(t =>
                {
                    var name = allThietBi.FirstOrDefault(x => x.TB_ID == (t.TB_ID ?? 0))?.TB_TenThietBi;
                    return string.IsNullOrEmpty(name) ? "Không xác định" : name;
                })
                .OrderBy(g => g.Key)
                .Select(g => new EquipmentSummaryDto
                {
                    TenThietBi = g.Key!,
                    TongSoLuongGiao = g.Sum(x => x.TBP_SoLuongGiao ?? 0)
                })
                .ToList();

            // ===== BẢO TRÌ =====
            var bttbList = _context.BaoTriThietBis.ToList();
            int tongThietBiDuocBaoTri = bttbList.Sum(x => x.BTTB_SoLuong ?? 0); // tổng số thiết bị được bảo trì
            decimal tongChiPhiBaoTri = bttbList.Sum(x => x.BTTB_ChiPhi ?? 0);

            // ===== BUILD VIEWMODEL =====
            var vm = new ThongKeKTX
            {
                TongSinhVien = tongSv,
                SoNam = soNam,
                SoNu = soNu,
                TongPhong = tongPhong,
                TongBanGhiDichVu = tongBanGhiDichVu,
                ServiceDetails = serviceGroups,
                TongLoaiThietBi = tongLoaiThietBi,
                TongThietBiDaGiao = tongThietBiDaGiao,
                EquipmentDetails = equipmentGroups,
                TongThietBiDuocBaoTri = tongThietBiDuocBaoTri,
                TongChiPhiBaoTri = tongChiPhiBaoTri
            };

            return View(vm);
        }
    }
}
