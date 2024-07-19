using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using RepositoryLayer.Exceptions;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderBL _orderBL;
        private ResponseModel resmodel;

        public OrderController(IOrderBL orderBL)
        {
            _orderBL = orderBL;
        }

        [HttpPost("PlaceOrder")]
        public async Task<IActionResult> PlaceOrderAsync(OrderModel model)
        {
            try
            {
                var id = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                var result = await _orderBL.PlaceOrder(model, id);
                if (result != null)
                {
                    resmodel = new ResponseModel()
                    {
                        Success = "true",
                        Message = "Order Placed Successfully",
                        Data = result
                    };

                }
            }
            catch (CustomException ex)
            {
                resmodel = new ResponseModel()
                {
                    Success = "false",
                    Message = ex.Message
                };
                return StatusCode(400, resmodel);
            }

            return StatusCode(201, resmodel);
        }

        [HttpGet("GetAllOrder")]
        public async Task<IActionResult> GetAllOrder()
        {
            try
            {
                var id = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                var result = await _orderBL.GetAllOrders(id);
                if (result != null)
                {
                    resmodel = new ResponseModel()
                    {
                        Success = "true",
                        Message = "Order Fetched Successfully",
                        Data = result
                    };

                }
            }
            catch (CustomException ex)
            {
                resmodel = new ResponseModel()
                {
                    Success = "false",
                    Message = ex.Message
                };
                return StatusCode(400, resmodel);
            }

            return StatusCode(200, resmodel);
        }

    }
}
