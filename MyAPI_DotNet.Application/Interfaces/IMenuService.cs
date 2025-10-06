using MyAPI_DotNet.Domain.Entities;
using MyAPI_DotNet.Application.DTOs.Menu;


namespace MyAPI_DotNet.Application.Interfaces
{
    public interface IMenuService
    {
        Task<IEnumerable<Menu>> GetAllMenusAsync();
        Task<Menu?> GetMenuByIdAsync(int id);
        Task<Menu> CreateMenuAsync(CreateMenuDto createMenuDto);
        Task UpdateMenuAsync(int id, UpdateMenuDto updateMenuDto);
        Task DeleteMenuAsync(int id);
    }
}