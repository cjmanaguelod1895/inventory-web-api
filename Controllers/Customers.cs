using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_Web_API.IServices;
using Inventory_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Web_API.Controllers
{
    [ApiExplorerSettings(GroupName = "Customers CRUD Endpoint")]
    [Route("Inventory/[controller]")]
    [ApiController]
    public class Customers : Controller
    {
    
        private ICustomerService _oCustomerService;
        public Customers(ICustomerService oCustomerService)
        {
            _oCustomerService = oCustomerService;
        }

        /// <summary>
        /// Get list for all Customers.
        /// </summary>
        /// <returns>Get list for all Customers</returns>
        // GET: Inventory/Customers
        [HttpGet]
        [Authorize]
        public IEnumerable<Customer> Get()
        {
            return _oCustomerService.GetCustomerList();
        }

        /// <summary>
        /// Get list for all Customer per Id.
        /// </summary>
        /// <returns>Get list for all Customer</returns>
        // GET: Inventory/Customers/{customerId}
        [HttpGet("{customerId}")]
        [Authorize]
        public Customer Get(int customerId)
        {
            return _oCustomerService.GetCustomer(customerId);
        }

        /// <summary>
        /// Add/Save New Customers details.
        /// </summary>
        /// <returns></returns>
        // POST: Inventory/Customers
        [HttpPost]
        [Authorize]
        public Customer Post([FromBody] Customer oCustomer)
        {
            if (ModelState.IsValid)
            {
                return _oCustomerService.AddCustomer(oCustomer);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Update user Customer.
        /// </summary>
        /// <returns></returns>
        // PUT: Inventory/Customers/{customerId}
        [HttpPut("{customerId}")]
        [Authorize]
        public Customer Put(int customerId, [FromBody] Customer oCustomer)
        {
            if (ModelState.IsValid)
            {
                return _oCustomerService.UpdateCustomer(customerId, oCustomer);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Delete user Customer.
        /// </summary>
        /// <returns></returns>
        // DELETE: Inventory/Customers/{customerId}
        [HttpDelete("{customerId}")]
        [Authorize]
        public string Delete(int customerId)
        {
            return _oCustomerService.Delete(customerId);
        }
    }
}
