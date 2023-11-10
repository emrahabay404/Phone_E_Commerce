using AutoMapper;
using DataAccess.Abstract;
using E_Commerce_Business.Abstract;
using E_Commerce_Business.Constants;
using E_Commerce_Core.Utilities.Results;
using E_Commerce_Entity.DTOs;
using Order = E_Commerce_Entity.Concrete.Order;

namespace E_Commerce_Business.Concrete
{
   public class OrderManager : IOrderService
   {
      IMapper _mapper;
      IOrderDal _OrderDal;
      public ICacheService _CacheService { get; }
      public OrderManager(IOrderDal orderDal, IMapper mapper, ICacheService cacheService)
      {
         _CacheService = cacheService;
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
         var _entity = await _OrderDal.GetAllAsync();
         var entityDtos = _mapper.Map<IEnumerable<OrderDto>>(_entity);
         var expirationTime = DateTimeOffset.Now.AddMinutes(30);
         _CacheService.SetData("AllOrders", entityDtos, expirationTime);
         var cachedData = _CacheService.GetData<IEnumerable<OrderDto>>("AllOrders");
         return new SuccessDataResult<IEnumerable<OrderDto>>(cachedData, Messages.Orders_Listed);
      }

      public async Task<IDataResult<IEnumerable<OrderDto>>> GetByCustomerID(int customerID)
      {
         var _Entity = await _OrderDal.GetAllAsync(Order => Order.CustomerID == customerID);
         var _EntityDto = _mapper.Map<IEnumerable<OrderDto>>(_Entity);
         var expirationTime = DateTimeOffset.Now.AddMinutes(30);
         _CacheService.SetData("OrderByCustomerID", _EntityDto, expirationTime);
         var cachedData = _CacheService.GetData<IEnumerable<OrderDto>>("OrderByCustomerID");
         return new SuccessDataResult<IEnumerable<OrderDto>>(cachedData, Messages.Order_Fetched);
      }

      public async Task<IDataResult<OrderDto>> GetByIdAsync(int _OrderID)
      {
         var _Entity = await _OrderDal.GetAsync(Order => Order.OrderID == _OrderID);
         var _EntityDto = _mapper.Map<OrderDto>(_Entity);
         var expirationTime = DateTimeOffset.Now.AddMinutes(30);
         _CacheService.SetData("OrderByID", _EntityDto, expirationTime);
         var cachedData = _CacheService.GetData<OrderDto>("OrderByID");
         return new SuccessDataResult<OrderDto>(cachedData, Messages.Order_Fetched);
      }

      public async Task<IResult> UpdateAsync(OrderDto orderDto)
      {
         var _order = _mapper.Map<Order>(orderDto);
         await _OrderDal.UpdateAsync(_order);
         return new SuccessResult(Messages.Order_Updated);
      }
   }
}
