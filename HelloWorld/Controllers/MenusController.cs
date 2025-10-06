using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelloWorld.Data;
using HelloWorld.Models;
using HelloWorld.DTOs.Menu;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public MenusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Menus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Menu>>> GetMenus()
        {
            var menus = await _context.Menus.ToListAsync();
            return Ok(menus); // Trả về status 200 OK và danh sách menus
        }

        // GET: api/menus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Menu>> GetMenu(int id)
        {
            var menu = await _context.Menus.FirstOrDefaultAsync(m => m.Id == id);

            if (menu == null)
            {
                return NotFound(); // Trả về status 404 Not Found nếu không tìm thấy
            }

            return Ok(menu);
        }

        // POST: api/Menus
        [HttpPost]
        public async Task<ActionResult<Menu>> CreateMenu([FromBody] CreateMenuDto createMenuDto)
        {
            var menu = new Menu
            {
                Name = createMenuDto.Name
            };

            // 2.Thêm vào DbContext và lưu vào CSDL
            _context.Menus.Add(menu);
            await _context.SaveChangesAsync();

            // 3.Trả về phản hồi với status 201 Created và thông tin menu mới tạo
            return CreatedAtAction(nameof(GetMenu), new { id = menu.Id }, menu);
        }

        // PUT: api/menus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenu(int id, [FromBody] UpdateMenuDto updateMenuDto)
        {
            // 1. Tìm menu trong CSDL
            var menu = await _context.Menus.FindAsync(id);

            // 2. Nếu không tìm thấy, trả về 404 Not Found
            if (menu == null)
            {
                return NotFound();
            }

            // 3. Cập nhật thuộc tính của đối tượng đã tìm thấy
            // EF Core đang theo dõi đối tượng 'menu' này
            menu.Name = updateMenuDto.Name;

            // 4. Lưu thay đổi
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Xử lý trường hợp có người khác đã xóa/sửa record này cùng lúc
                // For this project, we can just re-throw or handle as needed.
                throw;
            }

            // 5. Trả về 204 No Content, báo hiệu cập nhật thành công
            return NoContent();
        }
            // DELETE: api/menus/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteMenu(int id)
            {
                // 1. Tìm menu trong CSDL
                var menu = await _context.Menus.FindAsync(id);

                // 2. Nếu không tìm thấy, trả về 404 Not Found
                if (menu == null)
                {
                    return NotFound();
                }

                // 3. Xóa đối tượng khỏi DbContext
                _context.Menus.Remove(menu);
                // 4. Lưu thay đổi để áp dụng vào CSDL
                await _context.SaveChangesAsync();

                // 5. Trả về 204 No Content
                return NoContent();
            }
        }
    }

