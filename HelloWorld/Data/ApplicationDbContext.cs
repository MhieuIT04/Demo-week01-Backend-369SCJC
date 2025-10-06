using MyAPI_DotNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MyAPI_DotNet.Application.Interfaces;


namespace HelloWorld.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Khai báo các bảng mà EF Core sẽ quản lý
        public DbSet<Menu> Menus { get; set; }
        public DbSet<News> News { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

            // === BẮT ĐẦU SEED DATA ===

            // Seed data cho bảng Menu
            modelBuilder.Entity<Menu>().HasData(
                new Menu { Id = 1, Name = "Thời sự" },
                new Menu { Id = 2, Name = "Thể thao" },
                new Menu { Id = 3, Name = "Giải trí" }
            );

            // Seed data cho bảng News
            modelBuilder.Entity<News>().HasData(
        new News
        {
            Id = 1,
            Title = "Bão số 5 sắp vào biển Đông",
            Content = "Nội dung chi tiết về cơn bão số 5...",
 
            CreatedDate = new DateTime(2023, 10, 27),
            MenuId = 1
        },
        new News
        {
        Id = 2,
        Title = "Kết quả vòng 10 V-League",
        Content = "CLB A thắng CLB B với tỷ số 2-1...",

        CreatedDate = new DateTime(2023, 10, 27),
        MenuId = 2
        },
        new News
        {
            Id = 3,
            Title = "Ca sĩ X ra mắt MV mới",
            Content = "MV mới của ca sĩ X đạt triệu view...",
   
            CreatedDate = new DateTime(2023, 10, 27),
            MenuId = 3
        }
            );
        }

    }
}