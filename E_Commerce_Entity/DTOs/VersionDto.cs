using E_Commerce_Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Entity.DTOs
{
   public class VersionDto : IDto
   {
      public int VersionID { get; set; }
      [Required]
      public int ModelID { get; set; }
      [Required]
      public int StorageCapacity { get; set; }
      [Required]
      public float Price { get; set; }
      [Required]
      public int StockStatus { get; set; }
   }
}
