using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.Models
{
    public class UnitOfMeasure
    {
        public int UnitID { get; set; }

        public string UnitName { get; set; }

        public string UnitCode { get; set; }

        public int UnitType { get; set; }

        public int UnitSub { get; set; }


        public DynamicParameters SetParameters(UnitOfMeasure unitOfMeasure, int operationType)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UnitID", unitOfMeasure.UnitID);
            parameters.Add("@UnitName", unitOfMeasure.UnitName);
            parameters.Add("@UnitCode", unitOfMeasure.UnitCode);
            parameters.Add("@UnitType", unitOfMeasure.UnitType);
            parameters.Add("@UnitSub", unitOfMeasure.UnitSub);
            parameters.Add("@OperationType", operationType);

            return parameters;
        }
    }
}
