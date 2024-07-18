using MediatR;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Commands.User
{
    public class CreateUserCommand : IRequest<UserEntity>
    {
        public string Name { get; set; }

        public string email { get; set; }

        public long phoneNumber { get; set; }

        public string password { get; set; }

        public string role { get; set; }

        public CreateUserCommand(string Name, string email, long phoneNumber, string password, string role)
        {
            this.Name = Name.ToLower();
            this.email = email.ToLower();
            this.phoneNumber = phoneNumber;
            this.password = password;
            this.role = role.ToLower();
        }
    }
}
