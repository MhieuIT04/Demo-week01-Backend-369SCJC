using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAPI_DotNet.Application.Interfaces;
using MyAPI_DotNet.Domain.Entities;

namespace MyAPI_DotNet.Application.Features.Menus.Queries.GetAllMenus
{
    // 1. Định nghĩa Query: Nó không cần thuộc tính gì vì ta muốn lấy tất cả.
    //    Nó kế thừa IRequest<T> với T là kiểu dữ liệu trả về.
    public class GetAllMenusQuery : IRequest<IEnumerable<Menu>> { }

    // 2. Định nghĩa Handler: Logic xử lý Query.
    //    Nó kế thừa IRequestHandler<TQuery, TResponse>.
    public class GetAllMenusQueryHandler : IRequestHandler<GetAllMenusQuery, IEnumerable<Menu>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllMenusQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Menu>> Handle(GetAllMenusQuery request, CancellationToken cancellationToken)
        {
            // Logic xử lý y hệt như trong Service cũ.
            // Tối ưu: Dùng AsNoTracking() vì đây là truy vấn chỉ đọc.
            return await _context.Menus.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}