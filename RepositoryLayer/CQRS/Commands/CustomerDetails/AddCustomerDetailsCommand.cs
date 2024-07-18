using MediatR;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Commands.CustomerDetails
{
    public class AddCustomerDetailsCommand : IRequest<CustomerDetailsEntity>
    {
        public string address {  get; set; }
        public string city {  get; set; }
        public string state {  get; set; }
        public string addressType {  get; set; }
        public int userid {  get; set; }

        public AddCustomerDetailsCommand(string address, string city, string state, string addressType, int userid)
        {
            this.address = address;
            this.city = city;
            this.state = state;
            this.addressType = addressType;
            this.userid = userid;
        }
    }
}
