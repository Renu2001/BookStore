using ModelLayer;
using RepositoryLayer.DTO;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface ICartBL
    {
        Task<CartEntity> AddBookToCart(CartModel model, int id);
        Task<bool> DeleteBookFromCart(int id,int bookid);
        Task<CartDTO> GetAllBooksFromCart(int id);
        Task<CartEntity> UpdateQuantity(CartModel model, int id);
    }
}
