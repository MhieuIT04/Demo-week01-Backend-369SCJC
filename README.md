# Demo-week01-Backend
Demo kiến thức và tìm hiểu tuần 1 các kiến thức Backend 

**- Ngày 01: kiến thức tìm hiểu**
+ Cài đặt thành công .NET core 8, Postman
+ Tạo và chạy được 1 project .NET 8 từ template
+ Thêm vào một endpoint /hello đơn và gọi nó thành công qua swagger
+ Hiểu được các khái niệm về: Resource, HTTP verb (get, post, put, delete), endpoint, status code

**- Ngày 02: Hiểu cách ứng dụng .NET kết nối và ánh xạ với cơ sở dữ liệu SQL Server thông qua EF Core.**
*   Project .NET API không báo lỗi khi build.
*   CSDL `MiniProjectDb` trong SQL Server có 3 bảng: `Menus`, `News`, và `__EFMigrationsHistory`.
*   Bảng `News` có cột `MenuId` là khóa ngoại và có quan hệ với khóa chính của bảng `Menus`.

**- Ngày 03: Học cách dùng LINQ để truy vấn dữ liệu từ database thông qua EF Core một cách hiệu quả**
*   giải thích chức năng của `Where`, `Select`, `FirstOrDefault`, `ToList`, và `Include`.
*   viết các câu lệnh LINQ đơn giản để truy vấn dữ liệu từ 2 bảng có quan hệ 1-n.
  
**- Ngày 04 & 05: Xây dựng API CRUD**
- Tạo và xây dựng được bộ API CRUD(Create, Read, Update, Delete) hoàn chỉnh cho 2 đối dượng Menu và new
- Sử dụng swagger để kiểm tra tất cả các chức nănng  từ tạo, sửa, xóa dữ liệu

**- Ngày 06: Clean Archiecture**
- Tách từ Solution ban đầu thành 3 project ('Domain', 'Application', 'Presentation') với các dependency được thiết lập
- Code Logic nghiệp vụ đã được chuyển từ 'Controller' sang 'MenuService'
- Ứng dụng được chia ra 3 phần và được phân nhiệm vụ cho mỗi phần, giảm gánh nặng công việc cho Controller cũ

**- Ngày 07: CQRS và thư viện MediatR**
- Chia nhỏ trong MenuService tách 2 phần Command(lệnh) và Queries(truy vấn) ra 2 phần riêng biệt
- Áp dụng thư viện MediatR, MediatR là người trung gian nhận các đối tượng của Controller sau đó tự động tìm ra các handle và MediatR sẽ trả về cho controller
