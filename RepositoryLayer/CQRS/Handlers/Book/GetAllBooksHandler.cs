using MediatR;
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
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, List<BookEntity>>
    {
        private readonly IBookRL _bookRL;

        public GetAllBooksHandler(IBookRL bookRL)
        {
            _bookRL = bookRL;
        }

        public async Task<List<BookEntity>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var result = await _bookRL.GetAllBooks();
            return result;
        }
    }
}
