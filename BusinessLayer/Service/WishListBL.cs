using BusinessLayer.Interface;
using MediatR;
using ModelLayer;
using RepositoryLayer.CQRS.Commands.Cart;
using RepositoryLayer.CQRS.Commands.WishList;
using RepositoryLayer.CQRS.Queries.WishList;
using RepositoryLayer.Entity;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class WishListBL : IWishListBL
    {
        private readonly IMediator mediator;

        public WishListBL(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<WishListEntity> AddBookToWishList(WishListModel model, int Userid)
        {
            var result = await mediator.Send(new AddItemCommand(model.BookId, Userid));
            return result;
        }

        public async Task<bool> DeleteBookFromWishList(int Userid, int bookid)
        {
            var result = await mediator.Send(new RemoveItemCommand(Userid, bookid));
            return result;
        }

        public async Task<List<WishListEntity>> GetAllBooksFromWishList(int Userid)
        {
            var result = await mediator.Send(new GetAllItemsQuery(Userid));
            return result;
        }
    }
}
