using MediatR;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Commands.WishList
{
    public class AddItemCommand : IRequest<WishListEntity>
    {
        public int bookId;
        public int userid;

        public AddItemCommand(int bookId, int userid)
        {
            this.bookId = bookId;
            this.userid = userid;
        }
    }
}
