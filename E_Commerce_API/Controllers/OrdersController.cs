using E_Commerce_Business.Abstract;
using E_Commerce_Entity.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
   //[Authorize]
   [Route("api/[controller]")]
   [ApiController]
   public class OrdersController : ControllerBase
   {
      IOrderService _OrderService;
      IOrderDetailService _OrderDetailService;

      public OrdersController(IOrderService orderService, IOrderDetailService orderDetailService)
      {
         _OrderService = orderService;
         _OrderDetailService = orderDetailService;
      }

      //[HttpGet("orders")]
      [HttpGet]
      public async Task<IActionResult> GetAll()
      {
         var result = await _OrderService.GetAllAsync();
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest(result);
      }

      [HttpGet("[action]/{customerID}")]
      public async Task<IActionResult> Customer(int customerID)
      {
         var result = await _OrderService.GetByCustomerID(customerID);
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest();
      }

      [HttpGet("[action]/{orderId}")]
      public async Task<IActionResult> GetDetailsByOrderID(int orderId)
      {
         var result = await _OrderDetailService.GetByOrderId(orderId);
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest();
      }

      [HttpPost]
      public async Task<IActionResult> Add(OrderDto orderDto)
      {
         var result = await _OrderService.AddAsync(orderDto);
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest();
      }

      [HttpDelete("{orderId}")]
      public async Task<IActionResult> Delete(int orderId)
      {
         var result = await _OrderService.DeleteAsync(orderId);
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest();
      }

      [HttpPut]
      public async Task<IActionResult> Update(OrderDto orderDto)
      {
         var result = await _OrderService.UpdateAsync(orderDto);
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest();
      }

   }
}
