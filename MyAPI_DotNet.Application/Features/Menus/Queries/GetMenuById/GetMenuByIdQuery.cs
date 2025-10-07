using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAPI_DotNet.Application.Interfaces;
using MyAPI_DotNet.Domain.Entities;

namespace MyAPI_DotNet.Application.Features.Menus.Queries.GetMenuById
{
    // 1. Định nghĩa Query
    // - Chứa dữ liệu cần thiết: Id của menu cần tìm.
    // - Kế thừa IRequest<Menu?>: vì nó sẽ trả về một đối tượng Menu, hoặc null nếu không tìm thấy.
    public class GetMenuByIdQuery : IRequest<Menu?>
    {
        public int Id { get; set; }
    }

    // 2. Định nghĩa Handler
    public class GetMenuByIdQueryHandler : IRequestHandler<GetMenuByIdQuery, Menu?>
    {
        private readonly IApplicationDbContext _context;

        public GetMenuByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Menu?> Handle(GetMenuByIdQuery request, CancellationToken cancellationToken)
        {
            // Logic nghiệp vụ: Tìm menu bằng Id. Dùng FindAsync là tối ưu nhất cho việc tìm theo khóa chính.
            var menu = await _context.Menus.FindAsync(new object[] { request.Id }, cancellationToken);
            return menu;
        }
    }
}