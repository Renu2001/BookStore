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
    public class CartController : ControllerBase
    {
        private readonly ICartBL _cartBL;
        private ResponseModel resmodel;
        public CartController(ICartBL cartBL)
        {
            _cartBL = cartBL;
        }

        [HttpPost("AddBookToCart")]
        public async Task<IActionResult> AddBookToCartAsync(CartModel model)
        {
            try
            {
                var id = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                var result = await _cartBL.AddBookToCart(model, id);
                if (result != null)
                {
                    resmodel = new ResponseModel()
                    {
                        Success = "true",
                        Message = "Book Added to Cart Successfully",
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

        [HttpPost("UpdateQuantity")]
        public async Task<IActionResult> UpdateQuantity(CartModel model)
        {
            try
            {
                var id = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                var result = await _cartBL.UpdateQuantity(model, id);
                if (result != null)
                {
                    resmodel = new ResponseModel()
                    {
                        Success = "true",
                        Message = "Cart updated Successfully",
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
    
        [HttpDelete("DeleteBookFromCart")]
        public async Task<IActionResult> DeleteBookFromCart(int bookid)
        {
            try
            {
                var id = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                var result = await _cartBL.DeleteBookFromCart(id,bookid);
                if (result != null)
                {
                    resmodel = new ResponseModel()
                    {
                        Success = "true",
                        Message = "Book Added to Cart Successfully",
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

        [HttpGet("GetAllBooksFromCart")]
        public async Task<IActionResult> GetAllBooksFromCart()
        {
            try
            {
                var id = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                var result = await _cartBL.GetAllBooksFromCart(id);
                if (result != null)
                {
                    resmodel = new ResponseModel()
                    {
                        Success = "true",
                        Message = "Book Added to Cart Successfully",
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
    }
}
