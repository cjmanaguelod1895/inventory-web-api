using Dapper;
using Inventory_Web_API.Common;
using Inventory_Web_API.Helpers;
using Inventory_Web_API.IServices;
using Inventory_Web_API.Models;
using Inventory_Web_API.Models.PSGC;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.Services
{
    public class CurrencySevice : ICurrencyService
    {
        PSGC _psgc = new PSGC();
        Currency _currency = new Currency();
        List<Currency> _currencyList = new List<Currency>();


        private readonly AppSettings _appSettings;

        public CurrencySevice(IOptions<AppSettings> appsettings)
        {
            _appSettings = appsettings.Value;
        }

        public Currency AddCurrency(Currency oCurrency)
        {
            try
            {
                int operationType = Convert.ToInt32(oCurrency.Id == 0 ? OperationType.Insert : OperationType.Update);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oCurrencyList = con.Query<Currency>("[salespropos].[sp_Currency]",
                       _currency.SetParameters(oCurrency, operationType),
                       commandType: CommandType.StoredProcedure);

                    if (oCurrencyList != null && oCurrencyList.Count() > 0)
                    {
                        _currency = oCurrencyList.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _currency;
        }

        public string Delete(int currencyId)
        {
            string message = "";

            try
            {
                _currency = new Currency()
                {
                    Id = currencyId
                };

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oCurrency = con.Query<Currency>("[salespropos].[sp_Currency]",
                        _currency.SetParameters(_currency, (int)OperationType.Delete),
                        commandType: CommandType.StoredProcedure);

                    if (oCurrency != null && oCurrency.Count() > 0)
                    {
                        _currency = oCurrency.FirstOrDefault();

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

        public Currency GetCurrency(int currencyId)
        {
            _currency = new Currency()
            {
                Id = currencyId
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

                    var oCurrency = con.Query<Currency>("[salespropos].[sp_Currency]",
                        _currency.SetParameters(_currency, operationType),
                       commandType: CommandType.StoredProcedure).ToList();

                    if (oCurrency != null && oCurrency.Count() > 0)
                    {
                        _currency = oCurrency.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _currency;
        }

        public List<Currency> GetCurrencyList()
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

                    var oCurrency = con.Query<Currency>("[salespropos].[sp_Currency]",
                       _currency.SetParameters(_currency, operationType),
                       commandType: CommandType.StoredProcedure);


                    if (oCurrency != null && oCurrency.Count() > 0)
                    {
                        _currencyList = oCurrency.ToList();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _currencyList;
        }

        public Currency UpdateCurrency(int currencyId, Currency oCurrency)
        {
            oCurrency.Id = currencyId;

            try
            {
                int operationType = Convert.ToInt32(OperationType.Update);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oCurrencyList = con.Query<Currency>("[salespropos].[sp_Currency]",
                        _currency.SetParameters(oCurrency, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oCurrencyList != null && oCurrencyList.Count() > 0)
                    {
                        _currency = oCurrencyList.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _currency;
        }
    }
}
