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
    public class BrandService : IBrandService
    {
        PSGC _psgc = new PSGC();
        Brand _brand = new Brand();
        List<Brand> _brandList = new List<Brand>();


        private readonly AppSettings _appSettings;

        public BrandService(IOptions<AppSettings> appsettings)
        {
            _appSettings = appsettings.Value;
        }

        public Brand AddBrand(Brand oBrand)
        {
            try
            {
                int operationType = Convert.ToInt32(oBrand.BrandId == 0 ? OperationType.Insert : OperationType.Update);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oBrandList = con.Query<Brand>("sp_Brand",
                       _brand.SetParameters(oBrand, operationType),
                       commandType: CommandType.StoredProcedure);

                    if (oBrandList != null && oBrandList.Count() > 0)
                    {
                        _brand = oBrandList.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _brand;
        }

        public string Delete(int brandId)
        {
            string message = "";

            try
            {
                _brand = new Brand()
                {
                    BrandId = brandId
                };

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oBrandList = con.Query<Brand>("sp_Brand",
                        _brand.SetParameters(_brand, (int)OperationType.Delete),
                        commandType: CommandType.StoredProcedure);

                    if (oBrandList != null && oBrandList.Count() > 0)
                    {
                        _brand = oBrandList.FirstOrDefault();

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

        public Brand GetBrand(int brandId)
        {
            _brand = new Brand()
            {
                BrandId = brandId
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

                    var oBrandList = con.Query<Brand>("sp_Brand",
                        _brand.SetParameters(_brand, operationType),
                       commandType: CommandType.StoredProcedure).ToList();

                    if (oBrandList != null && oBrandList.Count() > 0)
                    {
                        _brand = oBrandList.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _brand;
        }

        public List<Brand> GetBrandList()
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

                    var oBrandList = con.Query<Brand>("sp_Brand",
                       _brand.SetParameters(_brand, operationType),
                       commandType: CommandType.StoredProcedure);


                    if (oBrandList != null && oBrandList.Count() > 0)
                    {
                        _brandList = oBrandList.ToList();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _brandList;
        }

        public Brand UpdateBrand(int brandId, Brand oBrand)
        {
            oBrand.BrandId = brandId;

            try
            {
                int operationType = Convert.ToInt32(OperationType.Update);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oBrandList = con.Query<Brand>("sp_Brand",
                        _brand.SetParameters(oBrand, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oBrandList != null && oBrandList.Count() > 0)
                    {
                        _brand = oBrandList.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _brand;
        }
    }
}
