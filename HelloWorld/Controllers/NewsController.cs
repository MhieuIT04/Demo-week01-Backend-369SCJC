using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelloWorld.Data;
using HelloWorld.Models;
using HelloWorld.DTOs.New;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public NewsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/News
        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> GetNews()
        {
            var news = await _context.News.ToListAsync();
            return Ok(news); // Trả về status 200 OK và danh sách news
        }
        // GET: api/news/5
        [HttpGet("{id}")]
        public async Task<ActionResult<News>> GetNews(int id)
        { 
            var news = await _context.News.FirstOrDefaultAsync(News => News.Id == id);
            if (news == null)
            {
                return NotFound(); // Trả về status 404 Not Found nếu không tìm thấy
            }
            return Ok(news);
        }

        // POST: api/News
        [HttpPost]
        public async Task<ActionResult<News>> CreateNews([FromBody] CreateNewsDto createNewsDto)
        {
            var news = new News
            {
                Title = createNewsDto.Title,
                Content = createNewsDto.Content,
                CreatedDate = createNewsDto.CreatedDate,
                MenuId = createNewsDto.MenuId
            };
            // 2.Thêm vào DbContext và lưu vào CSDL
            _context.News.Add(news);
            await _context.SaveChangesAsync();
            // 3.Trả về phản hồi với status 201 Created và thông tin news mới tạo
            return CreatedAtAction(nameof(GetNews), new { id = news.Id }, news);
        }

        // PUT: api/news/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNews(int id, [FromBody] UpdateNewsDto updateNewsDto)
        {
            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound(); // Trả về status 404 Not Found nếu không tìm thấy
            }
            // Cập nhật các thuộc tính của news
            news.Title = updateNewsDto.Title;
            news.Content = updateNewsDto.Content;
            news.CreatedDate = updateNewsDto.CreatedDate;
            news.MenuId = updateNewsDto.MenuId;
            // Đánh dấu entity là đã được sửa đổi
            _context.Entry(news).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync(); // Lưu các thay đổi vào CSDL
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsExists(id))
                {
                    return NotFound(); // Trả về status 404 Not Found nếu không tìm thấy trong quá trình lưu
                }
                else
                {
                    throw; // Ném lại ngoại lệ nếu có lỗi khác
                }
            }
            return NoContent(); // Trả về status 204 No Content để biểu thị cập nhật thành công
        }

        private bool NewsExists(int id)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/news/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNews(int id)
        {
            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound(); // Trả về status 404 Not Found nếu không tìm thấy
            }
            _context.News.Remove(news);
            await _context.SaveChangesAsync(); // Lưu các thay đổi vào CSDL
            return NoContent(); // Trả về status 204 No Content để biểu thị xóa thành công
        }

    }
}
