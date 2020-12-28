using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_Web_API.IServices;
using Inventory_Web_API.Models.PSGC;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Web_API.Controllers
{
    [Route("Inventory/[controller]")]
    [ApiController]
    public class PSGC : Controller
    {
        private IBarangayService _iBarangayService;

        public PSGC(IBarangayService iBarangayService)
        {
            _iBarangayService = iBarangayService;
        }

        /// <summary>
        /// Get list of Barangay.
        /// </summary>
        /// <returns>Get list of Barangay</returns>
        // GET: Inventory/PSGC/Barangay
        [Route("Barangay")]
        [HttpGet]
        [Authorize]
        public IEnumerable<Barangay> Get()
        {
            return _iBarangayService.GetBarangayList();
        }

        /// <summary>
        /// Get list of all Barangay per Id.
        /// </summary>
        /// <returns>Get list of all Barangay per Id</returns>
        // GET: Inventory/PSGC/Barangay/{id}
        [HttpGet("Barangay/{barangayId}")]
        [Authorize]
        public Barangay Get(int barangayId)
        {
            return _iBarangayService.GetBarangay(barangayId);
        }

        /// <summary>
        /// Add/Save New Barangay Details.
        /// </summary>
        /// <returns></returns>
        // POST: Inventory/PSGC/Barangay
        [HttpPost("Barangay")]
        [Authorize]
        public Barangay Post([FromBody] Barangay oBarangay)
        {
            if (ModelState.IsValid)
            {
                return _iBarangayService.AddBarangay(oBarangay);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Update Barangay details.
        /// </summary>
        /// <returns></returns>
        // PUT: Inventory/PSGC/Barangay/{id}
        [HttpPut("Barangay/{barangayId}")]
        [Authorize]
        public Barangay Put(int barangayId, [FromBody] Barangay oBarangay)
        {
            if (ModelState.IsValid)
            {
                return _iBarangayService.UpdateBarangay(barangayId, oBarangay);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Delete Barangay details.
        /// </summary>
        /// <returns></returns>
        // DELETE: Inventory/PSGC/Barangay/{id}
        [HttpDelete("Barangay/{barangayId}")]
        [Authorize]
        public string Delete(int barangayId)
        {
            return _iBarangayService.Delete(barangayId);
        }
    }
}
