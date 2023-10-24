using E_Commerce_Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Entity.Concrete
{
   public class Version : IEntity
   {
      [Key]
      public int VersionID { get; set; }
      [ForeignKey("Model")]
      [Required]
      public int ModelID { get; set; }
      public Model Model { get; set; }
      [Required]
      public int StorageCapacity { get; set; }
      [Required]
      public float Price { get; set; }
      [Required]
      public int StockStatus { get; set; }
   }
}
