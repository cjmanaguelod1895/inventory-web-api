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
    public class WareHouseService : IWareHouseService
    {
        WareHouse _owareHouse = new WareHouse();
        List<WareHouse> _owareHouses = new List<WareHouse>();

        private readonly AppSettings _appSettings;

        public WareHouseService(IOptions<AppSettings> appsettings)
        {
            _appSettings = appsettings.Value;
        }
        public WareHouse AddWareHouse(WareHouse wareHouse)
        {
            _owareHouse = new WareHouse();
            DateTime aDate = DateTime.Now;
            wareHouse.Created_At = aDate;

            try
            {
                int operationType = Convert.ToInt32(wareHouse.Id == 0 ? OperationType.Insert : OperationType.Update);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oWareHouse = con.Query<WareHouse>("[salespropos].[sp_WareHouse]",
                        _owareHouse.SetParameters(wareHouse, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oWareHouse != null && oWareHouse.Count() > 0)
                    {
                        _owareHouse = oWareHouse.FirstOrDefault();
                    }
                }
            }
            catch (Exception)
            {


            }

            return _owareHouse;
        }

        public string Delete(int wareHouseId)
        {
            string message = "";

            try
            {
                _owareHouse = new WareHouse()
                {
                    Id = wareHouseId
                };

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oWareHouse = con.Query<WareHouse>("[salespropos].[sp_WareHouse]",
                        _owareHouse.SetParameters(_owareHouse, (int)OperationType.Delete),
                        commandType: CommandType.StoredProcedure);

                    if (oWareHouse != null && oWareHouse.Count() > 0)
                    {
                        _owareHouse = oWareHouse.FirstOrDefault();

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

        public WareHouse GetWareHouse(int wareHouseId)
        {
            _owareHouse = new WareHouse()
            {
                Id = wareHouseId
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

                    var oWareHouse = con.Query<WareHouse>("[salespropos].[sp_WareHouse]",
                        _owareHouse.SetParameters(_owareHouse, operationType),
                       commandType: CommandType.StoredProcedure).ToList();

                    if (oWareHouse != null && oWareHouse.Count() > 0)
                    {
                        _owareHouse = oWareHouse.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return _owareHouse;
        }

        public List<WareHouse> GetWareHouseList()
        {
            _owareHouse = new WareHouse();
            _owareHouses = new List<WareHouse>();

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

                    var oWareHouse = con.Query<WareHouse>("[salespropos].[sp_WareHouse]",
                       _owareHouse.SetParameters(_owareHouse, operationType),
                       commandType: CommandType.StoredProcedure);


                    if (oWareHouse != null && oWareHouse.Count() > 0)
                    {
                        _owareHouses = oWareHouse.ToList();
                    }
                }
            }
            catch (Exception ex)
            {


            }

            return _owareHouses;
        }

        public WareHouse UpdateWareHouse(int wareHouseId, WareHouse wareHouse)
        {
            _owareHouse = new WareHouse();
            DateTime aDate = DateTime.Now;
            wareHouse.Id = wareHouseId;
            wareHouse.Updated_at = aDate;

            try
            {
                int operationType = Convert.ToInt32(OperationType.Update);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oWareHouse = con.Query<WareHouse>("[salespropos].[sp_WareHouse]",
                        _owareHouse.SetParameters(wareHouse, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oWareHouse != null && oWareHouse.Count() > 0)
                    {
                        _owareHouse = oWareHouse.FirstOrDefault();
                    }
                }
            }
            catch (Exception)
            {


            }

            return _owareHouse;
        }
    }
}
