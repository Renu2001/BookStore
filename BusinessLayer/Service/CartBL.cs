using BusinessLayer.Interface;
using MediatR;
using ModelLayer;
using RepositoryLayer.CQRS.Commands.Book;
using RepositoryLayer.CQRS.Commands.Cart;
using RepositoryLayer.CQRS.Queries.Cart;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class CartBL : ICartBL
    {
        private readonly IMediator mediator;

        public CartBL(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<CartEntity> AddBookToCart(CartModel model, int userid)
        {
            var result = await mediator.Send(new AddBookToCartCommand(model.Quantity,model.BookId,userid));
            return result;
        }

        public async Task<bool> DeleteBookFromCart(int userid, int bookid)
        {
            var result = await mediator.Send(new RemoveBookFromCartCommand(userid,bookid));
            return result;
        }

        public async Task<List<CartEntity>> GetAllBooksFromCart(int userid)
        {
            var result = await mediator.Send(new GetAllBooksByUserIdQuery(userid));
            return result;
        }

        public async Task<CartEntity> UpdateQuantity(CartModel model, int userid)
        {
            var result = await mediator.Send(new UpdateQuantityCommand(model.BookId,model.Quantity,userid));
            return result;
        }
    }
}
