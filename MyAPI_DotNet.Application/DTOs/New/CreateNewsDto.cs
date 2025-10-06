using System.ComponentModel.DataAnnotations;
namespace HelloWorld.DTOs.New
{
    public class CreateNewsDto
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public int MenuId { get; set; }


    }
}
