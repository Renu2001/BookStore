using MediatR;
using RepositoryLayer.CQRS.Commands.User;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Handlers.User
{
    internal class ForgetPasswordHandler : IRequestHandler<ForgetPasswordCommand, string>
    {
        private readonly IUserRL _userRL;

        public ForgetPasswordHandler(IUserRL userRL)
        {
            _userRL = userRL;
        }

        public async Task<string> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRL.ForgotPassword(request.Email);
            return result;
        }
    }
}
