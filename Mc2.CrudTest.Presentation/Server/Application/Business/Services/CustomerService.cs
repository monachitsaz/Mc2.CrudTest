using Mc2.CrudTest.Presentation.Server.Application.Services;
using Mc2.CrudTest.Presentation.Server.Infra;
using Mc2.CrudTest.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Application.Business.Services
{
    public class CustomerService : ICustomerService
    {
        readonly CrudTestDbContext _dbContext = new();

        public CustomerService(CrudTestDbContext dbContext)
        {
            this._dbContext = dbContext;

        }
        public CustomerService()
        {

        }

        public async Task<List<Customer>> GetCustomerList()
        {
            try
            {
                return await Task.FromResult(_dbContext.Customers.ToList());
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AddCustomer(Customer customer)
        {
            bool result = true;
            try
            {
                bool isValid = Regex.IsMatch(customer.BankAccountNumber, "((\\d{4})-){3}\\d{4}");

                var phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
                var phone = phoneNumberUtil.Parse(customer.PhoneNumber, null);
                customer.CountryCode = phone.CountryCode;
                customer.NationalNumber = phone.NationalNumber;
                if (isValid)
                {
                    _dbContext.Customers.Add(customer);
                    _dbContext.SaveChanges();
                    result = true;
                }
                else
                {
                    result = false;
                }


            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }


        public Customer GetCustomerData(int id)
        {
            try
            {
                Customer customer = _dbContext.Customers.Find(id);
                if (customer != null)
                {
                    return customer;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void UpdateCustomer(Customer customer)
        {
            try
            {
                bool isValid = Regex.IsMatch(customer.BankAccountNumber, "((\\d{4})-){3}\\d{4}");

                var phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
                var phone = phoneNumberUtil.Parse(customer.PhoneNumber, null);
                customer.CountryCode = phone.CountryCode;
                customer.NationalNumber = phone.NationalNumber;
                _dbContext.Entry(customer).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteCustomer(int id)
        {
            try
            {
                Customer customer = _dbContext.Customers.Find(id);

                _dbContext.Customers.Remove(customer);
                _dbContext.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
