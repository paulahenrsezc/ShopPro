using Microsoft.AspNetCore.Mvc;
using ShopPro.Modules.Application.Dtos.OrderDetails;
using ShopPro.Modules.Application.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopPro.Modules.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsService orderDetailsService;

        public OrderDetailsController(IOrderDetailsService orderDetailsService)
        {
            this.orderDetailsService = orderDetailsService;
        }

        [HttpGet("GetOrderDetails")]
        public IActionResult Get()
        {
            var result = this.orderDetailsService.GetOrderDetails();

            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpGet("GetOrderDetailsById")]
        public IActionResult Get(int id)
        {
            var result = this.orderDetailsService.GetOrderDetails(id);

            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpPost("SaveOrderDetails")]
        public IActionResult Post([FromBody] OrderDetailsSaveDto saveDto)
        {
            var result = this.orderDetailsService.SaveOrderDetails(saveDto);

            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpPut("UpdateOrderDetails")]
        public IActionResult Put(OrderDetailsUpdateDto updateDto)
        {
            var result = this.orderDetailsService.UpdateOrderDetails(updateDto);

            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpDelete("RemoveOrderDetails")]
        public IActionResult Delete(OrderDetailsRemoveDto removeDto)
        {
            var result = this.orderDetailsService.RemoveOrderDetails(removeDto);

            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }
    }
}
