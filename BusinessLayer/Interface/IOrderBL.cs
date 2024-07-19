using ModelLayer;
using RepositoryLayer.DTO;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IOrderBL
    {
        Task<List<OrderEntity>> GetAllOrders(int id);
        Task<OrderDTO> PlaceOrder(OrderModel model, int id);
    }
}
