using BusinessLayer.Interface;
using MediatR;
using ModelLayer;
using RepositoryLayer.CQRS.Commands.Cart;
using RepositoryLayer.CQRS.Commands.CustomerDetails;
using RepositoryLayer.CQRS.Queries.CustomerDetails;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class CustomerDetailsBL : ICustomerDetailsBL
    {
        private readonly IMediator mediator;

        public CustomerDetailsBL(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<CustomerDetailsEntity> AddCustomerDetails(CustomerDetailsModel model, int userid)
        {
            var result = await mediator.Send(new AddCustomerDetailsCommand(model.Address, model.City,model.State, model.AddressType,userid));
            return result;
        }

        public async Task<List<CustomerDetailsEntity>> GetCustomerDetails(int userid)
        {
            var result = await mediator.Send(new GetCustomerDetailsQuery(userid));
            return result;
        }

        public async Task<bool> RemoveCustomerDetails(string type, int userid)
        {
            var result = await mediator.Send(new DeleteCustomerDetailsCommand(type, userid));
            return result;
        }

        public async Task<CustomerDetailsEntity> UpdateCustomerDetails(CustomerDetailsModel model, int userid)
        {
            var result = await mediator.Send(new UpdateCustomerDetailsCommand(model.Address, model.City, model.State, model.AddressType, userid));
            return result;
        }
    }
}
