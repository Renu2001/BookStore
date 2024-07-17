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


        public UserRL(BookStoreContext bookStoreContext, Token token)
        {
            _bookStoreContext = bookStoreContext;
            _token = token;
        }

        public async Task<UserEntity> Register(UserEntity entity)
        {
            try
            {
                _bookStoreContext.Users.Add(entity);
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
    }
}
