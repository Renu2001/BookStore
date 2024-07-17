using MediatR;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Queries.Cart
{
    public class GetAllBooksByUserIdQuery : IRequest <List<CartEntity>>
    {
        public int Userid { get; set; }

        public GetAllBooksByUserIdQuery(int userid)
        {
            Userid = userid;
        }
    }
}
