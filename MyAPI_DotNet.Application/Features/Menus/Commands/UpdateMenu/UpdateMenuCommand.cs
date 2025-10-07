using MediatR;
using MyAPI_DotNet.Application.Interfaces;

namespace MyAPI_DotNet.Application.Features.Menus.Commands.UpdateMenu
{
    // 1. Định nghĩa Command
    // - Chứa dữ liệu cần thiết: Id để biết menu nào cần sửa, và Name là dữ liệu mới.
    // - Kế thừa IRequest<Unit>: Unit là kiểu trả về của MediatR, tương đương với 'void'.
    //   Hành động Update thường không cần trả về dữ liệu gì, chỉ cần báo thành công.
    public class UpdateMenuCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    // 2. Định nghĩa Handler
    public class UpdateMenuCommandHandler : IRequestHandler<UpdateMenuCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public UpdateMenuCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateMenuCommand request, CancellationToken cancellationToken)
        {
            var menu = await _context.Menus.FindAsync(new object[] { request.Id }, cancellationToken);

            if (menu == null)
            {
                // Ném ra exception khi không tìm thấy. Controller sẽ bắt exception này.
                throw new KeyNotFoundException($"Menu with Id {request.Id} not found.");
            }

            menu.Name = request.Name;
            await _context.SaveChangesAsync(cancellationToken);

            // Trả về Unit.Value để báo hiệu hành động đã hoàn tất.
            return Unit.Value;
        }
    }
}