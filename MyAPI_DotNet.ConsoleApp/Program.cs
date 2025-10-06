using Microsoft.EntityFrameworkCore;
using HelloWorld.Data; 
using HelloWorld.Models; 

// Chuỗi kết nối 
var connectionString = "Server=DESKTOP-K7TIP51\\MSSQLSERVER_01;Database=MiniProjectDb;Trusted_Connection=True;TrustServerCertificate=True";

// Cấu hình để DbContext biết cách kết nối CSDL
var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
optionsBuilder.UseSqlServer(connectionString);

// Tạo một instance của DbContext
using var context = new ApplicationDbContext(optionsBuilder.Options);

Console.WriteLine("Kết nối CSDL thành công!");

// Viết câu lệnh LINQ để truy vấn dữ liệu từ bảng Menus

if (!context.Menus.Any())
{
    Console.WriteLine("Thêm dữ liệu mẫu...");
    var menuThoiSu = new Menu { Name = "Thời sự" };
    var menuTheThao = new Menu { Name = "Thể thao" };

    context.Menus.Add(menuThoiSu);
    context.Menus.Add(menuTheThao);

    context.News.Add(new News { Title = "Bản tin sáng 1", Content = "Nội dung...", Menu = menuThoiSu });
    context.News.Add(new News { Title = "Bản tin thể thao 1", Content = "Nội dung...", Menu = menuTheThao });
    context.News.Add(new News { Title = "Bản tin sáng 2", Content = "Nội dung...", Menu = menuThoiSu });

    context.SaveChanges(); // Lưu tất cả thay đổi vào CSDL
    Console.WriteLine("Thêm dữ liệu mẫu thành công!");
}

Console.WriteLine("\n=== Bắt đầu truy vấn ===");

// === BÀI TẬP 1: LẤY TẤT CẢ MENU ===
var allMenus = context.Menus.ToList();
Console.WriteLine("Danh sách tất cả Menu:");
foreach (var menu in allMenus)
{
    Console.WriteLine($"- ID: {menu.Id}, Name: {menu.Name}");
}

// === BÀI TẬP 2: TÌM MENU THEO ID ===
var menuIdToFind = 1;
var foundMenu = context.Menus.FirstOrDefault(m => m.Id == menuIdToFind);
if (foundMenu != null)
{
    Console.WriteLine($"\nTìm thấy menu có ID {menuIdToFind}: {foundMenu.Name}");
}
else
{
    Console.WriteLine($"\nKhông tìm thấy menu có ID {menuIdToFind}");
}

// === BÀI TẬP 3: LỌC CÁC MENU THEO TÊN ===
var keyword = "Thao"; // Chữ 'Thao' trong 'Thể thao' - Liệu có thể thử bằng cách khác ngoài đưa keyword trực tiếp hay không?
var filteredMenus = context.Menus.Where(m => m.Name.Contains(keyword)).ToList();
Console.WriteLine($"\nCác menu có tên chứa '{keyword}':");
foreach (var menu in filteredMenus)
{
    Console.WriteLine($"- {menu.Name}");
}

// === BÀI TẬP 4: LẤY MENU VÀ CÁC NEWS LIÊN QUAN (QUAN TRỌNG) ===
var menuWithNews = context.Menus
    .Include(m => m.News) // Dùng Include để nạp dữ liệu từ bảng News
    .FirstOrDefault(m => m.Id == 1);

if (menuWithNews != null)
{
    Console.WriteLine($"\nCác tin tức thuộc Menu '{menuWithNews.Name}':");
    foreach (var newsItem in menuWithNews.News)
    {
        Console.WriteLine($"  - {newsItem.Title}");
    }
}