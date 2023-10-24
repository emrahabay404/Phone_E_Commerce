using E_Commerce_Business.Abstract;
using E_Commerce_Business.Constants;
using E_Commerce_Core.Utilities.Results;
using E_Commerce_Entity.Concrete;
using E_Commerce_Entity.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
   [Authorize]
   [Route("api/[controller]")]
   [ApiController]
   public class OrderDetailController : ControllerBase
   {
      IOrderDetailService _OrderDetailService;
      public OrderDetailController(IOrderDetailService orderDetailService)
      {
         _OrderDetailService = orderDetailService;
      }

      [HttpGet("orders")]
      public async Task<IActionResult> GetAll()
      {
         var result = await _OrderDetailService.GetAllAsync();
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest(result);
      }

      [HttpPost]
      public async Task<IActionResult> Add([FromBody] OrderDetailDto[] orderDetailDto)
      {
         int ListN = orderDetailDto.Count();
         int SuccessDataN = 0;
         foreach (var item in orderDetailDto)
         {
            var result = await _OrderDetailService.AddAsync(item);
            if (result.Success)
            {
               SuccessDataN++;
            }
         }
         if (ListN == SuccessDataN)
         {
            return Ok(new SuccessResult(Messages.OrderDetail_Added));
         }
         else
         {
            return BadRequest(new SuccessResult(Messages.OrderDetailAdd_Not_Completed));
         }

      }

      [HttpDelete("{orderDetailId}")]
      public async Task<IActionResult> Delete(int orderDetailId)
      {
         var result = await _OrderDetailService.DeleteAsync(orderDetailId);
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest();
      }

      [HttpGet("GetbyOrderID{orderId}")]
      public async Task<IActionResult> GetByOrderID(int orderId)
      {
         var result = await _OrderDetailService.GetByOrderId(orderId);
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest();
      }

      [HttpPut]
      public async Task<IActionResult> Update(OrderDetailDto orderDetailDto)
      {
         var result = await _OrderDetailService.UpdateAsync(orderDetailDto);
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest();
      }

      [HttpGet("{orderDetailId}")]
      public async Task<IActionResult> Get(int orderDetailId)
      {
         var result = await _OrderDetailService.GetByIdAsync(orderDetailId);
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest();
      }

   }
}
