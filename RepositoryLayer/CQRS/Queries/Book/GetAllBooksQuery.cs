using MediatR;
using RepositoryLayer.CQRS.Commands.Book;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Queries.Book
{
    public class GetAllBooksQuery : IRequest<List<BookEntity>>
    {
    }
}
