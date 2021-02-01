using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Inventory_Web_API.Models
{
    public class Users
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string Company_Name { get; set; }

        public int Role_id { get; set; }

        public string Role { get; set; }

        public int Biller_Id { get; set; }

        public int Warehouse_id { get; set; }

        public int Is_Active { get; set; }

        public int Is_deleted { get; set; }

        public DateTime? Created_at { get; set; }

        public DateTime? Updated_at { get; set; }

        public DateTime? Last_login_date { get; set; }

        public DynamicParameters SetParameters(Users oUser, int operationType)
        {


            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", oUser.Id);
            parameters.Add("@Name", oUser.Name);
            parameters.Add("@Username", oUser.Username);
            parameters.Add("@Email", oUser.Email);
            parameters.Add("@Password", oUser.Password);
            parameters.Add("@Phone", oUser.Phone);
            parameters.Add("@Company_Name", oUser.Company_Name);
            parameters.Add("@Role_id", oUser.Role_id);
            parameters.Add("@Role", oUser.Role);
            parameters.Add("@Biller_id", oUser.Biller_Id);
            parameters.Add("@Warehouse_id", oUser.Warehouse_id);
            parameters.Add("@Is_active", oUser.Is_Active);
            parameters.Add("@Is_deleted", oUser.Is_deleted);
            parameters.Add("@Created_at", oUser.Created_at);
            parameters.Add("@Updated_at", oUser.Updated_at);
            parameters.Add("@Last_login_date", oUser.Last_login_date);
            parameters.Add("@OperationType", operationType);

            return parameters;
        }

    }
}
