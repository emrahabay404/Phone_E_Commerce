using E_Commerce_Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Entity.DTOs
{
   public class ProductDto : IDto
    {
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int UnitsInStock { get; set; }
        [Required]
        public float UnitPrice { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string ProductImage { get; set; }
    }
}
