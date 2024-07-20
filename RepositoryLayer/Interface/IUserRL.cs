﻿using ModelLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        Task<string> ForgotPassword(string email);
        Task<string> Login(LoginModel login);
        Task<UserEntity> Register(UserEntity model);
        Task<bool> ResetPassword(string email, string password);
    }
}
