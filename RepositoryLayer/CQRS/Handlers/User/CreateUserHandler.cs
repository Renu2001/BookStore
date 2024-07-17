using MediatR;
using RepositoryLayer.CQRS.Commands.User;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Handlers.User
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserEntity>
    {
        private readonly IUserRL _userRL;

        public CreateUserHandler(IUserRL userRL)
        {
            _userRL = userRL;
        }

        public Task<UserEntity> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            UserEntity userEntity = new UserEntity()
            {
                Name = request.firstName,
                Email = request.email,
                PhoneNumber = request.phoneNumber,
                Password = request.password,
                Roles = request.role
            };
            var result = _userRL.Register(userEntity);
            return result;
        }
    }
}
