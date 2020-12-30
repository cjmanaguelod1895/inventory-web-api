using Inventory_Web_API.Models.PSGC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.IServices
{
    public interface IBarangayService
    {
        List<Barangay> GetBarangayList();

        Barangay GetBarangay(int baranggayId);

        Barangay AddBarangay(Barangay barangay);

        Barangay UpdateBarangay(int baranggayId, Barangay barangay);


        string Delete(int barangayId);
    }
}
