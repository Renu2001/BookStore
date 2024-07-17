using MediatR;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Commands.Cart
{
    public class AddBookToCartCommand : IRequest<CartEntity>
    {
        public int Quantity { get; set; }

        public int BookId { get; set; }
        public int UserId { get; set; }
        public AddBookToCartCommand(int quantity, int bookId, int userId)
        {
            Quantity = quantity;
            BookId = bookId;
            UserId = userId;
        }
    }
}
