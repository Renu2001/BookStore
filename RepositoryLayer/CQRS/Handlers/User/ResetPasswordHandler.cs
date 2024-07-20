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
    public class ResetPasswordHandler : IRequestHandler<ResetPasswordCommand, bool>
    {
        private readonly IUserRL _userRL;

        public ResetPasswordHandler(IUserRL userRL)
        {
            _userRL = userRL;
        }

        public async Task<bool> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRL.ResetPassword(request.email, request.password);
            return result;
        }
    }
}
