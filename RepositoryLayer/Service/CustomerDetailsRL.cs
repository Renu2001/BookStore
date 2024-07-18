using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Exceptions;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class CustomerDetailsRL : ICustomerDetailsRL
    {
        private readonly BookStoreContext _bookStoreContext;

        public CustomerDetailsRL(BookStoreContext bookStoreContext)
        {
            _bookStoreContext = bookStoreContext;
        }
        public async Task<CustomerDetailsEntity> AddCustomerDetails(CustomerDetailsEntity customerDetailsEntity)
        {
            try
            {
                _bookStoreContext.CustomerDetails.Add(customerDetailsEntity);
                await _bookStoreContext.SaveChangesAsync();
                return customerDetailsEntity;
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message);
            }

        }

        public async Task<List<CustomerDetailsEntity>> GetCustomerDetailsByUserId(int userid)
        {
            try
            {
                var result = await _bookStoreContext.CustomerDetails.Where(x => x.UserEntityId == userid).Include(x => x.Users).ToListAsync();
                if (result == null)
                    throw new CustomException("Nothing Found");
                return result;
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message);
            }
        }
    

        public async Task<bool> RemoveCustomerDetails(string addresstype, int userid)
        {
            try
            {
                var result = _bookStoreContext.CustomerDetails.FirstOrDefault(x => x.UserEntityId == userid && x.AddressType == addresstype);
                if (result == null)
                    return false;

                _bookStoreContext.CustomerDetails.Remove(result);
                await _bookStoreContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message);
            }
            return true;
        }

        public async Task<CustomerDetailsEntity> UpdateCustomerDetails(string address, string city, string state, string addressType, int userid)
        {
            var entity = _bookStoreContext.CustomerDetails.FirstOrDefault(x => x.AddressType == addressType && x.UserEntityId == userid);
            if (entity == null)
            {
                throw new CustomException("Book Doesnt exists");
            }
            if (entity != null)
            {
                entity.Address = address;
                entity.City = city;
                entity.State = state;
                entity.AddressType = addressType;
                entity.UserEntityId = userid;
            }
            _bookStoreContext.CustomerDetails.Update(entity);
            await _bookStoreContext.SaveChangesAsync();
            return entity;
        }
    }
}
