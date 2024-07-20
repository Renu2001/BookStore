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

        public async Task<string> ForgotPassword(string email)
        {
            var result = await mediator.Send(new ForgetPasswordCommand(email));
            return result;
        }

        public async Task<string> Login(LoginModel login)
        {
            var result = await mediator.Send(new GetUserByEmailQuery(login.email,login.password));
            return result;
        }

        public async Task<UserEntity> Register(UserModel model, string role)
        {
            try
            { 
                var password = PasswordHashing.Encrypt(model.Password);
                var result = await mediator.Send(new CreateUserCommand(model.Name,model.Email, model.PhoneNumber, password, role));
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> ResetPassword(string email, string password)
        {
            var result = await mediator.Send(new ResetPasswordCommand(email,password));
            return result;
        }

       
    }
}
