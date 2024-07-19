using MediatR;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Queries.Order
{
    public class GetAllOrdersQuery : IRequest<List<OrderEntity>>
    {
        public int UserId { get; set; }

        public GetAllOrdersQuery(int userId)
        {
            UserId = userId;
        }
    }
}
