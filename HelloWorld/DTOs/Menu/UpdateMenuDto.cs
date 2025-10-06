using System.ComponentModel.DataAnnotations;
namespace HelloWorld.DTOs.Menu
{
    public class UpdateMenuDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
