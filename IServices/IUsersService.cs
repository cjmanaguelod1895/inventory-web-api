using Inventory_Web_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.IServices
{
    public interface IUsersService
    {

        List<Users> GetAllUsers();

        Users GetUser(int userId);

        Users AddUser(Users users);

        Users UpdateUser(int id, Users user);


        string Delete(int id);
    }
}
