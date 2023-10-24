using E_Commerce_Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Entity.DTOs
{
   public class CustomerDto : IDto
   {
      public int CustomerID { get; set; }
      [Required]
      public string CustomerName { get; set; }
      [Required]
      public string CustomerLastName { get; set; }
   }
}
