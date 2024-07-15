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
                firstName = request.firstName,
                lastName = request.lastName,
                email = request.email,
                phoneNumber = request.phoneNumber,
                password = request.password,
                roles = request.role
            };
            var result = _userRL.Register(userEntity);
            return result;
        }
    }
}
