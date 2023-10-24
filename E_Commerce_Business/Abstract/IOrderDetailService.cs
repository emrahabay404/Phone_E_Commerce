using E_Commerce_Core.Utilities.Results;
using E_Commerce_Entity.DTOs;

namespace E_Commerce_Business.Abstract
{
   public interface IOrderDetailService
   {
      Task<IResult> AddAsync(OrderDetailDto  orderDetailDto);
      Task<IResult> UpdateAsync(OrderDetailDto  orderDetailDto);
      Task<IResult> DeleteAsync(int OrderDetailID);
      Task<IDataResult<OrderDetailDto>> GetByIdAsync(int OrderDetailID);
      Task<IDataResult<IEnumerable<OrderDetailDto>>> GetByOrderId(int OrderID);
      Task<IDataResult<IEnumerable<OrderDetailDto>>> GetAllAsync();
   }
}
