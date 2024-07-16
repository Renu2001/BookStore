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
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly IBookRL _bookRL;

        public DeleteBookHandler(IBookRL bookRL)
        {
            _bookRL = bookRL;
        }

        public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var result = await _bookRL.DeleteBook(request.Id);
            return result;
        }
    }
}
