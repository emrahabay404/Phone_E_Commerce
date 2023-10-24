using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Core.Entities.Concrete
{
   public class OperationClaim : IEntity
   {
      [Key]
      public int Id { get; set; }
      public string Name { get; set; }
   }
}
