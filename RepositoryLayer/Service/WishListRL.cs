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
    public class WishListRL : IWishListRL
    {
        private readonly BookStoreContext _bookStoreContext;

        public WishListRL(BookStoreContext bookStoreContext)
        {
            _bookStoreContext = bookStoreContext;
        }

        public async Task<WishListEntity> AddItemToWishList(int userid, int bookId)
        {
            try
            {
                var result = _bookStoreContext.WishLists.FirstOrDefault(x => x.UserId == userid && x.BookId == bookId);
                if (result != null)
                    throw new CustomException("Book Already Exist in WishList");

                var book = _bookStoreContext.Books.FirstOrDefault(x => x.Id == bookId);
                WishListEntity wishList = new WishListEntity()
                {
                    BookId = bookId,
                    UserId = userid,
                };
                _bookStoreContext.WishLists.Add(wishList);
                await _bookStoreContext.SaveChangesAsync();
                return wishList;
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message);
            }
        }

        public async Task<List<WishListEntity>> GetAllItemsFromWishList(int userid)
        {
            try
            {
                var result = await _bookStoreContext.WishLists.Where(x => x.UserId == userid).Include(x => x.UserEntity).Include(x => x.BookEntity).ToListAsync();
                if (result == null)
                    throw new CustomException("Nothing Found");
                return result;
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message);
            }
        }

        public async Task<bool> RemoveItemFromWishList(int userid, int bookid)
        {
            try
            {
                var result = _bookStoreContext.WishLists.FirstOrDefault(x => x.UserId == userid && x.BookId == bookid);
                if (result == null)
                    return false;

                _bookStoreContext.WishLists.Remove(result);
                await _bookStoreContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message);
            }
            return true;
        }
    }
}
