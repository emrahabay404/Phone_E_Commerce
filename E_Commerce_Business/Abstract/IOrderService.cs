using E_Commerce_Core.Utilities.Results;
using E_Commerce_Entity.DTOs;

namespace E_Commerce_Business.Abstract
{
   public interface IOrderService
   {
      Task<IResult> AddAsync(OrderDto  orderDto);
      Task<IResult> UpdateAsync(OrderDto orderDto);
      Task<IResult> DeleteAsync(int OrderID);
      Task<IDataResult<OrderDto>> GetByIdAsync(int OrderID);
      Task<IDataResult<IEnumerable<OrderDto>>> GetAllAsync();
      Task<IDataResult<IEnumerable<OrderDto>>> GetByCustomerID(int customerID);
      
   }
}
