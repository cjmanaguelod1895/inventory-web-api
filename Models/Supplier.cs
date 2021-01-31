using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Company_name { get; set; }

        public string Vat_number { get; set; }


        public string Email { get; set; }

        public string Phone_number { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Postal_code { get; set; }

        public string Country { get; set; }

        public int Is_active { get; set; }

        public DateTime? Created_at { get; set; }

        public DateTime? Updated_at { get; set; }

        public DynamicParameters SetParameters(Supplier oSupplier, int operationType)
        {


            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", oSupplier.Id);
            parameters.Add("@Name", oSupplier.Name);
            parameters.Add("@Image", oSupplier.Image);
            parameters.Add("@Company_name", oSupplier.Company_name);
            parameters.Add("@Vat_number", oSupplier.Vat_number);
            parameters.Add("@Email", oSupplier.Email);
            parameters.Add("@Phone_number", oSupplier.Phone_number);
            parameters.Add("@Address", oSupplier.Address);
            parameters.Add("@City", oSupplier.City);
            parameters.Add("@State", oSupplier.State);
            parameters.Add("@Postal_code", oSupplier.Postal_code);
            parameters.Add("@Country", oSupplier.Country);
            parameters.Add("@Is_active", oSupplier.Is_active);
            parameters.Add("@Created_at", oSupplier.Created_at);
            parameters.Add("@Updated_at", oSupplier.Updated_at);
            parameters.Add("@OperationType", operationType);

            return parameters;
        }
    }
}
