# Demo-week01-Backend
Demo kiến thức và tìm hiểu tuần 1 các kiến thức Backend 
- Ngày 01: kiến thức tìm hiểu
+ Cài đặt thành công .NET core 8, Postman
+ Tạo và chạy được 1 project .NET 8 từ template
+ Thêm vào một endpoint /hello đơn và gọi nó thành công qua swagger
+ Hiểu được các khái niệm về: Resource, HTTP verb (get, post, put, delete), endpoint, status code

- Ngày 02: Hiểu cách ứng dụng .NET kết nối và ánh xạ với cơ sở dữ liệu SQL Server thông qua EF Core.
*   Project .NET API không báo lỗi khi build.
*   CSDL `MiniProjectDb` trong SQL Server có 3 bảng: `Menus`, `News`, và `__EFMigrationsHistory`.
*   Bảng `News` có cột `MenuId` là khóa ngoại và có quan hệ với khóa chính của bảng `Menus`.

- Ngày 03: Học cách dùng LINQ để truy vấn dữ liệu từ database thông qua EF Core một cách hiệu quả
*   Bạn có thể tự tin giải thích chức năng của `Where`, `Select`, `FirstOrDefault`, `ToList`, và `Include`.
*   Bạn có thể tự viết các câu lệnh LINQ đơn giản để truy vấn dữ liệu từ 2 bảng có quan hệ 1-n.
*   Bạn đã sẵn sàng để ngày mai áp dụng chính xác các câu lệnh này vào bên trong các endpoint API.

