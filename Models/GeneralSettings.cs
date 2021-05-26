using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.Models
{
    public class GeneralSettings
    {
        public string Site_Title { get; set; }

        public string Site_Logo { get; set; }

        public string Currency { get; set; }

        public string Staff_Access { get; set; }

        public string Date_Format { get; set; }

        public string Developed_By { get; set; }

        public string Invoice_Format { get; set; }

        public int State { get; set; }

        public string Theme { get; set; }

        public DateTime? Created_at { get; set; }

        public DateTime? Updated_at { get; set; }



        public DynamicParameters SetParameters(GeneralSettings oGeneralSettings, int operationType)
        {


            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Site_Title", oGeneralSettings.Site_Title);
            parameters.Add("@Site_Logo", oGeneralSettings.Site_Logo);
            parameters.Add("@Currency", oGeneralSettings.Currency);
            parameters.Add("@Staff_Access", oGeneralSettings.Staff_Access);
            parameters.Add("@Date_Format", oGeneralSettings.Date_Format);
            parameters.Add("@Developed_By", oGeneralSettings.Developed_By);
            parameters.Add("@Invoice_Format", oGeneralSettings.Invoice_Format);
            parameters.Add("@State", oGeneralSettings.State);
            parameters.Add("@Theme", oGeneralSettings.Theme);
            parameters.Add("@Created_at", oGeneralSettings.Created_at);
            parameters.Add("@Updated_at", oGeneralSettings.Updated_at);
            parameters.Add("@OperationType", operationType);

            return parameters;
        }
    }
}
