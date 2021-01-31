using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.Models
{
    public class WareHouse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public int Is_active { get; set; }

        public DateTime? Created_At { get; set; }

        public DateTime? Updated_at { get; set; }

        public DynamicParameters SetParameters(WareHouse oWareHouse, int operationType)
        {


            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", oWareHouse.Id);
            parameters.Add("@Name", oWareHouse.Name);
            parameters.Add("@Phone", oWareHouse.Phone);
            parameters.Add("@Email", oWareHouse.Email);
            parameters.Add("@Address", oWareHouse.Address);
            parameters.Add("@Is_active", oWareHouse.Is_active);
            parameters.Add("@Created_at", oWareHouse.Created_At);
            parameters.Add("@Updated_at", oWareHouse.Updated_at);
            parameters.Add("@OperationType", operationType);

            return parameters;
        }
    }
}
