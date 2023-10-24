using AutoMapper;
using DataAccess.Abstract;
using E_Commerce_Business.Abstract;
using E_Commerce_Business.Constants;
using E_Commerce_Core.Utilities.Results;
using E_Commerce_Entity.Concrete;
using E_Commerce_Entity.DTOs;

namespace E_Commerce_Business.Concrete
{
   public class OrderManager : IOrderService
   {
      IMapper _mapper;
      IOrderDal _OrderDal;
      public OrderManager(IOrderDal orderDal, IMapper mapper)
      {
         _mapper = mapper;
         _OrderDal = orderDal;
      }
      public async Task<IResult> AddAsync(OrderDto orderDto)
      {
         var _ORDER = _mapper.Map<Order>(orderDto);
         await _OrderDal.AddAsync(_ORDER);
         return new SuccessResult(Messages.Order_Added);
      }

      public async Task<IResult> DeleteAsync(int orderID)
      {
         var _order = _mapper.Map<Order>(orderID);
         await _OrderDal.DeleteAsync(_order);
         return new SuccessResult(Messages.Order_Deleted);
      }

      public async Task<IDataResult<IEnumerable<OrderDto>>> GetAllAsync()
      {
         var _ORDER = await _OrderDal.GetAllAsync();
         var _ORDERDto = _mapper.Map<IEnumerable<OrderDto>>(_ORDER);
         return new SuccessDataResult<IEnumerable<OrderDto>>(_ORDERDto, Messages.Orders_Listed);
      }

      public async Task<IDataResult<IEnumerable<OrderDto>>> GetByCustomerID(int customerID)
      {
         var _order = await _OrderDal.GetAllAsync(x => x.CustomerID == customerID);
         var _orderDto = _mapper.Map<IEnumerable<OrderDto>>(_order);
         return new SuccessDataResult<IEnumerable<OrderDto>>(_orderDto, Messages.Orders_Listed);
      }

      public async Task<IDataResult<OrderDto>> GetByIdAsync(int orderID)
      {
         var _order = await _OrderDal.GetAsync(x => x.OrderID == orderID);
         var _orderDto = _mapper.Map<OrderDto>(_order);
         return new SuccessDataResult<OrderDto>(_orderDto, Messages.Order_Fetched);
      }

      public async Task<IResult> UpdateAsync(OrderDto orderDto)
      {
         var _order = _mapper.Map<Order>(orderDto);
         await _OrderDal.UpdateAsync(_order);
         return new SuccessResult(Messages.Order_Updated);
      }
   }
}
