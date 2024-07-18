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
    public class CustomerDetailsController : ControllerBase
    {
        private readonly ICustomerDetailsBL _customerDetailsBL;
        private ResponseModel resmodel;

        public CustomerDetailsController(ICustomerDetailsBL customerDetailsBL)
        {
            _customerDetailsBL = customerDetailsBL;
        }


        [HttpPost("AddCustomerDetails")]
        public async Task<IActionResult> AddCustomerDetailsAsync(CustomerDetailsModel model)
        {
            try
            {
                var userid = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                var result = await _customerDetailsBL.AddCustomerDetails(model, userid);
                if (result != null)
                {
                    resmodel = new ResponseModel()
                    {
                        Success = "true",
                        Message = "Customer Details Added Successfully",
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

        [HttpPost("UpdateCustomerDetails")]
        public async Task<IActionResult> UpdateCustomerDetailsAsync(CustomerDetailsModel model)
        {
            try
            {
                var userid = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                var result = await _customerDetailsBL.UpdateCustomerDetails(model, userid);
                if (result != null)
                {
                    resmodel = new ResponseModel()
                    {
                        Success = "true",
                        Message = "Customer Details Updated Successfully",
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

        [HttpDelete("RemoveCustomerDetails")]
        public async Task<IActionResult> RemoveCustomerDetailsAsync(string type)
        {
            try
            {
                var userid = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                var result = await _customerDetailsBL.RemoveCustomerDetails(type, userid);
                if (result != null)
                {
                    resmodel = new ResponseModel()
                    {
                        Success = "true",
                        Message = "Customer Details Deleted Successfully",
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

        [HttpGet("GetCustomerDetails")]
        public async Task<IActionResult> GetCustomerDetailsAsync()
        {
            try
            {
                var userid = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                var result = await _customerDetailsBL.GetCustomerDetails(userid);
                if (result != null)
                {
                    resmodel = new ResponseModel()
                    {
                        Success = "true",
                        Message = "Customer Details Fetched Successfully",
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
