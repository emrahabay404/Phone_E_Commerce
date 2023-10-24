using E_Commerce_Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Entity.Concrete
{
   public class OrderDetail : IEntity
   {
      [Key]
      public int OrderDetailId { get; set; }
      [ForeignKey("Order")]
      [Required]
      public int OrderID { get; set; }
      public Order Order { get; set; }
      [ForeignKey("Product")]
      [Required]
      public int ProductId { get; set; }
      public Product Product { get; set; }
      [Required]
      public int Quantity { get; set; }
      [Required]
      public float UnitPrice { get; set; }
   }
}
