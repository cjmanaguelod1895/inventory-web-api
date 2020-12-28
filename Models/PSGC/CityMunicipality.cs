using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.Models
{
    public class CityMunicipality
    {
        public int MunicipalityId { get; set; }

        public string PSGCCode { get; set; }

        public string CityMunDescription { get; set; }

        public string RegDescription { get; set; }

        public string ProvinceCode { get; set; }

        public string CityMunCode { get; set; }
    }
}
