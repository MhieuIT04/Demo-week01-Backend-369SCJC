using Microsoft.AspNetCore.Mvc;
using MyAPI_DotNet.Application.DTOs.Menu;
using MyAPI_DotNet.Application.Interfaces;
using MyAPI_DotNet.Domain.Entities; 

namespace HelloWorld.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        // Controller chỉ phụ thuộc vào Interface của tầng Application
        private readonly IMenuService _menuService;

        public MenusController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        // GET: api/menus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Menu>>> GetMenus()
        {
            var menus = await _menuService.GetAllMenusAsync();
            return Ok(menus);
        }

        // GET: api/menus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Menu>> GetMenu(int id)
        {
            // Chỉ gọi service, không chứa logic
            var menu = await _menuService.GetMenuByIdAsync(id);

            if (menu == null)
            {
                return NotFound(); // Việc trả về HTTP Status Code là trách nhiệm của Controller
            }

            return Ok(menu);
        }

        // POST: api/menus
        [HttpPost]
        public async Task<ActionResult<Menu>> CreateMenu([FromBody] CreateMenuDto createMenuDto)
        {
            // Chỉ gọi service, không chứa logic
            var newMenu = await _menuService.CreateMenuAsync(createMenuDto);

            // Trả về response theo chuẩn RESTful
            return CreatedAtAction(nameof(GetMenu), new { id = newMenu.Id }, newMenu);
        }

        // PUT: api/menus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenu(int id, [FromBody] UpdateMenuDto updateMenuDto)
        {
            try
            {
                // Chỉ gọi service, không chứa logic
                await _menuService.UpdateMenuAsync(id, updateMenuDto);
            }
            catch (KeyNotFoundException) // Bắt lỗi cụ thể do service ném ra
            {
                return NotFound();
            }

            return NoContent(); // Trả về 204 No Content khi thành công
        }

        // DELETE: api/menus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            try
            {
                // Chỉ gọi service, không chứa logic
                await _menuService.DeleteMenuAsync(id);
            }
            catch (KeyNotFoundException) // Bắt lỗi cụ thể do service ném ra
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}