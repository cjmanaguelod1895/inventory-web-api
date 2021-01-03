using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.Models
{
    public class Brand
    {
        public int BrandId { get; set; }

        public string BrandName { get; set; }

        public string BrandCode { get; set; }

        public string BrandDescription { get; set; }


        public DynamicParameters SetParameters(Brand oBrand, int operationType)
        {


            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@BrandId", oBrand.BrandId);
            parameters.Add("@BrandName", oBrand.BrandName);
            parameters.Add("@BrandCode", oBrand.BrandCode);
            parameters.Add("@BrandDescription", oBrand.BrandDescription);
            parameters.Add("@OperationType", operationType);

            return parameters;
        }
    }
}
