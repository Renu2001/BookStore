using MediatR;
using RepositoryLayer.CQRS.Commands.Book;
using RepositoryLayer.CQRS.Queries.Book;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Handlers.Book
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, BookEntity>
    {
        private readonly IBookRL _bookRL;

        public GetBookByIdHandler(IBookRL bookRL)
        {
            _bookRL = bookRL;
        }

        public async Task<BookEntity> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _bookRL.GetBookById(request.Id);
            return result;
        }
    }
}
