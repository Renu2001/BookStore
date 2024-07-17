using MediatR;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Commands.Cart
{
    public class UpdateQuantityCommand : IRequest<CartEntity>
    {
        public int BookId { get; }
        public int Quantity { get; }
        public int UserId { get; }
        public UpdateQuantityCommand(int bookId, int quantity, int userid)
        {
            BookId = bookId;
            Quantity = quantity;
            UserId = userid;
        }

        
    }
}
