using Microsoft.EntityFrameworkCore;
using ModelLayer;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Exceptions;
using RepositoryLayer.Interface;
using RepositoryLayer.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class UserRL : IUserRL
    {
        private readonly BookStoreContext _bookStoreContext;
        private readonly Token _token;
        private readonly Email _email;

        public UserRL(BookStoreContext bookStoreContext, Token token, Email email)
        {
            _bookStoreContext = bookStoreContext;
            _token = token;
            _email = email;
        }

        public async Task<UserEntity> Register(UserEntity entity)
        {
            try
            {
                var userEntity = await _bookStoreContext.Users.FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (userEntity != null)
                    throw new CustomException("Email Id Exists Please Login!!");
                _bookStoreContext.Users.Add(entity);
                _email.SendRegisterMail(entity);
                await _bookStoreContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message);
            }
            return entity;
        }

        public bool ValidateUser(string email, string password)
        {
            var user = _bookStoreContext.Users.FirstOrDefault(u => u.Email == email);
            if (user == null) return false;

            string decryptedPassword = PasswordHashing.Decrypt(user.Password);
            Console.WriteLine($"password : {password}");
            Console.WriteLine($"Derypted pass : {decryptedPassword}");
            Console.WriteLine($"Boolean: {decryptedPassword == password}");
            return (decryptedPassword == password);
        }

        public Task<string> Login(LoginModel login)
        {
            var user = _bookStoreContext.Users.FirstOrDefault(x => x.Email == login.email);
            var result = ValidateUser(user.Email, login.password);
            if (user == null)
            {
                throw new CustomException("User does not exist. Please register first.");
            }
            else if (!result)
            {
                throw new CustomException("Invalid Email or Password");
            }
            else
            {
                var token = _token.GenerateToken(user);
                return Task.FromResult(token);
            }


        }

        public async Task<string> ForgotPassword(string email)
        {
            var result = await _bookStoreContext.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (result == null)
                throw new CustomException("Enter Valid Email");

            _email.SendResetMail(email,result);
            return "Email Send SuccessFully";
        }

        public async Task<bool> ResetPassword(string email, string password)
        {
            var result = await _bookStoreContext.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (result != null)
            {
                result.Password = PasswordHashing.Encrypt(password);
                _bookStoreContext.Users.Update(result);
                _bookStoreContext.SaveChanges();
               
            }
            else
            {
                throw new CustomException("Email is not valid");
            }
            return true;
        }
    }
}
