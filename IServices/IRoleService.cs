using Inventory_Web_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.IServices
{
    public interface IRoleService
    {
        List<Role> GetRoleList();

        Role GetRole(int roleId);

        Role AddRole(Role role);

        Role UpdateRole(int roleId, Role role);


        string Delete(int roleId);
    }
}
