using MediatR;
using MyAPI_DotNet.Application.Interfaces;

namespace MyAPI_DotNet.Application.Features.Menus.Commands.DeleteMenu
{
    // 1. Định nghĩa Command
    // - Chỉ cần Id của menu cần xóa.
    // - Kế thừa IRequest<Unit> vì không cần trả về dữ liệu.
    public class DeleteMenuCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }

    // 2. Định nghĩa Handler
    public class DeleteMenuCommandHandler : IRequestHandler<DeleteMenuCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMenuCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
        {
            var menu = await _context.Menus.FindAsync(new object[] { request.Id }, cancellationToken);

            if (menu == null)
            {
                throw new KeyNotFoundException($"Menu with Id {request.Id} not found.");
            }

            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}