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
    public class UpdateCustomerDetailsHandler : IRequestHandler<UpdateCustomerDetailsCommand, CustomerDetailsEntity>
    {
        private readonly ICustomerDetailsRL _customerDetailsRL;

        public UpdateCustomerDetailsHandler(ICustomerDetailsRL customerDetailsRL)
        {
            _customerDetailsRL = customerDetailsRL;
        }
        public async Task<CustomerDetailsEntity> Handle(UpdateCustomerDetailsCommand request, CancellationToken cancellationToken)
        {
            var result = await _customerDetailsRL.UpdateCustomerDetails(request.address, request.city, request.state, request.addressType, request.userid);
            return result;
        }
    }
}
