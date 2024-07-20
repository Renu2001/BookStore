using MediatR;
using RepositoryLayer.CQRS.Commands.WishList;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Handlers.WishList
{
    public class AddItemHandler : IRequestHandler<AddItemCommand, WishListEntity>
    {
        private readonly IWishListRL _wishListRL;

        public AddItemHandler(IWishListRL wishListRL)
        {
            _wishListRL = wishListRL;
        }

        public async Task<WishListEntity> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            var result = await _wishListRL.AddItemToWishList(request.userid, request.bookId);
            return result;
        }

    }
}
