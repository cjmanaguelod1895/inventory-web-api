using Inventory_Web_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.IServices
{
    public interface ICustomerGroupService
    {
        List<CustomerGroup> GetCustomerGroupList();

        CustomerGroup GetCustomerGroup(int customerGroupId);

        CustomerGroup AddCustomerGroup(CustomerGroup customerGroup);

        CustomerGroup UpdateCustomerGroup(int customerGroupId, CustomerGroup customerGroup);


        string Delete(int customerGroupId);
    }
}
