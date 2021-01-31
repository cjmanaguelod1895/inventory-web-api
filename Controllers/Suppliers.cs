using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_Web_API.IServices;
using Inventory_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Web_API.Controllers
{
    [ApiExplorerSettings(GroupName = "Suppliers CRUD Endpoint")]
    [Route("Inventory/[controller]")]
    [ApiController]
    public class Suppliers : Controller
    {
        private ISupplierService _oSupplierService;
        public Suppliers(ISupplierService oSupplierService)
        {
            _oSupplierService = oSupplierService;
        }

        /// <summary>
        /// Get list for all Suppliers.
        /// </summary>
        /// <returns>Get list for all Suppliers</returns>
        // GET: Inventory/Suppliers
        [HttpGet]
        [Authorize]
        public IEnumerable<Supplier> Get()
        {
            return _oSupplierService.GetSupplierList();
        }

        /// <summary>
        /// Get list for all Supplier per Id.
        /// </summary>
        /// <returns>Get list for all Supplier</returns>
        // GET: Inventory/Suppliers/{supplierId}
        [HttpGet("{supplierId}")]
        [Authorize]
        public Supplier Get(int supplierId)
        {
            return _oSupplierService.GetSupplier(supplierId);
        }

        /// <summary>
        /// Add/Save New Suppliers details.
        /// </summary>
        /// <returns></returns>
        // POST: Inventory/Supplier
        [HttpPost]
        [Authorize]
        public Supplier Post([FromBody] Supplier oSupplier)
        {
            if (ModelState.IsValid)
            {
                return _oSupplierService.AddSupplier(oSupplier);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Update user Supplier.
        /// </summary>
        /// <returns></returns>
        // PUT: Inventory/Billers/{supplierId}
        [HttpPut("{supplierId}")]
        [Authorize]
        public Supplier Put(int supplierId, [FromBody] Supplier oSupplier)
        {
            if (ModelState.IsValid)
            {
                return _oSupplierService.UpdateSupplier(supplierId, oSupplier);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Delete user Biller.
        /// </summary>
        /// <returns></returns>
        // DELETE: Inventory/Biller/{supplierId}
        [HttpDelete("{supplierId}")]
        [Authorize]
        public string Delete(int supplierId)
        {
            return _oSupplierService.Delete(supplierId);
        }
    }
}
