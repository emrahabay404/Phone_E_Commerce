using E_Commerce_Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Entity.Concrete
{
   public class Brand : IEntity
   {
      [Key]
      public int BrandID { get; set; }
      [Required]
      public string BrandName { get; set; }
      public List<Model> Models { get; set; }
   }
}
