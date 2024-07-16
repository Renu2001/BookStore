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
    public class CreateBookHandler : IRequestHandler<CreateBookCommand, BookEntity>
    {
        private readonly IBookRL _bookRL;

        public CreateBookHandler(IBookRL bookRL)
        {
            _bookRL = bookRL;
        }

        public Task<BookEntity> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
           BookEntity bookEntity = new BookEntity()
           {
               bookName = request.BookName,
               description = request.Description,
               price = request.Price,
               discountPrice = request.DiscountPrice,
               quantity = request.Quantity,
               author=request.Author,
               bookImage=request.BookImage,
               UserEntityId=request.Admin_Id

           };


        }
    }
}
