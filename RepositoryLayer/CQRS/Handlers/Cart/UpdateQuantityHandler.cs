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
    public class UpdateQuantityHandler : IRequestHandler<UpdateQuantityCommand, CartEntity>
    {
        private readonly ICartRL _cartRL;

        public UpdateQuantityHandler(ICartRL cartRL)
        {
            _cartRL = cartRL;
        }

        public async Task<CartEntity> Handle(UpdateQuantityCommand request, CancellationToken cancellationToken)
        {
            var result = await _cartRL.UpdateQuantity(request.BookId,request.Quantity,request.UserId);
            return result;
        }
    }
}
