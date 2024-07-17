using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface ICartRL
    {
        Task<CartEntity> AddBookToCart(int quantity, int bookId, int userId);
        Task<List<CartEntity>> GetAllBooksFromCart(int userid);
        Task<bool> RemoveBookFromCart(int bookId, int userId);
        Task<CartEntity> UpdateQuantity(int bookId, int quantity, int userId);
    }
}
