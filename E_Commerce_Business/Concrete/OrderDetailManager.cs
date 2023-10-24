using AutoMapper;
using E_Commerce_Business.Abstract;
using E_Commerce_Business.Constants;
using E_Commerce_Core.Utilities.Results;
using E_Commerce_DataAccess.Abstract;
using E_Commerce_Entity.Concrete;
using E_Commerce_Entity.DTOs;

namespace E_Commerce_Business.Concrete
{
   public class OrderDetailManager : IOrderDetailService
   {
      IMapper _mapper;
      IOrderDetailDal _OrderDetailDal;
      public OrderDetailManager(IOrderDetailDal orderDetailDal, IMapper mapper)
      {
         _mapper = mapper;
         _OrderDetailDal = orderDetailDal;
      }
      public async Task<IResult> AddAsync(OrderDetailDto orderDetailDto)
      {
         var _orderDetail = _mapper.Map<OrderDetail>(orderDetailDto);
         await _OrderDetailDal.AddAsync(_orderDetail);
         return new SuccessResult(Messages.OrderDetail_Added);
      }

      public async Task<IResult> DeleteAsync(int orderDetailID)
      {
         var _orderDetail = _mapper.Map<OrderDetail>(orderDetailID);
         await _OrderDetailDal.DeleteAsync(_orderDetail);
         return new SuccessResult(Messages.OrderDetail_Deleted);
      }

      public async Task<IDataResult<IEnumerable<OrderDetailDto>>> GetAllAsync()
      {
         var _orderDetail = await _OrderDetailDal.GetAllAsync();
         var _orderDetailDto = _mapper.Map<IEnumerable<OrderDetailDto>>(_orderDetail);
         return new SuccessDataResult<IEnumerable<OrderDetailDto>>(_orderDetailDto, Messages.OrderDetail_Listed);
      }

      public async Task<IDataResult<OrderDetailDto>> GetByIdAsync(int OrderDetailId)
      {
         var _orderDetail = await _OrderDetailDal.GetAsync(x => x.OrderDetailId == OrderDetailId);
         var _orderDetailDto = _mapper.Map<OrderDetailDto>(_orderDetail);
         return new SuccessDataResult<OrderDetailDto>(_orderDetailDto, Messages.OrderDetail_Fetched);
      }

      public async Task<IResult> UpdateAsync(OrderDetailDto orderDetailDto)
      {
         var _orderDetail = _mapper.Map<OrderDetail>(orderDetailDto);
         await _OrderDetailDal.UpdateAsync(_orderDetail);
         return new SuccessResult(Messages.OrderDetail_Updated);
      }

      public async Task<IDataResult<IEnumerable<OrderDetailDto>>> GetByOrderId(int OrderID)
      {
         var _orderDetail = await _OrderDetailDal.GetAllAsync(x => x.OrderID == OrderID);
         var _orderDetailDto = _mapper.Map<IEnumerable<OrderDetailDto>>(_orderDetail);
         //return new SuccessDataResult<OrderDetailDto>(chiefDto, Messages.OrderDetail_Fetched);
         return new SuccessDataResult<IEnumerable<OrderDetailDto>>(_orderDetailDto, Messages.OrderDetail_Fetched);
      }
   }
}
