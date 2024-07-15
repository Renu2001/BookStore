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
        public string firstName { get; set; }

        public string lastName { get; set; }

        public string email { get; set; }

        public long phoneNumber { get; set; }

        public string password { get; set; }

        public string role { get; set; }

        public CreateUserCommand(string firstName, string lastName, string email, long phoneNumber, string password, string role)
        {
            this.firstName = firstName.ToLower();
            this.lastName = lastName.ToLower();
            this.email = email.ToLower();
            this.phoneNumber = phoneNumber;
            this.password = password;
            this.role = role.ToLower();
        }
    }
}
