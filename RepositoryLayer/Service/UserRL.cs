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
        //private readonly PasswordHashing hashing;

        public UserRL(BookStoreContext bookStoreContext)
        {
            _bookStoreContext = bookStoreContext;
            //this.hashing = hashing;
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
            var user = _bookStoreContext.Users.FirstOrDefault(u => u.email == email);
            if (user == null) return false;

            var decryptedPassword = PasswordHashing.Decrypt(user.password);
            return decryptedPassword == password;
        }

        public Task<bool> Login(LoginModel login)
        {
            var user = _bookStoreContext.Users.FirstOrDefault(x => x.email == login.email);
            var result = ValidateUser(user.email, login.password);
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
                return Task.FromResult(true);
            }


        }
    }
}
