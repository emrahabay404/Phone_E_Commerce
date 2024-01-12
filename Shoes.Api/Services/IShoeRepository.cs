using MicroServices.Data.Models;

namespace Shoes.Api.Services
{
   public interface IShoeRepository
   {
      List<Shoe> GetShoes();

      bool DeleteShoe(int id);
   }
}
