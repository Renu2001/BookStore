using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Exceptions;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class CartRL : ICartRL
    {
        private readonly BookStoreContext _bookStoreContext;

        public CartRL(BookStoreContext bookStoreContext)
        {
            _bookStoreContext = bookStoreContext;
        }
        public async Task<CartEntity> AddBookToCart(int quantity, int bookId, int userId)
        {
            try
            {
                var result = _bookStoreContext.Carts.FirstOrDefault(x => x.UserId == userId && x.BookId == bookId);
                if (result != null)
                    throw new CustomException("Book Already Exist in Cart");
                CartEntity cart = new CartEntity()
                {
                    Quantity = quantity,
                    BookId = bookId,
                    UserId = userId
                };
                _bookStoreContext.Carts.Add(cart);
                await _bookStoreContext.SaveChangesAsync();
                return cart;
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message);
            }

        }

        public async Task<List<CartEntity>> GetAllBooksFromCart(int userid)
        {
            try
            {
                var result = await _bookStoreContext.Carts.Where(x => x.UserId == userid).Include(x => x.UserEntity).Include(x => x.BookEntity).ToListAsync();
                if (result == null)
                    throw new CustomException("Nothing Found");
                return result;
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message);
            }
        }

        public async Task<bool> RemoveBookFromCart(int bookId, int userId)
        {
            try
            {
                var result = _bookStoreContext.Carts.FirstOrDefault(x => x.UserId == userId && x.BookId == bookId);
                if (result == null)
                    return false;

                _bookStoreContext.Carts.Remove(result);
                await _bookStoreContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message);
            }
            return true;
        }

        public async Task<CartEntity> UpdateQuantity(int bookId, int quantity, int userId)
        {
            var book = _bookStoreContext.Carts.FirstOrDefault(x => x.Id == bookId && x.UserId == userId);
            if (book == null)
            {
                throw new CustomException("Book Doesnt exists");
            }
            if (book != null)
            {
                book.Quantity = quantity;
                book.UserId = userId;
                book.BookId = bookId;
            }
            _bookStoreContext.Carts.Update(book);
            await _bookStoreContext.SaveChangesAsync();
            return book;
        }
    }
}
