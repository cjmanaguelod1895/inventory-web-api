using Inventory_Web_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.IServices
{
    public interface ICurrencyService
    {
        List<Currency> GetCurrencyList();

        Currency GetCurrency(int currencyId);

        Currency AddCurrency(Currency oCurrency);

        Currency UpdateCurrency(int currencyId, Currency oCurrency);


        string Delete(int currencyId);
    }
}
