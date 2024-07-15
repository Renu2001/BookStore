using ModelLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandService.Interface
{
    public interface IUserCommand
    {
        Task<UserEntity> Add(UserModel model, string role);
    }
}
