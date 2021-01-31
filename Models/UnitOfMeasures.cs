using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.Models
{
    public class UnitOfMeasure
    {
        public int Id { get; set; }

        public string Unit_code { get; set; }

        public string Unit_Name { get; set; }

        public int Base_unit { get; set; }

        public string Operator { get; set; }

        public float Operation_value { get; set; }

        public int Is_active { get; set; }

        public DateTime? Created_at { get; set; }

        public DateTime? Updated_at { get; set; }


        public DynamicParameters SetParameters(UnitOfMeasure unitOfMeasure, int operationType)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", unitOfMeasure.Id);
            parameters.Add("@Unit_code", unitOfMeasure.Unit_code);
            parameters.Add("@Unit_Name", unitOfMeasure.Unit_Name);
            parameters.Add("@Base_unit", unitOfMeasure.Base_unit);
            parameters.Add("@Operator", unitOfMeasure.Operator);
            parameters.Add("@Operation_value", unitOfMeasure.Operation_value);
            parameters.Add("@Is_active", unitOfMeasure.Is_active);
            parameters.Add("@Created_at", unitOfMeasure.Created_at);
            parameters.Add("@Updated_at", unitOfMeasure.Updated_at);
            parameters.Add("@OperationType", operationType);

            return parameters;
        }
    }
}
