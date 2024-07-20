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
    public class WishListController : ControllerBase
    {
        private readonly IWishListBL _wishListBL;
        private ResponseModel resmodel;
        public WishListController(IWishListBL wishListBL)
        {
            _wishListBL = wishListBL;
        }

        [HttpPost("AddBookToWishList")]
        public async Task<IActionResult> AddBookToWishListAsync(WishListModel model)
        {
            try
            {
                var id = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                var result = await _wishListBL.AddBookToWishList(model, id);
                if (result != null)
                {
                    resmodel = new ResponseModel()
                    {
                        Success = "true",
                        Message = "Book Added to WishList Successfully",
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


        [HttpDelete("DeleteBookFromWishList")]
        public async Task<IActionResult> DeleteBookFromCart(int bookid)
        {
            try
            {
                var id = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                var result = await _wishListBL.DeleteBookFromWishList(id, bookid);
                if (result != null)
                {
                    resmodel = new ResponseModel()
                    {
                        Success = "true",
                        Message = "Book Deleted from WishList Successfully",
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

        [HttpGet("GetAllBooksFromWishList")]
        public async Task<IActionResult> GetAllBooksFromCart()
        {
            try
            {
                var id = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                var result = await _wishListBL.GetAllBooksFromWishList(id);
                if (result != null)
                {
                    resmodel = new ResponseModel()
                    {
                        Success = "true",
                        Message = "Book Added to WishList Successfully",
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
