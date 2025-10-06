using MyAPI_DotNet.Domain.Entities;
using MyAPI_DotNet.Application.DTOs.Menu;
using Microsoft.EntityFrameworkCore;
using MyAPI_DotNet.Application.Interfaces;


namespace MyAPI_DotNet.Application.Services
{
    public class MenuService : IMenuService
    {
        private readonly IApplicationDbContext _context;

        public MenuService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Menu> CreateMenuAsync(CreateMenuDto createMenuDto)
        {
            var menu = new Menu { Name = createMenuDto.Name };
            _context.Menus.Add(menu);
            await _context.SaveChangesAsync();
            return menu;
        }
        public async Task DeleteMenuAsync(int id)
        {
            var menu = await _context.Menus.FindAsync(id);
            if (menu != null)
            {
                _context.Menus.Remove(menu);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Menu>> GetAllMenusAsync()
        {
            return await _context.Menus.ToListAsync();
        }
        public async Task<Menu?> GetMenuByIdAsync(int id)
        {
            return await _context.Menus.FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task UpdateMenuAsync(int id, UpdateMenuDto updateMenuDto)
        {
            var menu = await _context.Menus.FindAsync(id);
            if (menu != null)
            {
                menu.Name = updateMenuDto.Name;
                await _context.SaveChangesAsync();
            }
        }

     
    }
}