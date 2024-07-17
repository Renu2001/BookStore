using MediatR;
using RepositoryLayer.CQRS.Commands.Cart;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Handlers.Cart
{
    public class RemoveBookHandler : IRequestHandler<RemoveBookFromCartCommand, bool>
    {
        private readonly ICartRL _cartRL;

        public RemoveBookHandler(ICartRL cartRL)
        {
            _cartRL = cartRL;
        }

        public async Task<bool> Handle(RemoveBookFromCartCommand request, CancellationToken cancellationToken)
        {
            var result = await _cartRL.RemoveBookFromCart(request.BookId,request.UserId); 
            return result;
        }
    }
}
