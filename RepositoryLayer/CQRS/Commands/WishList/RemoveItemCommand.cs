using MediatR;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Commands.WishList
{
    public class RemoveItemCommand : IRequest<bool>
    {
        public int userid;
        public int bookid;

        public RemoveItemCommand(int userid, int bookid)
        {
            this.userid = userid;
            this.bookid = bookid;
        }
    }
}
