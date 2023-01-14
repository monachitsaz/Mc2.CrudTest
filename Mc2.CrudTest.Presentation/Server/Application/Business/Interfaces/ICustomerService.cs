using Mc2.CrudTest.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Application.Services
{
    public interface ICustomerService
    {
        public bool AddCustomer(Customer customer);

        public void UpdateCustomer(Customer customer);

        public List<Customer> GetCustomerList();

        public Customer GetCustomerData(int id);

        public void DeleteCustomer(int id);
    }
}
