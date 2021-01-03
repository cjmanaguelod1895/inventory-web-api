using Inventory_Web_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.IServices
{
    public interface IBrandService
    {
        List<Brand> GetBrandList();

        Brand GetBrand(int brandId);

        Brand AddBrand(Brand oBrand);

        Brand UpdateBrand(int brandId, Brand oBrand);


        string Delete(int brandId);
    }
}
