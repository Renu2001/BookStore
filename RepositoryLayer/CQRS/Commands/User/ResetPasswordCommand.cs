using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Commands.User
{
    public class ResetPasswordCommand : IRequest<bool>
    {
        public string email;
        public string password;

        public ResetPasswordCommand(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
    }
}
