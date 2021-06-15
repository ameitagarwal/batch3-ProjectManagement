using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Models
{
    public class ProductModel
    {

        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ProductCode1 { get; set; }
        public decimal Amount { get; set; }
    }
}
