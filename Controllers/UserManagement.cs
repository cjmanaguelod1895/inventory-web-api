using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_Web_API.IServices;
using Inventory_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Web_API.Controllers
{
    [ApiExplorerSettings(GroupName = "User Management CRUD Endpoint")]
    [Route("Inventory/[controller]")]
    [ApiController]
    public class UserManagement : ControllerBase
    {
        private IUsersService _oUsersService;
        public UserManagement(IUsersService oUsersService)
        {
            _oUsersService = oUsersService;
        }

        /// <summary>
        /// Get list for all Users.
        /// </summary>
        /// <returns>Get list for all Users</returns>
        // GET: Inventory/UserManagement
        [HttpGet]
        [Authorize]
        public IEnumerable<Users> Get()
        {
            return _oUsersService.GetAllUsers();
        }

        /// <summary>
        /// Get list for all user per Id.
        /// </summary>
        /// <returns>Get list for all Users</returns>
        // GET: Inventory/UserManagement/{id}
        [HttpGet("{id}")]
        [Authorize]
        public Users Get(int id)
        {
            return _oUsersService.GetUser(id);
        }

        /// <summary>
        /// Add/Save New user details.
        /// </summary>
        /// <returns></returns>
        // POST: Inventory/UserManagement
        [HttpPost]
        [Authorize]
        public Users Post([FromBody] Users oUsers)
        {
            if (ModelState.IsValid)
            {
                return _oUsersService.AddUser(oUsers);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Update user details.
        /// </summary>
        /// <returns></returns>
        // PUT: Inventory/UserManagement/{id}
        [HttpPut("{id}")]
        [Authorize]
        public Users Put(int id, [FromBody] Users oUsers)
        {
            if (ModelState.IsValid)
            {
                return _oUsersService.UpdateUser(id, oUsers);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Delete user details.
        /// </summary>
        /// <returns></returns>
        // PUT: Inventory/UserManagement/{id}
        // DELETE api/<UserManagement>/5
        [HttpDelete("{id}")]
        [Authorize]
        public string Delete(int id)
        {
            return _oUsersService.Delete(id);
        }
    }
}
