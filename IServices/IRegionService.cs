using Inventory_Web_API.Models.PSGC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.IServices
{
    public interface IRegionService
    {
        List<Region> GetRegionList();

        Region GetRegion(int regionId);

        Region AddRegion(Region region);

        Region UpdateRegion(int regionId, Region region);


        string Delete(int regionId);
    }
}
