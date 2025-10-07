using MediatR;
using MyAPI_DotNet.Application.Interfaces;
using MyAPI_DotNet.Domain.Entities;

namespace MyAPI_DotNet.Application.Features.Menus.Commands.CreateMenu
{
    // 1. Định nghĩa Command: Chứa các dữ liệu cần thiết để tạo Menu.
    //    Kế thừa IRequest<Menu> vì chúng ta muốn trả về Menu vừa tạo.
    public class CreateMenuCommand : IRequest<Menu>
    {
        public string Name { get; set; }
    }

    // 2. Định nghĩa Handler
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, Menu>
    {
        private readonly IApplicationDbContext _context;

        public CreateMenuCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Menu> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            var menu = new Menu { Name = request.Name };

            _context.Menus.Add(menu);
            await _context.SaveChangesAsync(cancellationToken);

            return menu;
        }
    }
}