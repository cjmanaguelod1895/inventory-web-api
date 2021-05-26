using Inventory_Web_API.IServices;
using Inventory_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.Controllers
{

    [ApiExplorerSettings(GroupName = "General Settings Get and Update Endpoint")]
    [Route("Inventory/[controller]")]
    [ApiController]
    public class GeneralSetting : Controller
    {
        private IGeneralSettings _oGeneralSettingsService;

        public GeneralSetting(IGeneralSettings oGeneralSettingsService)
        {
            _oGeneralSettingsService = oGeneralSettingsService;

        }

        /// <summary>
        /// Get list for all GeneralSettings.
        /// </summary>
        /// <returns>Get list for all GeneralSettings</returns>
        // GET: Inventory/GeneralSettings
        [HttpGet]
        [Authorize]
        public GeneralSettings Get()
        {
            return _oGeneralSettingsService.GetGeneralSettings() ;
        }

        /// <summary>
        /// Update General Settings.
        /// </summary>
        /// <returns></returns>
        // PUT: Inventory/GeneralSettings/{id}
        [HttpPut("{id}")]
        [Authorize]
        public GeneralSettings Put(int id, [FromForm] GeneralSettings oGeneralSettings)
        {
            if (ModelState.IsValid)
            {
                return _oGeneralSettingsService.UpdateGeneralSettings(oGeneralSettings);
            }
            else
            {
                return null;
            }
        }
    }
}
