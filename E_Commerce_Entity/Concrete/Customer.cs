using E_Commerce_Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Entity.Concrete
{
   public class Customer : IEntity
   {
      [Key]
      public int CustomerID { get; set; }
      public string CustomerName { get; set; }
      public string CustomerLastName { get; set; }
      public List<Order> Orders { get; set; }
   }
}
