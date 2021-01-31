using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.Models
{
    public class CustomerGroup
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Percentage { get; set; }

        public int Is_active { get; set; }

        public DateTime? Created_at { get; set; }

        public DateTime? Updated_at { get; set; }


        public DynamicParameters SetParameters(CustomerGroup oCustomerGroup, int operationType)
        {


            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", oCustomerGroup.Id);
            parameters.Add("@Name", oCustomerGroup.Name);
            parameters.Add("@Percentage", oCustomerGroup.Percentage);
            parameters.Add("@Is_active", oCustomerGroup.Is_active);
            parameters.Add("@Created_at", oCustomerGroup.Created_at);
            parameters.Add("@Updated_at", oCustomerGroup.Updated_at);
            parameters.Add("@OperationType", operationType);

            return parameters;
        }
    }
}
