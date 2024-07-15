using CommandService.Interface;
using ModelLayer;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandService.Handlers
{
    public class UserCommand : IUserCommand
    {
        private readonly IUserRL _userRL;

        public UserCommand(IUserRL userRL)
        {
            _userRL = userRL;
        }

        public async Task<UserEntity> Add(UserModel model, string role)
        {
            try
            {
                var result = await _userRL.Register(model, role);
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
