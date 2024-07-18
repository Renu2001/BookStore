using MediatR;
using RepositoryLayer.CQRS.Commands.CustomerDetails;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Handlers.CustomerDetails
{
    public class AddCustomerDetailsHandler : IRequestHandler<AddCustomerDetailsCommand, CustomerDetailsEntity>
    {
        private readonly ICustomerDetailsRL _customerDetailsRL;

        public AddCustomerDetailsHandler(ICustomerDetailsRL customerDetailsRL)
        {
            _customerDetailsRL = customerDetailsRL;
        }

        public async Task<CustomerDetailsEntity> Handle(AddCustomerDetailsCommand request, CancellationToken cancellationToken)
        {
            var customerDetailsEntity = new CustomerDetailsEntity()
            {
                Address = request.address,
                City = request.city,
                State = request.state,
                AddressType = request.addressType,
                UserEntityId = request.userid
            };
            var result =  await _customerDetailsRL.AddCustomerDetails(customerDetailsEntity);
            return result;

        }
    }
}
