using E_Commerce_Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Entity.Concrete
{
   public class Category : IEntity
   {
      [Key]
      public int CategoryId { get; set; }
      [Required]  
      public string CategoryName { get; set; }
      public List<Product> Products { get; set; }
   }
}
