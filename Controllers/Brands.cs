using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_Web_API.IServices;
using Inventory_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Web_API.Controllers
{
    [ApiExplorerSettings(GroupName = "Brand CRUD Endpoint")]
    [Route("Inventory/[controller]")]
    [ApiController]
    public class Brands : Controller
    {
        private IBrandService _iBrandService;
        public Brands(IBrandService iBrandService)
        {
            _iBrandService = iBrandService;
        }

        #region Brands
        /// <summary>
        /// Get list of Brands.
        /// </summary>
        /// <returns>Get list of Brands</returns>
        // GET: Inventory/Brands
        [HttpGet]
        [Authorize]
        public IEnumerable<Brand> GetBrandList()
        {
            return _iBrandService.GetBrandList();
        }

        /// <summary>
        /// Get list of all Brand per Id.
        /// </summary>
        /// <returns>Get list of all Brands per Id</returns>
        // GET: Inventory/{brandId}
        [HttpGet("{brandId}")]
        [Authorize]
        public Brand GetBrand(int brandId)
        {
            return _iBrandService.GetBrand(brandId);
        }

        /// <summary>
        /// Add/Save New Brand Details.
        /// </summary>
        /// <returns></returns>
        // POST: Inventory/Brand
        [HttpPost]
        [Authorize]
        public Brand AddNewBrand([FromForm] Brand oBrand)
        {
            if (ModelState.IsValid)
            {
                return _iBrandService.AddBrand(oBrand);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Update Brand details.
        /// </summary>
        /// <returns></returns>
        // PUT: Inventory/{brandId}
        [HttpPut("{brandId}")]
        [Authorize]
        public Brand UpdateBrand(int brandId, [FromForm] Brand oBrand)
        {
            if (ModelState.IsValid)
            {
                return _iBrandService.UpdateBrand(brandId, oBrand);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Delete Brand details.
        /// </summary>
        /// <returns></returns>
        // DELETE: Inventory/{brandId}
        [HttpDelete("{brandId}")]
        [Authorize]
        public string DeleteBrand(int brandId)
        {
            return _iBrandService.Delete(brandId);
        }

        #endregion
    }
}
