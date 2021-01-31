using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_Web_API.IServices;
using Inventory_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Web_API.Controllers
{
    [ApiExplorerSettings(GroupName = "WareHouse CRUD Endpoint")]
    [Route("Inventory/[controller]")]
    [ApiController]
    public class WareHouses : Controller
    {
        private IWareHouseService _oWareHouseService;
        public WareHouses(IWareHouseService oWareHouseService)
        {
            _oWareHouseService = oWareHouseService;
        }

        /// <summary>
        /// Get list for all WareHouse.
        /// </summary>
        /// <returns>Get list for all WareHouse</returns>
        // GET: Inventory/WareHouses
        [HttpGet]
        [Authorize]
        public IEnumerable<WareHouse> Get()
        {
            return _oWareHouseService.GetWareHouseList();
        }

        /// <summary>
        /// Get list for all WareHouse per Id.
        /// </summary>
        /// <returns>Get list for all WareHouse</returns>
        // GET: Inventory/WareHouses/{wareHouseId}
        [HttpGet("{wareHouseId}")]
        [Authorize]
        public WareHouse Get(int wareHouseId)
        {
            return _oWareHouseService.GetWareHouse(wareHouseId);
        }

        /// <summary>
        /// Add/Save New WareHouse details.
        /// </summary>
        /// <returns></returns>
        // POST: Inventory/WareHouses
        [HttpPost]
        [Authorize]
        public WareHouse Post([FromBody] WareHouse oWareHouse)
        {
            if (ModelState.IsValid)
            {
                return _oWareHouseService.AddWareHouse(oWareHouse);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Update user WareHouse.
        /// </summary>
        /// <returns></returns>
        // PUT: Inventory/WareHouses/{wareHouseId}
        [HttpPut("{wareHouseId}")]
        [Authorize]
        public WareHouse Put(int wareHouseId, [FromBody] WareHouse oWareHouse)
        {
            if (ModelState.IsValid)
            {
                return _oWareHouseService.UpdateWareHouse(wareHouseId, oWareHouse);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Delete user WareHouse.
        /// </summary>
        /// <returns></returns>
        // DELETE: Inventory/WareHouses/{wareHouseId}
        [HttpDelete("{wareHouseId}")]
        [Authorize]
        public string Delete(int wareHouseId)
        {
            return _oWareHouseService.Delete(wareHouseId);
        }
    }
}
