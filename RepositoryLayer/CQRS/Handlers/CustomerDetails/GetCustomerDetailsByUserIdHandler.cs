using MediatR;
using RepositoryLayer.CQRS.Queries.CustomerDetails;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Handlers.CustomerDetails
{
    public class GetCustomerDetailsByUserIdHandler : IRequestHandler<GetCustomerDetailsQuery, List<CustomerDetailsEntity>>
    {
        private readonly ICustomerDetailsRL _customerDetailsRL;

        public GetCustomerDetailsByUserIdHandler(ICustomerDetailsRL customerDetailsRL)
        {
            _customerDetailsRL = customerDetailsRL;
        }
        public async Task<List<CustomerDetailsEntity>> Handle(GetCustomerDetailsQuery request, CancellationToken cancellationToken)
        {
            var result = await _customerDetailsRL.GetCustomerDetailsByUserId(request.userid);
            return result;
        }
    }
}
