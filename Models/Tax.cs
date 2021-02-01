using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.Models
{
    public class Tax
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Rate { get; set; }

        public int Is_active { get; set; }

        public DateTime?  Created_at { get; set; }

        public DateTime? Updated_at { get; set; }

        public DynamicParameters SetParameters(Tax oCurrency, int operationType)
        {


            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", oCurrency.Id);
            parameters.Add("@Name", oCurrency.Name);
            parameters.Add("@Rate", oCurrency.Rate);
            parameters.Add("@Is_active", oCurrency.Is_active);
            parameters.Add("@Created_at", oCurrency.Created_at);
            parameters.Add("@Updated_at", oCurrency.Updated_at);
            parameters.Add("@OperationType", operationType);

            return parameters;
        }
    }
}
