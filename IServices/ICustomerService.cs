using Inventory_Web_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.IServices
{
    public interface ICustomerService
    {
        List<Customer> GetCustomerList();

        Customer GetCustomer(int customerId);

        Customer AddCustomer(Customer customer);

        Customer UpdateCustomer(int customerId, Customer customer);


        string Delete(int customerId);
    }
}
