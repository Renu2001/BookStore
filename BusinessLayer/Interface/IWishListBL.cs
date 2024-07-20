using ModelLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IWishListBL
    {
        Task<WishListEntity> AddBookToWishList(WishListModel model, int Userid);
        Task<bool> DeleteBookFromWishList(int Userid, int bookid);
        Task<List<WishListEntity>> GetAllBooksFromWishList(int Userid);
    }
}
