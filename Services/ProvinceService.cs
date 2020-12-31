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
    public class ProvinceService : IProvinceService
    {
        PSGC _psgc = new PSGC();
        Province _province = new Province();
        List<Province> _provinceList = new List<Province>();


        private readonly AppSettings _appSettings;

        public ProvinceService(IOptions<AppSettings> appsettings)
        {
            _appSettings = appsettings.Value;
        }

        public List<Province> GetProvinceList()
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

                    var oProvinceList = con.Query<Province>("sp_Province",
                       _province.SetParameters(_province, operationType),
                       commandType: CommandType.StoredProcedure);


                    if (oProvinceList != null && oProvinceList.Count() > 0)
                    {
                        _provinceList = oProvinceList.ToList();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _provinceList;
        }

        public Province GetProvince(int provinceId)
        {
            _province = new Province()
            {
                ProvinceId = provinceId
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

                    var oProvince = con.Query<Province>("sp_Province",
                        _province.SetParameters(_province, operationType),
                       commandType: CommandType.StoredProcedure).ToList();

                    if (oProvince != null && oProvince.Count() > 0)
                    {
                        _province = oProvince.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _province;
        }

        public Province AddProvince(Province province)
        {
            try
            {
                int operationType = Convert.ToInt32(province.ProvinceId == 0 ? OperationType.Insert : OperationType.Update);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oProvince = con.Query<Province>("sp_Province",
                        _province.SetParameters(province, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oProvince != null && oProvince.Count() > 0)
                    {
                        _province = oProvince.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _province;
        }

        public Province UpdateProvince(int provinceId, Province province)
        {
            province.ProvinceId = provinceId;

            try
            {
                int operationType = Convert.ToInt32(OperationType.Update);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oProvince = con.Query<Province>("sp_Province",
                        _province.SetParameters(province, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oProvince != null && oProvince.Count() > 0)
                    {
                        _province = oProvince.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _province;
        }

        public string Delete(int provinceId)
        {
            string message = "";

            try
            {
                _province = new Province()
                {
                    ProvinceId = provinceId
                };

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oProvince = con.Query<Province>("sp_Province",
                        _province.SetParameters(_province, (int)OperationType.Delete),
                        commandType: CommandType.StoredProcedure);

                    if (oProvince != null && oProvince.Count() > 0)
                    {
                        _province = oProvince.FirstOrDefault();

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
