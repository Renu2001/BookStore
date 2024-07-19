using MediatR;
using RepositoryLayer.DTO;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Commands.Order
{
    public class AddOrderCommand : IRequest<OrderDTO>
    {
        public int CustomersDetailsId { get; set; }
        public int UserId { get; set; }
        public AddOrderCommand( int customersDetailsId, int userId)
        {
            CustomersDetailsId = customersDetailsId;
            UserId = userId;
        }

    }
}
