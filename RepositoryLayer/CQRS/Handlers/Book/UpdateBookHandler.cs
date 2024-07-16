using MediatR;
using RepositoryLayer.CQRS.Commands.Book;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Handlers.Book
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, BookEntity>
    {
        private readonly IBookRL _bookRL;

        public UpdateBookHandler(IBookRL bookRL)
        {
            _bookRL = bookRL;
        }

        public async Task<BookEntity> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            BookEntity bookEntity = new BookEntity()
            {
                bookName = request.BookName,
                description = request.Description,
                price = request.Price,
                discountPrice = request.DiscountPrice,
                quantity = request.Quantity,
                author = request.Author,
                bookImage = request.BookImage,
                UserEntityId = request.Admin_Id
            };
            var result = await _bookRL.UpdateBook(request.Id,bookEntity);
            return result;

        }
    }
}
