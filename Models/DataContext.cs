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
        public DbSet<tblSinhVien> SinhViens { get; set; }
        public DbSet<tblToa> Toas { get; set; }
    }
}