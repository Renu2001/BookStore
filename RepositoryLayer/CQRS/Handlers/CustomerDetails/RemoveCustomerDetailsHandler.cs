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
    public class RemoveCustomerDetailsHandler : IRequestHandler<DeleteCustomerDetailsCommand, bool>
    {
        private readonly ICustomerDetailsRL _customerDetailsRL;

        public RemoveCustomerDetailsHandler(ICustomerDetailsRL customerDetailsRL)
        {
            _customerDetailsRL = customerDetailsRL;
        }
        public async Task<bool> Handle(DeleteCustomerDetailsCommand request, CancellationToken cancellationToken)
        {
            var result = await _customerDetailsRL.RemoveCustomerDetails(request.addresstype, request.userid);
            return result;
        }
    }
}
