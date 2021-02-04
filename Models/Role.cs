using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Guard_name { get; set; }

        public int Is_active { get; set; }

        public DateTime? Created_at { get; set; }

        public DateTime? Updated_at { get; set; }

        public DynamicParameters SetParameters(Role oRole, int operationType)
        {


            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", oRole.Id);
            parameters.Add("@Name", oRole.Name);
            parameters.Add("@Description", oRole.Description);
            parameters.Add("@Guard_name", oRole.Guard_name);
            parameters.Add("@Is_active", oRole.Is_active);
            parameters.Add("@Created_at", oRole.Created_at);
            parameters.Add("@Updated_at", oRole.Updated_at);
            parameters.Add("@OperationType", operationType);

            return parameters;
        }
    }
}
