using Inventory_Web_API.IServices;
using Inventory_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.Controllers
{
    [ApiExplorerSettings(GroupName = "Roles CRUD Endpoint")]
    [Route("Inventory/[controller]")]
    [ApiController]
    public class Roles : Controller
    {
        private IRoleService _iRoleService;
        public Roles(IRoleService iRoleService)
        {
            _iRoleService = iRoleService;
        }

        /// <summary>
        /// Get list for all Roles.
        /// </summary>
        /// <returns>Get list for all Roles</returns>
        // GET: Inventory/Roles
        [HttpGet]
        [Authorize]
        public IEnumerable<Role> Get()
        {
            return _iRoleService.GetRoleList();
        }

        /// <summary>
        /// Get list for all Role per Id.
        /// </summary>
        /// <returns>Get list for all Role</returns>
        // GET: Inventory/Roles/{roleId}
        [HttpGet("{roleId}")]
        [Authorize]
        public Role Get(int roleId)
        {
            return _iRoleService.GetRole(roleId);
        }

        /// <summary>
        /// Add/Save New Role details.
        /// </summary>
        /// <returns></returns>
        // POST: Inventory/Roles
        [HttpPost]
        [Authorize]
        public Role Post([FromBody] Role oRole)
        {
            if (ModelState.IsValid)
            {
                return _iRoleService.AddRole(oRole);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Update user Role.
        /// </summary>
        /// <returns></returns>
        // PUT: Inventory/Roles/{roleId}
        [HttpPut("{roleId}")]
        [Authorize]
        public Role Put(int roleId, [FromBody] Role oRole)
        {
            if (ModelState.IsValid)
            {
                return _iRoleService.UpdateRole(roleId, oRole);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Delete user Role.
        /// </summary>
        /// <returns></returns>
        // DELETE: Inventory/Roles/{roleId}
        [HttpDelete("{roleId}")]
        [Authorize]
        public string Delete(int roleId)
        {
            return _iRoleService.Delete(roleId);
        }
    }
}
