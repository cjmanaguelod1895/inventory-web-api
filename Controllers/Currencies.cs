using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_Web_API.IServices;
using Inventory_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Web_API.Controllers
{
    [ApiExplorerSettings(GroupName = "Currencies CRUD Endpoint")]
    [Route("Inventory/[controller]")]
    [ApiController]
    public class Currencies : Controller
    {

        private ICurrencyService _iCurrencyService;
        public Currencies(ICurrencyService iCurrencyService)
        {
            _iCurrencyService = iCurrencyService;
        }

        #region Currencies
        /// <summary>
        /// Get list of Currencies.
        /// </summary>
        /// <returns>Get list of Currencies</returns>
        // GET: Inventory/Currencies
        [HttpGet]
        [Authorize]
        public IEnumerable<Currency> GetCurrencyList()
        {
            return _iCurrencyService.GetCurrencyList();
        }

        /// <summary>
        /// Get list of all Currency per Id.
        /// </summary>
        /// <returns>Get list of all Currency per Id</returns>
        // GET: Inventory/{currencyId}
        [HttpGet("{currencyId}")]
        [Authorize]
        public Currency Get(int currencyId)
        {
            return _iCurrencyService.GetCurrency(currencyId);
        }

        /// <summary>
        /// Add/Save New Currency Details.
        /// </summary>
        /// <returns></returns>
        // POST: Inventory/Currency
        [HttpPost]
        [Authorize]
        public Currency Add([FromBody] Currency oCurrency)
        {
            if (ModelState.IsValid)
            {
                return _iCurrencyService.AddCurrency(oCurrency);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Update Currency details.
        /// </summary>
        /// <returns></returns>
        // PUT: Inventory/{currencyId}
        [HttpPut("{currencyId}")]
        [Authorize]
        public Currency Update(int currencyId, [FromBody] Currency oCurrency)
        {
            if (ModelState.IsValid)
            {
                return _iCurrencyService.UpdateCurrency(currencyId, oCurrency);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Delete Currency details.
        /// </summary>
        /// <returns></returns>
        // DELETE: Inventory/{currencyId}
        [HttpDelete("{currencyId}")]
        [Authorize]
        public string Delet(int currencyId)
        {
            return _iCurrencyService.Delete(currencyId);
        }

        #endregion
    }
}
