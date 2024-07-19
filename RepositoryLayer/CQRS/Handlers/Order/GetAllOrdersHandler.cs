using MediatR;
using RepositoryLayer.CQRS.Queries.Order;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Handlers.Order
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, List<OrderEntity>>
    {
        private readonly IOrderRL _orderRL;

        public GetAllOrdersHandler(IOrderRL orderRL)
        {
            _orderRL = orderRL;
        }

        public async Task<List<OrderEntity>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var result = await _orderRL.GetAllOrders(request.UserId);
            return result;
        }
    }
}
