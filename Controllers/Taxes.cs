using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_Web_API.IServices;
using Inventory_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Web_API.Controllers
{
    [ApiExplorerSettings(GroupName = "Taxes CRUD Endpoint")]
    [Route("Inventory/[controller]")]
    [ApiController]
    public class Taxes : Controller
    {
       
        private ITaxService _iTaxService;
        public Taxes(ITaxService iTaxService)
        {
            _iTaxService = iTaxService;
        }

        /// <summary>
        /// Get list for all Taxes.
        /// </summary>
        /// <returns>Get list for all Taxes</returns>
        // GET: Inventory/Taxes
        [HttpGet]
        [Authorize]
        public IEnumerable<Tax> Get()
        {
            return _iTaxService.GetTaxList();
        }

        /// <summary>
        /// Get list for all Tax per Id.
        /// </summary>
        /// <returns>Get list for all Tax</returns>
        // GET: Inventory/Taxes/{taxId}
        [HttpGet("{taxId}")]
        [Authorize]
        public Tax Get(int taxId)
        {
            return _iTaxService.GetTax(taxId);
        }

        /// <summary>
        /// Add/Save New Tax details.
        /// </summary>
        /// <returns></returns>
        // POST: Inventory/Taxes
        [HttpPost]
        [Authorize]
        public Tax Post([FromBody] Tax oTaxes)
        {
            if (ModelState.IsValid)
            {
                return _iTaxService.AddTax(oTaxes);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Update user Tax.
        /// </summary>
        /// <returns></returns>
        // PUT: Inventory/Taxes/{taxId}
        [HttpPut("{taxId}")]
        [Authorize]
        public Tax Put(int taxId, [FromBody] Tax oTaxes)
        {
            if (ModelState.IsValid)
            {
                return _iTaxService.UpdateTax(taxId, oTaxes);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Delete user Tax.
        /// </summary>
        /// <returns></returns>
        // DELETE: Inventory/Taxes/{taxId}
        [HttpDelete("{taxId}")]
        [Authorize]
        public string Delete(int taxId)
        {
            return _iTaxService.Delete(taxId);
        }
    }
}
