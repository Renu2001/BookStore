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
    public class AddBookToCartHandler : IRequestHandler<AddBookToCartCommand, CartEntity>
    {
        private readonly ICartRL _cartRL;

        public AddBookToCartHandler(ICartRL cartRL)
        {
            _cartRL = cartRL;
        }

        public async Task<CartEntity> Handle(AddBookToCartCommand request, CancellationToken cancellationToken)
        {
            var result = await _cartRL.AddBookToCart(request.Quantity, request.BookId, request.UserId);
            return result;
        }
    }
}
