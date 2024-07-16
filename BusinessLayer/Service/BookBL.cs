using BusinessLayer.Interface;
using MediatR;
using ModelLayer;
using RepositoryLayer.CQRS.Commands.Book;
using RepositoryLayer.CQRS.Queries.Book;
using RepositoryLayer.CQRS.Queries.User;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class BookBL : IBookBL
    {
        private readonly IMediator mediator;

        public BookBL(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<BookEntity> Add(BookModel model, int id)
        {
            var result = await mediator.Send(new CreateBookCommand(model.bookName,model.description,model.price,model.discountPrice,model.quantity,model.author,model.bookImage,id));
            return result;
        }

        public async Task<bool> DeleteBook(int id)
        {
            var result = await mediator.Send(new DeleteBookCommand(id));
            return result;
        }

        public async Task<List<BookEntity>> GetAllBooks()
        {
            var result = await mediator.Send(new GetAllBooksQuery());
            return result;
        }

        public async Task<BookEntity> GetBookById(int id)
        {
            var result = await mediator.Send(new GetBookByIdQuery(id));
            return result;
        }

        public async Task<BookEntity> UpdateBook(int bookId, BookModel model, int id)
        {
            var result = await mediator.Send(new UpdateBookCommand(bookId,model.bookName, model.description, model.price, model.discountPrice, model.quantity, model.author, model.bookImage, id));
            return result;
        }
    }
}
