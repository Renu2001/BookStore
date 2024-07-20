using MediatR;
using RepositoryLayer.CQRS.Queries.Cart;
using RepositoryLayer.DTO;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Handlers.Cart
{
    public class GetAllBooksByUserIdHandler : IRequestHandler<GetAllBooksByUserIdQuery, CartDTO>
    {
        private readonly ICartRL _cartRL;

        public GetAllBooksByUserIdHandler(ICartRL cartRL)
        {
            _cartRL = cartRL;
        }

        public async Task<CartDTO> Handle(GetAllBooksByUserIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _cartRL.GetAllBooksFromCart(request.Userid);
            return result;
        }
    }
}
