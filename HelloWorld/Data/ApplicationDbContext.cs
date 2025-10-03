using HelloWorld.Models;
using Microsoft.EntityFrameworkCore;
using HelloWorld.Models;

namespace HelloWorld.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Khai báo các bảng mà EF Core sẽ quản lý
        public DbSet<Menu> Menus { get; set; }
        public DbSet<News> News { get; set; }
    }
}