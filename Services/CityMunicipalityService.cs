using Dapper;
using Inventory_Web_API.Common;
using Inventory_Web_API.Helpers;
using Inventory_Web_API.IServices;
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
    public class CityMunicipalityService : ICityMunicipalityService
    {
        PSGC _psgc = new PSGC();
        CityMunicipality _cityMunicipality = new CityMunicipality();
        List<CityMunicipality> _cityMunicipalityList = new List<CityMunicipality>();


        private readonly AppSettings _appSettings;

        public CityMunicipalityService(IOptions<AppSettings> appsettings)
        {
            _appSettings = appsettings.Value;
        }

        public List<CityMunicipality> GetCityMunicipalities()
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

                    var oCityMunicipalityList = con.Query<CityMunicipality>("sp_CityMunicipality",
                       _cityMunicipality.SetParameters(_cityMunicipality, operationType),
                       commandType: CommandType.StoredProcedure);


                    if (oCityMunicipalityList != null && oCityMunicipalityList.Count() > 0)
                    {
                        _cityMunicipalityList = oCityMunicipalityList.ToList();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _cityMunicipalityList;
        }

        public CityMunicipality GetCityMunicipality(int cityMunicipalityId)
        {
            _cityMunicipality = new CityMunicipality()
            {
                MunicipalityId = cityMunicipalityId
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

                    var oCityMunicipality = con.Query<CityMunicipality>("sp_CityMunicipality",
                        _cityMunicipality.SetParameters(_cityMunicipality, operationType),
                       commandType: CommandType.StoredProcedure).ToList();

                    if (oCityMunicipality != null && oCityMunicipality.Count() > 0)
                    {
                        _cityMunicipality = oCityMunicipality.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _cityMunicipality;
        }

        public CityMunicipality AddCityMunicipality(CityMunicipality cityMunicipalities)
        {
            try
            {
                int operationType = Convert.ToInt32(cityMunicipalities.MunicipalityId == 0 ? OperationType.Insert : OperationType.Update);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oCityMunicipality = con.Query<CityMunicipality>("sp_CityMunicipality",
                        _cityMunicipality.SetParameters(cityMunicipalities, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oCityMunicipality != null && oCityMunicipality.Count() > 0)
                    {
                        _cityMunicipality = oCityMunicipality.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _cityMunicipality;

        }

        public CityMunicipality UpdateMunicipality(int cityMunicipalityId, CityMunicipality cityMunicipalities)
        {
            cityMunicipalities.MunicipalityId = cityMunicipalityId;

            try
            {
                int operationType = Convert.ToInt32(OperationType.Update);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oCityMunicipality = con.Query<CityMunicipality>("sp_CityMunicipality",
                        _cityMunicipality.SetParameters(cityMunicipalities, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oCityMunicipality != null && oCityMunicipality.Count() > 0)
                    {
                        _cityMunicipality = oCityMunicipality.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _cityMunicipality;
        }

        public string Delete(int cityMunicipalityId)
        {
            string message = "";

            try
            {
                _cityMunicipality = new CityMunicipality()
                {
                    MunicipalityId = cityMunicipalityId
                };

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oCityMunicipality = con.Query<CityMunicipality>("sp_CityMunicipality",
                        _cityMunicipality.SetParameters(_cityMunicipality, (int)OperationType.Delete),
                        commandType: CommandType.StoredProcedure);

                    if (oCityMunicipality != null && oCityMunicipality.Count() > 0)
                    {
                        _cityMunicipality = oCityMunicipality.FirstOrDefault();

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
