using RepositoryLayer.DTO;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IOrderRL
    {
        Task<List<OrderEntity>> GetAllOrders(int userId);
        Task<OrderDTO> PlaceOrder(int userId, int customersDetailsId);
    }
}
