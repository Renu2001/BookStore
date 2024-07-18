using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Commands.CustomerDetails
{
    public class DeleteCustomerDetailsCommand : IRequest<bool>
    {
        public string addresstype {  get; set; }
        public int userid {  get; set; }

        public DeleteCustomerDetailsCommand(string addresstype, int userid)
        {
            this.addresstype = addresstype;
            this.userid = userid;
        }
    }
}
