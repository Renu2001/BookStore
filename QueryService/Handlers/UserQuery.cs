using ModelLayer;
using QueryService.Interface;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryService.Handlers
{
    public class UserQuery : IUserQuery
    {
        private readonly IUserRL _userRL;

        public UserQuery(IUserRL userRL)
        {
            _userRL = userRL;
        }
        public async Task<bool> Log(LoginModel login)
        {
            try
            {
                var result = await _userRL.Login(login);
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
