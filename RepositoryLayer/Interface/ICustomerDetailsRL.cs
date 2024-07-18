using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface ICustomerDetailsRL
    {
        Task<CustomerDetailsEntity> AddCustomerDetails(CustomerDetailsEntity customerDetailsEntity);
        Task <List<CustomerDetailsEntity>> GetCustomerDetailsByUserId(int userid);
        Task<bool> RemoveCustomerDetails(string addresstype, int userid);
        Task<CustomerDetailsEntity> UpdateCustomerDetails(string address, string city, string state, string addressType, int userid);
    }
}
