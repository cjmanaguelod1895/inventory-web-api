using Inventory_Web_API.Models.PSGC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.IServices
{
    public interface IProvinceService
    {
        List<Province> GetProvinceList();

        Province GetProvince(int provinceId);

        Province AddProvince(Province province);

        Province UpdateProvince(int provinceId, Province province);


        string Delete(int provinceId);
    }
}
