using Dapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.Models
{
    public class Biller
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public IFormFile ImageFile { get; set; }

        public string Company_name { get; set; }

        public string Vat_number { get; set; }


        public string Email { get; set; }

        public string Phone_number { get; set; }

        public string Address { get; set; }

        public string City  { get; set; }

        public string State { get; set; }

        public string Postal_code { get; set; }

        public string Country { get; set; }

        public int Is_active { get; set; }

        public DateTime? Created_at { get; set; }

        public DateTime? Updated_at { get; set; }

        public DynamicParameters SetParameters(Biller oBiller, int operationType)
        {


            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", oBiller.Id);
            parameters.Add("@Name", oBiller.Name);
            parameters.Add("@Image", oBiller.Image);
            parameters.Add("@Company_name", oBiller.Company_name);
            parameters.Add("@Vat_number", oBiller.Vat_number);
            parameters.Add("@Email", oBiller.Email);
            parameters.Add("@Phone_number", oBiller.Phone_number);
            parameters.Add("@Address", oBiller.Address);
            parameters.Add("@City", oBiller.City);
            parameters.Add("@State", oBiller.State);
            parameters.Add("@Postal_code", oBiller.Postal_code);
            parameters.Add("@Country", oBiller.Country);
            parameters.Add("@Is_active", oBiller.Is_active);
            parameters.Add("@Created_at", oBiller.Created_at);
            parameters.Add("@Updated_at", oBiller.Updated_at);
            parameters.Add("@OperationType", operationType);

            return parameters;
        }
    }
}
