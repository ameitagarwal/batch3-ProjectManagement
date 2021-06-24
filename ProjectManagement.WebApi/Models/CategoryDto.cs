using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.WebApi.Models
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(10)]
        public string Name { get; set; }
        [Required]
        [MinLength(3)]
        public string Description { get; set; }

        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}
