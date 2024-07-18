using MediatR;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Queries.CustomerDetails
{
    public class GetCustomerDetailsQuery : IRequest<List<CustomerDetailsEntity>>
    {
        public int userid {  get; set; }

        public GetCustomerDetailsQuery(int userid)
        {
            this.userid = userid;
        }
    }
}
