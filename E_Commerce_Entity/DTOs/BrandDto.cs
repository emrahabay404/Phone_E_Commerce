using E_Commerce_Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Entity.DTOs
{
   public class BrandDto : IDto
   {
      public int BrandID { get; set; }
      [Required] public string BrandName { get; set; }
   }
}
