using Inventory_Web_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.IServices
{
    public interface IUnitOfMeasureService
    {
        List<UnitOfMeasure> GetUnitOfMeasureList();

        UnitOfMeasure GetUnitOfMeasure(int unitId);

        UnitOfMeasure AddUnitOfMeasure(UnitOfMeasure oUnitOfMeasure);

        UnitOfMeasure UpdateUnitOfMeasure(int unitId, UnitOfMeasure oUnitOfMeasure);


        string Delete(int unitId);
    }
}
