using Mc2.CrudTest.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Application.Services
{
    public interface ICustomerService
    {
        bool AddCustomer(Customer customer);

        void UpdateCustomer(Customer customer);

        List<Customer> GetCustomerList();

        Customer GetCustomerData(int id);

        void DeleteCustomer(int id);
    }
}
