using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class WishListModel
    {
        public int BookId { get; set; }

        public WishListModel(int bookId)
        {
            BookId = bookId;
        }
    }
}
