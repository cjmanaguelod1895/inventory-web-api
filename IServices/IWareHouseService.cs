using Inventory_Web_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.IServices
{
    public interface IWareHouseService
    {
        List<WareHouse> GetWareHouseList();

        WareHouse GetWareHouse(int wareHouseId);

        WareHouse AddWareHouse(WareHouse wareHouse);

        WareHouse UpdateWareHouse(int wareHouseId, WareHouse wareHouse);


        string Delete(int wareHouseId);
    }
}
