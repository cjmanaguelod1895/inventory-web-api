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
    public class RegionService : IRegionService
    {
        PSGC _psgc = new PSGC();
        Region _region = new Region();
        List<Region> _regionList = new List<Region>();


        private readonly AppSettings _appSettings;

        public RegionService(IOptions<AppSettings> appsettings)
        {
            _appSettings = appsettings.Value;
        }

        public List<Region> GetRegionList()
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

                    var oRegionList = con.Query<Region>("sp_Region",
                       _region.SetParameters(_region, operationType),
                       commandType: CommandType.StoredProcedure);


                    if (oRegionList != null && oRegionList.Count() > 0)
                    {
                        _regionList = oRegionList.ToList();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _regionList;
        }

        public Region GetRegion(int regionId)
        {
            _region = new Region()
            {
                RegionId = regionId
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

                    var oRegion = con.Query<Region>("sp_Region",
                        _region.SetParameters(_region, operationType),
                       commandType: CommandType.StoredProcedure).ToList();

                    if (oRegion != null && oRegion.Count() > 0)
                    {
                        _region = oRegion.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _region;
        }

        public Region AddRegion(Region region)
        {
            try
            {
                int operationType = Convert.ToInt32(region.RegionId == 0 ? OperationType.Insert : OperationType.Update);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oRegion = con.Query<Region>("sp_Region",
                        _region.SetParameters(region, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oRegion != null && oRegion.Count() > 0)
                    {
                        _region = oRegion.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _region;
        }

        public Region UpdateRegion(int regionId, Region region)
        {
            region.RegionId = regionId;

            try
            {
                int operationType = Convert.ToInt32(OperationType.Update);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oRegion = con.Query<Region>("sp_Region",
                        _region.SetParameters(region, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oRegion != null && oRegion.Count() > 0)
                    {
                        _region = oRegion.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _region;
        }

        public string Delete(int regionId)
        {
            string message = "";

            try
            {
                _region = new Region()
                {
                    RegionId = regionId
                };

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oRegion = con.Query<Region>("sp_Region",
                        _region.SetParameters(_region, (int)OperationType.Delete),
                        commandType: CommandType.StoredProcedure);

                    if (oRegion != null && oRegion.Count() > 0)
                    {
                        _region = oRegion.FirstOrDefault();

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
