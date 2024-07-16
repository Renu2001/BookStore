using RepositoryLayer.CQRS.Commands.Book;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IBookRL
    {
        Task<BookEntity> AddBook(BookEntity bookEntity);
        Task<bool> DeleteBook(int id);
        Task<List<BookEntity>> GetAllBooks();
        Task<BookEntity> GetBookById(int id);
        Task<BookEntity> UpdateBook(int id, BookEntity bookEntity);
    }
}
