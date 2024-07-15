using MediatR;
using ModelLayer;
using RepositoryLayer.CQRS.Queries.User;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Handlers.User
{
    public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, bool>
    {
        private readonly IUserRL _userRL;

        public GetUserByEmailHandler(IUserRL userRL)
        {
            _userRL = userRL;
        }
        public Task<bool> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var login = new LoginModel()
            {
                email = request.email,
                password = request.password
            };
            var result = _userRL.Login(login);
            return result;
        }
    }
}
