using MediatR;
using RepositoryLayer.CQRS.Queries.WishList;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Handlers.WishList
{
    public class GetAllItemsHandler : IRequestHandler<GetAllItemsQuery,List<WishListEntity>>
    {
        private readonly IWishListRL _wishListRL;

        public GetAllItemsHandler(IWishListRL wishListRL)
        {
            _wishListRL = wishListRL;
        }

        public async Task<List<WishListEntity>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            var result = await _wishListRL.GetAllItemsFromWishList(request.userid);
            return result;
        }
    }
}
