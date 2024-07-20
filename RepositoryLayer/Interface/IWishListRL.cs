using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IWishListRL
    {
        Task<WishListEntity> AddItemToWishList(int userid, int bookId);
        Task<List<WishListEntity>> GetAllItemsFromWishList(int userid);
        Task<bool> RemoveItemFromWishList(int userid, int bookid);
    }
}
