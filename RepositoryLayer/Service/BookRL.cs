using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Exceptions;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class BookRL : IBookRL
    {
        private readonly BookStoreContext _bookStoreContext;

        public BookRL(BookStoreContext bookStoreContext)
        {
            _bookStoreContext = bookStoreContext;
        }

        public async Task<BookEntity> AddBook(BookEntity bookEntity)
        {
            try
            {
                _bookStoreContext.Books.Add(bookEntity);
                await _bookStoreContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message);
            }
            return bookEntity;
        }

        public async Task<bool> DeleteBook(int id)
        {
            try
            {
                var result = _bookStoreContext.Books.FirstOrDefault(x=>x.Id == id);
                if (result == null)
                    return false;

                _bookStoreContext.Books.Remove(result);
                await _bookStoreContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message);
            }
            return true;
        }

        public async Task<List<BookEntity>> GetAllBooks()
        {
            try
            {
                var result = await _bookStoreContext.Books.ToListAsync();
                if (result == null)
                    throw new CustomException("No Books Found");
                return result;
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message);
            }
            
        }

        public async Task<BookEntity> GetBookById(int id)
        {
            try
            {
                var result = await _bookStoreContext.Books.FirstOrDefaultAsync(x => x.Id == id);
                if (result == null)
                    throw new CustomException("No Book Found");
                return result;
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message);
            }
            
        }

        public async Task<BookEntity> UpdateBook(int id, BookEntity bookEntity)
        {
            try
            {
               var book = _bookStoreContext.Books.FirstOrDefault(x => x.Id == id);
                if (book == null)
                {
                    throw new CustomException("Book Doesnt exists");
                }
                if (book != null)
                {
                    book.BookName = bookEntity.BookName;
                    book.Description = bookEntity.Description;
                    book.Price = bookEntity.Price;
                    book.DiscountPrice = bookEntity.DiscountPrice;
                    book.Quantity = bookEntity.Quantity;
                    book.Author = bookEntity.Author;
                    book.BookImage = bookEntity.BookImage;
                    book.UserEntityId=bookEntity.UserEntityId;
                }
                 _bookStoreContext.Books.Update(book);
                await _bookStoreContext.SaveChangesAsync();
                return book;
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message);
            }
            
        }
    }
}
