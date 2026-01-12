using DoAn.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace DoAn.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<tblMenu> Menus { get; set; }
        public DbSet<AdminMenu> AdminMenus { get; set; }
        public DbSet<tblTaiKhoan> TaiKhoans { get; set; }
        public DbSet<tblCoSo> CoSos { get; set; }
        
        public DbSet<tblPhong> Phongs { get; set; }
        public DbSet<tblToa> Toas { get; set; }
        public DbSet<tblSinhVien> SinhViens { get; set; }
        public DbSet<tblDichVu> DichVus { get; set; }
        public DbSet<tblDichVuPhong> DichVuPhongs { get; set; }
        public DbSet<tblThietBi> ThietBis { get; set; }
        public DbSet<tblThietBiPhong> ThietBiPhongs { get; set; }
        public DbSet<tblBaoTriThietBi> BaoTriThietBis { get; set; }
        public DbSet<tblDatPhong> DatPhongs { get; set; }
        public DbSet<tblHopDong> HopDongs { get; set; }
    }
}