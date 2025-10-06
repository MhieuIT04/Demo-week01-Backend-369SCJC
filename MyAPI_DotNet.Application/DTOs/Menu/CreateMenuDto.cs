using System.ComponentModel.DataAnnotations;
namespace MyAPI_DotNet.Application.DTOs.Menu
{
    public class CreateMenuDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
