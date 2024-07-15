using MediatR;
using ModelLayer;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Queries.User
{
    public class GetUserByEmailQuery : IRequest<string>
    {
        public string email { get; set; }
        public string password { get; set; }

        public GetUserByEmailQuery(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

    }
}
