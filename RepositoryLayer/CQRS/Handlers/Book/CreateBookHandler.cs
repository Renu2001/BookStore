using MediatR;
using RepositoryLayer.CQRS.Commands.Book;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Handlers.Book
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand, BookEntity>
    {
        private readonly IBookRL _bookRL;

        public CreateBookHandler(IBookRL bookRL)
        {
            _bookRL = bookRL;
        }

        public async Task<BookEntity> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
           BookEntity bookEntity = new BookEntity()
           {
               BookName = request.BookName,
               Description = request.Description,
               Price = request.Price,
               DiscountPrice = request.DiscountPrice,
               Quantity = request.Quantity,
               Author=request.Author,
               BookImage=request.BookImage,
               UserEntityId=request.Admin_Id
           };
            var result = await _bookRL.AddBook(bookEntity);
            return result;

        }
    }
}
