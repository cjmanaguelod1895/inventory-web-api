using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public int Customer_group_id { get; set; }

        public string Customer_group_name { get; set; }

        public int User_id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string Company_Name { get; set; }

        public string Email { get; set; }

        public string Phone_number { get; set; }

        public string Tax_no { get; set; }

        public string Address { get; set; }


        public string City { get; set; }


        public string State { get; set; }

        public string Postal_code { get; set; }

        public string Country { get; set; }

        public float Deposit { get; set; }

        public float Expense { get; set; }

        public int Is_active { get; set; }

        public DateTime? Created_at { get; set; }

        public DateTime? Updated_at { get; set; }

        public DynamicParameters SetParameters(Customer oCustomer, int operationType)
        {


            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", oCustomer.Id);
            parameters.Add("@Customer_group_id", oCustomer.Customer_group_id);
            parameters.Add("@User_id", oCustomer.User_id);
            parameters.Add("@Name", oCustomer.Name);
            parameters.Add("@Password", oCustomer.Password);
            parameters.Add("@Company_Name", oCustomer.Company_Name);
            parameters.Add("@Email", oCustomer.Email);
            parameters.Add("@Phone_number", oCustomer.Phone_number);
            parameters.Add("@Tax_no", oCustomer.Tax_no);
            parameters.Add("@Address", oCustomer.Address);
            parameters.Add("@City", oCustomer.City);
            parameters.Add("@State", oCustomer.State);
            parameters.Add("@Postal_code", oCustomer.Postal_code);
            parameters.Add("@Country", oCustomer.Country);
            parameters.Add("@Expense", oCustomer.Expense);
            parameters.Add("@Deposit", oCustomer.Deposit);
            parameters.Add("@Is_active", oCustomer.Is_active);
            parameters.Add("@Created_at", oCustomer.Created_at);
            parameters.Add("@Updated_at", oCustomer.Updated_at);
            parameters.Add("@OperationType", operationType);

            return parameters;
        }
    }
}
