using System.ComponentModel.DataAnnotations;

namespace MyAPI_DotNet.Domain.Entities // Nhớ thay YourProjectName
{
    public class Menu
    {
        [Key] // Đánh dấu đây là khóa chính
        public int Id { get; set; }

        [Required] // Bắt buộc phải có
        [MaxLength(100)] // Độ dài tối đa 100 ký tự
        public string Name { get; set; }

        // Mối quan hệ 1-n: Một Menu có thể có nhiều News
        public ICollection<News> News { get; set; } = new List<News>();
    }
}
