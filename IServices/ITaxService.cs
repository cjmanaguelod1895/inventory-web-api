using Inventory_Web_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.IServices
{
    public interface ITaxService
    {
        List<Tax> GetTaxList();

        Tax GetTax(int taxId);

        Tax AddTax(Tax tax);

        Tax UpdateTax(int taxId, Tax tax);


        string Delete(int taxId);
    }
}
