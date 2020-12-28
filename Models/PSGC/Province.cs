using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.Models
{
    public class Province
    {
        public int ProvinceId { get; set; }

        public string PSGCCode { get; set; }

        public string ProvinceDescription { get; set; }

        public string RegCode { get; set; }

        public string ProvinceCode { get; set; }
    }
}
