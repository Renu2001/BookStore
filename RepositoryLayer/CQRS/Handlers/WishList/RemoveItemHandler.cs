using MediatR;
using RepositoryLayer.CQRS.Commands.WishList;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Handlers.WishList
{
    public class RemoveItemHandler : IRequestHandler<RemoveItemCommand,bool>
    {
        private readonly IWishListRL _wishListRL;

        public RemoveItemHandler(IWishListRL wishListRL)
        {
            _wishListRL = wishListRL;
        }

        public async Task<bool> Handle(RemoveItemCommand request, CancellationToken cancellationToken)
        {
            var result = await _wishListRL.RemoveItemFromWishList(request.userid,request.bookid);
            return result;
        }
    }
}
