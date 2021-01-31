using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_Web_API.IServices;
using Inventory_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Web_API.Controllers
{
    [ApiExplorerSettings(GroupName = "Billers CRUD Endpoint")]
    [Route("Inventory/[controller]")]
    [ApiController]
    public class Billers : Controller
    {
        private IBillerService _oBillerService;
        public Billers(IBillerService oBillerService)
        {
            _oBillerService = oBillerService;
        }

        /// <summary>
        /// Get list for all Billers.
        /// </summary>
        /// <returns>Get list for all Billers</returns>
        // GET: Inventory/Billers
        [HttpGet]
        [Authorize]
        public IEnumerable<Biller> Get()
        {
            return _oBillerService.GetBillerList();
        }

        /// <summary>
        /// Get list for all Biller per Id.
        /// </summary>
        /// <returns>Get list for all Biller</returns>
        // GET: Inventory/Billers/{billerId}
        [HttpGet("{billerId}")]
        [Authorize]
        public Biller Get(int billerId)
        {
            return _oBillerService.GetBiller(billerId);
        }

        /// <summary>
        /// Add/Save New Billers details.
        /// </summary>
        /// <returns></returns>
        // POST: Inventory/Billers
        [HttpPost]
        [Authorize]
        public Biller Post([FromBody] Biller oBiller)
        {
            if (ModelState.IsValid)
            {
                return _oBillerService.AddBiller(oBiller);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Update user Biller.
        /// </summary>
        /// <returns></returns>
        // PUT: Inventory/Billers/{billerId}
        [HttpPut("{billerId}")]
        [Authorize]
        public Biller Put(int billerId, [FromBody] Biller oBiller)
        {
            if (ModelState.IsValid)
            {
                return _oBillerService.UpdateBiller(billerId, oBiller);
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
        // DELETE: Inventory/Biller/{billerId}
        [HttpDelete("{billerId}")]
        [Authorize]
        public string Delete(int billerId)
        {
            return _oBillerService.Delete(billerId);
        }
    }
}
