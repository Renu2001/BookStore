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
                var orderslist = new List<OrderEntity>();
                double ordertotalprice = 0;
                
                foreach(var order in result)
                {
                    var orderEntity = new OrderEntity()
                    {
                        UserEntityId = userId,
                        BookId = order.BookId,
                        CustomersDetailsId = customersDetailsId,
                        Quantity = order.Quantity,
                        TotalPrice = order.TotalPrice
                    };
                    ordertotalprice += order.TotalPrice;
                    var bookentity = _bookStoreContext.Books.FirstOrDefault(x => x.Id == order.BookId);
                    
                    bookentity.Quantity -= order.Quantity;
                    _bookStoreContext.Books.Update(bookentity);
                    orderslist.Add(orderEntity);
                    _bookStoreContext.Orders.Add(orderEntity);
                    _bookStoreContext.Carts.Remove(order);
                }
                await _bookStoreContext.SaveChangesAsync();
                var ordersummary = new OrderDTO()
                {
                    Orders = orderslist,
                    TotalPrice = ordertotalprice
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
