using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_Web_API.IServices;
using Inventory_Web_API.Models;
using Inventory_Web_API.Models.PSGC;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Web_API.Controllers
{
    [ApiExplorerSettings(GroupName = "Unit Of Measures CRUD Endpoint")]
    [Route("Inventory/[controller]")]
    [ApiController]
    public class UnitOfMeasures : Controller
    {
     
        private IUnitOfMeasureService _iUnitOfMeasureService;
        public UnitOfMeasures(IUnitOfMeasureService iUnitOfMeasureService)
        {
            _iUnitOfMeasureService = iUnitOfMeasureService;
        }

        #region Unit Of Measure
        /// <summary>
        /// Get list of Unit Of Measure.
        /// </summary>
        /// <returns>Get list of Unit Of Measure</returns>
        // GET: Inventory/UnitOfMeasures
        [HttpGet]
        [Authorize]
        public IEnumerable<UnitOfMeasure> GetUnitOfMeasureList()
        {
            return _iUnitOfMeasureService.GetUnitOfMeasureList();
        }

        /// <summary>
        /// Get list of all Unit Of Measure per Id.
        /// </summary>
        /// <returns>Get list of all Unit Of Measure per Id</returns>
        // GET: Inventory/UnitOfMeasures/{unitId}
        [HttpGet("{unitId}")]
        [Authorize]
        public UnitOfMeasure GetUnitOfMeasure(int unitId)
        {
            return _iUnitOfMeasureService.GetUnitOfMeasure(unitId);
        }

        /// <summary>
        /// Add/Save New Unit Of Measure Details.
        /// </summary>
        /// <returns></returns>
        // POST: Inventory/UnitOfMeasures
        [HttpPost]
        [Authorize]
        public UnitOfMeasure AddNewUnitOfMeasure([FromBody] UnitOfMeasure oUnitOfMeasure)
        {
            if (ModelState.IsValid)
            {
                return _iUnitOfMeasureService.AddUnitOfMeasure(oUnitOfMeasure);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Update Unit Of Measure details.
        /// </summary>
        /// <returns></returns>
        // PUT: Inventory/UnitOfMeasures/{unitId}
        [HttpPut("{unitId}")]
        [Authorize]
        public UnitOfMeasure UpdateUnitOfMeasure(int unitId, [FromBody] UnitOfMeasure oUnitOfMeasure)
        {
            if (ModelState.IsValid)
            {
                return _iUnitOfMeasureService.UpdateUnitOfMeasure(unitId, oUnitOfMeasure);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Delete Unit Of Measure details.
        /// </summary>
        /// <returns></returns>
        // DELETE: Inventory/UnitOfMeasures/{unitId}
        [HttpDelete("{unitId}")]
        [Authorize]
        public string DeleteUnitOfMeasure(int unitId)
        {
            return _iUnitOfMeasureService.Delete(unitId);
        }

        #endregion

    }
}
