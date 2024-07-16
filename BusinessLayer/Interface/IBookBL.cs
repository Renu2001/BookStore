using ModelLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IBookBL
    {
        Task<BookEntity> Add(BookModel model,int id);
        Task<bool> DeleteBook(int id);
        Task<List<BookEntity>> GetAllBooks();
        Task<BookEntity> GetBookById(int id);
        Task<BookEntity> UpdateBook(int bookId, BookModel model, int id);
    }
}
