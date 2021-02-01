using Dapper;
using Inventory_Web_API.Common;
using Inventory_Web_API.Helpers;
using Inventory_Web_API.IServices;
using Inventory_Web_API.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.Services
{
    public class TaxService : ITaxService
    {
        Tax _otax = new Tax();
        List<Tax> _otaxes = new List<Tax>();

        private readonly AppSettings _appSettings;

        public TaxService(IOptions<AppSettings> appsettings)
        {
            _appSettings = appsettings.Value;
        }

        public List<Tax> GetTaxList()
        {
            try
            {
                int operationType = Convert.ToInt32(OperationType.SelectAll);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State != ConnectionState.Closed)
                    {
                    }
                    else
                    {
                        con.Open();
                    }

                    var oTaxes = con.Query<Tax>("[salespropos].[sp_Taxes]",
                       _otax.SetParameters(_otax, operationType),
                       commandType: CommandType.StoredProcedure);


                    if (oTaxes != null && oTaxes.Count() > 0)
                    {
                        _otaxes = oTaxes.ToList();
                    }
                }
            }
            catch (Exception ex)
            {


            }

            return _otaxes;
        }

        public Tax GetTax(int taxId)
        {
            _otax = new Tax()
            {
                Id = taxId
            };

            try
            {
                int operationType = Convert.ToInt32(OperationType.SelectSpecific);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oTaxes = con.Query<Tax>("[salespropos].[sp_Taxes]",
                        _otax.SetParameters(_otax, operationType),
                       commandType: CommandType.StoredProcedure).ToList();

                    if (oTaxes != null && oTaxes.Count() > 0)
                    {
                        _otax = oTaxes.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return _otax;
        }

        public Tax AddTax(Tax tax)
        {
            _otax = new Tax();
            DateTime aDate = DateTime.Now;
            tax.Created_at = aDate;

            try
            {
                int operationType = Convert.ToInt32(tax.Id == 0 ? OperationType.Insert : OperationType.Update);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oTaxes = con.Query<Tax>("[salespropos].[sp_Taxes]",
                        _otax.SetParameters(tax, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oTaxes != null && oTaxes.Count() > 0)
                    {
                        _otax = oTaxes.FirstOrDefault();
                    }
                }
            }
            catch (Exception)
            {


            }

            return _otax;
        }

        public Tax UpdateTax(int taxId, Tax tax)
        {
            _otax = new Tax();
            DateTime aDate = DateTime.Now;
            tax.Id = taxId;
            tax.Updated_at = aDate;

            try
            {
                int operationType = Convert.ToInt32(OperationType.Update);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oTaxes = con.Query<Tax>("[salespropos].[sp_Taxes]",
                        _otax.SetParameters(tax, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oTaxes != null && oTaxes.Count() > 0)
                    {
                        _otax = oTaxes.FirstOrDefault();
                    }
                }
            }
            catch (Exception)
            {


            }

            return _otax;
        }

        public string Delete(int taxId)
        {
            string message = "";

            try
            {
                _otax = new Tax()
                {
                    Id = taxId
                };

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oTaxes = con.Query<Tax>("[salespropos].[sp_Taxes]",
                        _otax.SetParameters(_otax, (int)OperationType.Delete),
                        commandType: CommandType.StoredProcedure);

                    if (oTaxes != null && oTaxes.Count() > 0)
                    {
                        _otax = oTaxes.FirstOrDefault();

                        message = "Data Deleted!";
                    }
                }
            }
            catch (Exception ex)
            {

                message = ex.Message;
            }

            return message;
        }
    }
}
