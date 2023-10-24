using E_Commerce_Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Entity.Concrete
{
   public class Model : IEntity
   {
      [Key]
      public int ModelID { get; set; }
      [ForeignKey("Brand")]
      [Required]
      public int BrandID { get; set; }
      public Brand Brand { get; set; }
      [Required]
      public string ModelName { get; set; }
      public List<Version> Versions { get; set; }
   }
}
