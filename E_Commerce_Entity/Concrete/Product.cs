using E_Commerce_Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Entity.Concrete
{
   public class Product : IEntity
   {
      [Key]
      public int ProductId { get; set; }
      [Required]
      public string ProductName { get; set; }
      [Required]
      public int UnitsInStock { get; set; }
      [Required]
      public float UnitPrice { get; set; }
      [ForeignKey("Category")]
      [Required]
      public int CategoryId { get; set; }
      public Category Category { get; set; }
      [Required]
      public string ProductImage { get; set; }
      public List<OrderDetail> OrderDetails { get; set; }

   }
}
