using Dapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.Models
{
    public class Brand
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public IFormFile ImageFile { get; set; }

        public int Is_active { get; set; }

        public DateTime? Created_at { get; set; }

        public DateTime? Updated_at { get; set; }


        public DynamicParameters SetParameters(Brand oBrand, int operationType)
        {


            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", oBrand.Id);
            parameters.Add("@Title", oBrand.Title);
            parameters.Add("@Image", oBrand.Image);
            parameters.Add("@Is_active", oBrand.Is_active);
            parameters.Add("@Created_at", oBrand.Created_at);
            parameters.Add("@Updated_at", oBrand.Updated_at);
            parameters.Add("@OperationType", operationType);

            return parameters;
        }
    }
}
