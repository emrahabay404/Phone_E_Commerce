using E_Commerce_Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Entity.DTOs
{
   public class OrderDetailDto : IDto
   {
      public int OrderDetailId { get; set; }
      [Required]
      public int OrderID { get; set; }
      [Required]
      public int ProductId { get; set; }
      [Required]
      public int Quantity { get; set; }
      [Required]
      public float UnitPrice { get; set; }
   }
}
