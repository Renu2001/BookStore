using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.DTO;
using RepositoryLayer.Entity;
using RepositoryLayer.Exceptions;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class OrderRL : IOrderRL
    {
        private readonly BookStoreContext _bookStoreContext;

        public OrderRL(BookStoreContext bookStoreContext)
        {
            _bookStoreContext = bookStoreContext;
        }
        public async Task<List<OrderEntity>> GetAllOrders(int userId)
        {
            try
            {
                var result = await _bookStoreContext.Orders.Where(x => x.UserEntityId == userId).ToListAsync();
                if (result == null)
                    throw new CustomException("Nothing Found");
                return result;
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message);
            }
        }

        public async Task<OrderDTO> PlaceOrder(int userId, int customersDetailsId)
        {
            try
            {
                var result = _bookStoreContext.Carts.Where(x => x.UserId == userId).ToList();
                
                foreach(var order in result)
                {
                    var orderEntity = new OrderEntity()
                    {
                        UserEntityId = userId,
                        CartId = order.Id,
                        CustomersDetailsId = customersDetailsId,
                        Quantity = order.Quantity,
                        TotalPrice = order.TotalPrice
                    };
                    _bookStoreContext.Orders.Add(orderEntity);
                }
               
                await _bookStoreContext.SaveChangesAsync();
                var ordersummary = new OrderDTO()
                {

                };
                return ordersummary;
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message);
            }
        }
    }
}
