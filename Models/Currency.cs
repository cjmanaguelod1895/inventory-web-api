using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.Models
{
    public class Currency
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public float Exchange_rate { get; set; }

        public DateTime? Created_at { get; set; }

        public DateTime? Updated_at { get; set; }


        public DynamicParameters SetParameters(Currency oCurrency, int operationType)
        {


            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", oCurrency.Id);
            parameters.Add("@Name", oCurrency.Name);
            parameters.Add("@Code", oCurrency.Code);
            parameters.Add("@Exchange_rate", oCurrency.Exchange_rate);
            parameters.Add("@Created_at", oCurrency.Created_at);
            parameters.Add("@Updated_at", oCurrency.Updated_at);
            parameters.Add("@OperationType", operationType);

            return parameters;
        }
    }
}
