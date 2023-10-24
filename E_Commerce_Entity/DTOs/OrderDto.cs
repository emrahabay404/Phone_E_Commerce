using E_Commerce_Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Entity.DTOs
{
   public class OrderDto : IDto
   {
      public int OrderID { get; set; }
      [Required] public int CustomerID { get; set; }
      [Required] public DateTime OrderDate { get; set; }
      [Required] public float TotalPrice { get; set; }
      [Required] public bool OrderStatus { get; set; }
   }
}
