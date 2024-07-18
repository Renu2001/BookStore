using ModelLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface ICustomerDetailsBL
    {
        Task<CustomerDetailsEntity> AddCustomerDetails(CustomerDetailsModel model, int userid);
        Task<List<CustomerDetailsEntity>> GetCustomerDetails(int userid);
        Task<bool> RemoveCustomerDetails(string type, int userid);
        Task<CustomerDetailsEntity> UpdateCustomerDetails(CustomerDetailsModel model, int userid);
    }
}
