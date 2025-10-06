using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAPI_DotNet.Domain.Entities 
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        public string Content { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Khóa ngoại trỏ về bảng Menu
        public int MenuId { get; set; }

        [ForeignKey("MenuId")]
        public Menu Menu { get; set; }
    }
}