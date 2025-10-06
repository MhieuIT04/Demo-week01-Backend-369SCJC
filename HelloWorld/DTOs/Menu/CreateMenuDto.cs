using System.ComponentModel.DataAnnotations;
namespace HelloWorld.DTOs.Menu
{
    public class CreateMenuDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
