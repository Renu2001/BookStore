using MediatR;
using RepositoryLayer.CQRS.Commands.Order;
using RepositoryLayer.DTO;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Handlers.Order
{
    public class AddOrderHandler : IRequestHandler<AddOrderCommand, OrderDTO>
    {
        private readonly IOrderRL _orderRL;

        public AddOrderHandler(IOrderRL orderRL)
        {
            _orderRL = orderRL;
        }

        public async Task<OrderDTO> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var result = await _orderRL.PlaceOrder(request.UserId, request.CustomersDetailsId);
            return result;
        }
    }
}
