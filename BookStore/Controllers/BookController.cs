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
    public class BookController : ControllerBase
    {
        private readonly IBookBL _bookBL;
        private ResponseModel resmodel;
        public BookController(IBookBL bookBL)
        {
            _bookBL = bookBL;
        }

        [Authorize(Roles = "admin")]
        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBookAsync(BookModel model)
        {
            try
            {
                var id = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                //Console.WriteLine(id);
                var result = await _bookBL.Add(model, id);
                if (result != null)
                {
                    resmodel = new ResponseModel()
                    {
                        Success = "true",
                        Message = "Book Added Successfully",
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

        [Authorize(Roles = "admin")]
        [HttpPost("UpdateBook")]
        public async Task<IActionResult> UpdateBookAsync(int bookId,BookModel model)
        {
            try
            {
                var id = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                
                var result = await _bookBL.UpdateBook(bookId, model, id);
                if (result != null)
                {
                    resmodel = new ResponseModel()
                    {
                        Success = "true",
                        Message = "Book Updated Successfully",
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

        [Authorize(Roles = "admin")]
        [HttpPost("DeleteBook")]
        public async Task<IActionResult> DeleteBookAsync(int bookid)
        {
            try
            {
                var result = await _bookBL.DeleteBook(bookid);
                if (result != null)
                {
                    resmodel = new ResponseModel()
                    {
                        Success = "true",
                        Message = "Book Deleted Successfully",
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


        [HttpPost("GetAllBook")]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            try
            {
                var result = await _bookBL.GetAllBooks();
                if (result != null)
                {
                    resmodel = new ResponseModel()
                    {
                        Success = "true",
                        Message = "Book Fetched Successfully",
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

        [HttpPost("GetBookById")]
        public async Task<IActionResult> GetBookById(int bookid)
        {
            try
            {
                var result = await _bookBL.GetBookById(bookid);
                if (result != null)
                {
                    resmodel = new ResponseModel()
                    {
                        Success = "true",
                        Message = "Book Fetched Successfully",
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
