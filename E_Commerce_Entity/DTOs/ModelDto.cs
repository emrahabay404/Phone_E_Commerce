using E_Commerce_Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Entity.DTOs
{
   public class ModelDto : IDto
   {
      public int ModelID { get; set; }
      [Required]
      public string BrandID { get; set; }
      [Required]
      public string ModelName { get; set; }
   }
}
