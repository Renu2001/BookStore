using BusinessLayer.Interface;
using MediatR;
using ModelLayer;
using RepositoryLayer.CQRS.Commands.Order;
using RepositoryLayer.CQRS.Queries.Cart;
using RepositoryLayer.CQRS.Queries.Order;
using RepositoryLayer.DTO;
using RepositoryLayer.Entity;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class OrderBL : IOrderBL
    {
        private readonly IMediator mediator;

        public OrderBL(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<List<OrderEntity>> GetAllOrders(int userid)
        {
            var result = await mediator.Send(new GetAllOrdersQuery(userid));
            return result;
        }

        public async Task<OrderDTO> PlaceOrder(OrderModel model, int userid)
        {
            var result = await mediator.Send(new AddOrderCommand(model.CustomersDetailsId,userid));
            return result;
        }
    }
}
