using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_Web_API.IServices;
using Inventory_Web_API.Models.PSGC;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Web_API.Controllers
{
    [ApiExplorerSettings(GroupName = "PSGC CRUD Endpoint")]
    [Route("Inventory/[controller]")]
    [ApiController]
    public class PSGC : Controller
    {
        private IBarangayService _iBarangayService;
        private ICityMunicipalityService _iCityMunicipalityService;
        private IProvinceService _iProvinceService;
        private IRegionService _iRegionService;

        public PSGC(IBarangayService iBarangayService, ICityMunicipalityService iCityMunicipalityService, IProvinceService iProvinceService, IRegionService iRegionService)
        {
            _iBarangayService = iBarangayService;
            _iCityMunicipalityService = iCityMunicipalityService;
            _iProvinceService = iProvinceService;
            _iRegionService = iRegionService;
        }
        #region Barangay
        /// <summary>
        /// Get list of Barangay.
        /// </summary>
        /// <returns>Get list of Barangay</returns>
        // GET: Inventory/PSGC/Barangay
        [Route("Barangay")]
        [HttpGet]
        [Authorize]
        public IEnumerable<Barangay> GetBarangayList()
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
        public Barangay GetBarangay(int barangayId)
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
        public Barangay AddNewBarangay([FromBody] Barangay oBarangay)
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
        public Barangay UpdateBarangay(int barangayId, [FromBody] Barangay oBarangay)
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
        public string DeleteBarangay(int barangayId)
        {
            return _iBarangayService.Delete(barangayId);
        }

        #endregion

        #region CityMunipalities
        /// <summary>
        /// Get list of CityMunicipality.
        /// </summary>
        /// <returns>Get list of CityMunicipality</returns>
        // GET: Inventory/PSGC/CityMunicipality
        [Route("CityMunicipality")]
        [HttpGet]
        [Authorize]
        public IEnumerable<CityMunicipality> GetCityMunicipalityList()
        {
            return _iCityMunicipalityService.GetCityMunicipalities();
        }

        /// <summary>
        /// Get list of all CityMunicipality per Id.
        /// </summary>
        /// <returns>Get list of all CityMunicipality per Id</returns>
        // GET: Inventory/PSGC/CityMunicipality/{id}
        [HttpGet("CityMunicipality/{cityMunicipalityId}")]
        [Authorize]
        public CityMunicipality GetCityMunicipality(int cityMunicipalityId)
        {
            return _iCityMunicipalityService.GetCityMunicipality(cityMunicipalityId);
        }

        /// <summary>
        /// Add/Save New CityMunicipality Details.
        /// </summary>
        /// <returns></returns>
        // POST: Inventory/PSGC/CityMunicipality
        [HttpPost("CityMunicipality")]
        [Authorize]
        public CityMunicipality AddNewCityMunicipality([FromBody] CityMunicipality oCityMunicipality)
        {
            if (ModelState.IsValid)
            {
                return _iCityMunicipalityService.AddCityMunicipality(oCityMunicipality);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Update CityMunicipality details.
        /// </summary>
        /// <returns></returns>
        // PUT: Inventory/PSGC/CityMunicipality/{id}
        [HttpPut("CityMunicipality/{cityMunicipalityId}")]
        [Authorize]
        public CityMunicipality UpdateCityMunicipality(int cityMunicipalityId, [FromBody] CityMunicipality oCityMunicipality)
        {
            if (ModelState.IsValid)
            {
                return _iCityMunicipalityService.UpdateMunicipality(cityMunicipalityId, oCityMunicipality);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Delete CityMunicipality details.
        /// </summary>
        /// <returns></returns>
        // DELETE: Inventory/PSGC/CityMunicipality/{id}
        [HttpDelete("CityMunicipality/{cityMunicipalityId}")]
        [Authorize]
        public string DeleteCityMunicipality(int cityMunicipalityId)
        {
            return _iCityMunicipalityService.Delete(cityMunicipalityId);
        }

        #endregion

        #region Province
        /// <summary>
        /// Get list of Province.
        /// </summary>
        /// <returns>Get list of Province</returns>
        // GET: Inventory/PSGC/Province
        [Route("Province")]
        [HttpGet]
        [Authorize]
        public IEnumerable<Province> GetProvinceList()
        {
            return _iProvinceService.GetProvinceList();
        }

        /// <summary>
        /// Get list of all Province per Id.
        /// </summary>
        /// <returns>Get list of all Province per Id</returns>
        // GET: Inventory/PSGC/Province/{id}
        [HttpGet("Province/{provinceId}")]
        [Authorize]
        public Province GetProvince(int provinceId)
        {
            return _iProvinceService.GetProvince(provinceId);
        }

        /// <summary>
        /// Add/Save New Province Details.
        /// </summary>
        /// <returns></returns>
        // POST: Inventory/PSGC/Province
        [HttpPost("Province")]
        [Authorize]
        public Province AddNewProvince([FromBody] Province oProvince)
        {
            if (ModelState.IsValid)
            {
                return _iProvinceService.AddProvince(oProvince);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Update Province details.
        /// </summary>
        /// <returns></returns>
        // PUT: Inventory/PSGC/Province/{id}
        [HttpPut("Province/{provinceId}")]
        [Authorize]
        public Province UpdateProvince(int provinceId, [FromBody] Province oProvince)
        {
            if (ModelState.IsValid)
            {
                return _iProvinceService.UpdateProvince(provinceId, oProvince);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Delete Province details.
        /// </summary>
        /// <returns></returns>
        // DELETE: Inventory/PSGC/Province/{id}
        [HttpDelete("Province/{provinceId}")]
        [Authorize]
        public string DeleteProvince(int provinceId)
        {
            return _iProvinceService.Delete(provinceId);
        }

        #endregion

        #region Region
        /// <summary>
        /// Get list of Region.
        /// </summary>
        /// <returns>Get list of Region</returns>
        // GET: Inventory/PSGC/Region
        [Route("Region")]
        [HttpGet]
        [Authorize]
        public IEnumerable<Region> GetRegionList()
        {
            return _iRegionService.GetRegionList();
        }

        /// <summary>
        /// Get list of all Region per Id.
        /// </summary>
        /// <returns>Get list of all Region per Id</returns>
        // GET: Inventory/PSGC/Region/{id}
        [HttpGet("Region/{regionId}")]
        [Authorize]
        public Region GetRegion(int regionId)
        {
            return _iRegionService.GetRegion(regionId);
        }

        /// <summary>
        /// Add/Save New Region Details.
        /// </summary>
        /// <returns></returns>
        // POST: Inventory/PSGC/Region
        [HttpPost("Region")]
        [Authorize]
        public Region AddNewRegion([FromBody] Region oRegion)
        {
            if (ModelState.IsValid)
            {
                return _iRegionService.AddRegion(oRegion);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Update Region details.
        /// </summary>
        /// <returns></returns>
        // PUT: Inventory/PSGC/Region/{id}
        [HttpPut("Region/{regionId}")]
        [Authorize]
        public Region UpdateProvince(int regionId, [FromBody] Region oRegion)
        {
            if (ModelState.IsValid)
            {
                return _iRegionService.UpdateRegion(regionId, oRegion);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Delete Region details.
        /// </summary>
        /// <returns></returns>
        // DELETE: Inventory/PSGC/Region/{id}
        [HttpDelete("Region/{regionId}")]
        [Authorize]
        public string DeleteRegion(int regionId)
        {
            return _iRegionService.Delete(regionId);
        }

        #endregion
    }
}
