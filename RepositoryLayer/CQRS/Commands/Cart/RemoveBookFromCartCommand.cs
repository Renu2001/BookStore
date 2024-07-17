using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Commands.Cart
{
    public class RemoveBookFromCartCommand : IRequest<bool>
    {
        public int UserId { get; set; }
        public int BookId { get; set; }

        public RemoveBookFromCartCommand(int userId, int bookId)
        {
            UserId = userId;
            BookId = bookId;
        }
    }
}
