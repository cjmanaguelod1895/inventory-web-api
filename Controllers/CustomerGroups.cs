using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_Web_API.IServices;
using Inventory_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Web_API.Controllers
{
    [ApiExplorerSettings(GroupName = "Customer Groups CRUD Endpoint")]
    [Route("Inventory/[controller]")]
    [ApiController]
    public class CustomerGroups : Controller
    {
        private ICustomerGroupService _oCustomerGroupService;
        public CustomerGroups(ICustomerGroupService oCustomerGroupService)
        {
            _oCustomerGroupService = oCustomerGroupService;
        }

        /// <summary>
        /// Get list for all CustomerGroups.
        /// </summary>
        /// <returns>Get list for all CustomerGroups</returns>
        // GET: Inventory/CustomerGroups
        [HttpGet]
        [Authorize]
        public IEnumerable<CustomerGroup> Get()
        {
            return _oCustomerGroupService.GetCustomerGroupList();
        }

        /// <summary>
        /// Get list for all CustomerGroup per Id.
        /// </summary>
        /// <returns>Get list for all CustomerGroup</returns>
        // GET: Inventory/CustomerGroups/{customerGroupId}
        [HttpGet("{customerGroupId}")]
        [Authorize]
        public CustomerGroup Get(int customerGroupId)
        {
            return _oCustomerGroupService.GetCustomerGroup(customerGroupId);
        }

        /// <summary>
        /// Add/Save New CustomerGroup details.
        /// </summary>
        /// <returns></returns>
        // POST: Inventory/CustomerGroup
        [HttpPost]
        [Authorize]
        public CustomerGroup Post([FromBody] CustomerGroup oCustomerGroup)
        {
            if (ModelState.IsValid)
            {
                return _oCustomerGroupService.AddCustomerGroup(oCustomerGroup);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Update user CustomerGroup.
        /// </summary>
        /// <returns></returns>
        // PUT: Inventory/CustomerGroups/{customerGroupId}
        [HttpPut("{customerGroupId}")]
        [Authorize]
        public CustomerGroup Put(int customerGroupId, [FromBody] CustomerGroup oCustomerGroup)
        {
            if (ModelState.IsValid)
            {
                return _oCustomerGroupService.UpdateCustomerGroup(customerGroupId, oCustomerGroup);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Delete user CustomerGroup.
        /// </summary>
        /// <returns></returns>
        // DELETE: Inventory/CustomerGroups/{customerGroupId}
        [HttpDelete("{customerGroupId}")]
        [Authorize]
        public string Delete(int customerGroupId)
        {
            return _oCustomerGroupService.Delete(customerGroupId);
        }
    }
}
