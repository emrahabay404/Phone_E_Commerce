using E_Commerce_Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Entity.Concrete
{
   public class Order : IEntity
   {
      [Key]
      public int OrderID { get; set; }
      [ForeignKey("Customer")]
      [Required]
      public int CustomerID { get; set; }
      public Customer Customer { get; set; }
      [Required] public DateTime OrderDate { get; set; }
      [Required] public float TotalPrice { get; set; }
      [Required] public bool OrderStatus { get; set; }
      public List<OrderDetail> OrderDetails { get; set; }
   }
}
