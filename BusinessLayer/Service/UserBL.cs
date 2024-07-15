using BusinessLayer.Interface;
using MediatR;
using ModelLayer;
using RepositoryLayer.CQRS.Commands.User;
using RepositoryLayer.CQRS.Queries.User;
using RepositoryLayer.Entity;
using RepositoryLayer.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class UserBL : IUserBL
    {
        private readonly IMediator mediator;

        public UserBL(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Login(LoginModel login)
        {
            var result = await mediator.Send(new GetUserByEmailQuery(login.email,login.password));
            return result;
        }

        public async Task<UserEntity> Register(UserModel model, string role)
        {
            try
            { 
                var password = PasswordHashing.Encrypt(model.password);
                var result = await mediator.Send(new CreateUserCommand(model.firstName,model.lastName,model.email, model.phoneNumber, password, role));
                return result;
            }
            catch
            {
                throw;
            }
        }

        //public async Task<bool> Login(LoginModel login)
        //{
        //    try
        //    {
        //        var result = await _userQuery.Log(login);
        //        return result;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
    }
}
