using MediatR;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Queries.WishList
{
    public class GetAllItemsQuery : IRequest<List<WishListEntity>>
    {
        public int userid;

        public GetAllItemsQuery(int userid)
        {
            this.userid = userid;
        }
    }
}
