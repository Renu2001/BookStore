using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryService.Interface
{
    public interface IUserQuery
    {
        Task<bool> Log(LoginModel login);
    }
}
