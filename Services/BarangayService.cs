using Dapper;
using Inventory_Web_API.Common;
using Inventory_Web_API.Helpers;
using Inventory_Web_API.IServices;
using Inventory_Web_API.Models.PSGC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.Services
{
    public class BarangayService : IBarangayService
    {

        PSGC _psgc = new PSGC();
        Barangay _barangay = new Barangay();
        List<Barangay> _barangayList = new List<Barangay>();


        private readonly AppSettings _appSettings;

        public BarangayService(IOptions<AppSettings> appsettings)
        {
            _appSettings = appsettings.Value;
        }


        public Barangay AddBarangay(Barangay barangay)
        {

            try
            {
                int operationType = Convert.ToInt32(barangay.BarangayId == 0 ? OperationType.Insert : OperationType.Update);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oBarangay = con.Query<Barangay>("sp_Barangay",
                        _barangay.SetParameters(barangay, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oBarangay != null && oBarangay.Count() > 0)
                    {
                        _barangay = oBarangay.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _barangay;


        }


        public string Delete(int barangayId)
        {
            string message = "";

            try
            {
                _barangay = new Barangay()
                {
                    BarangayId = barangayId
                };

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oBarangay = con.Query<Barangay>("sp_Barangay",
                        _barangay.SetParameters(_barangay, (int)OperationType.Delete),
                        commandType: CommandType.StoredProcedure);

                    if (oBarangay != null && oBarangay.Count() > 0)
                    {
                        _barangay = oBarangay.FirstOrDefault();

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

        public List<Barangay> GetBarangayList()
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

                    var oBarangayList = con.Query<Barangay>("sp_Barangay",
                       _barangay.SetParameters(_barangay, operationType),
                       commandType: CommandType.StoredProcedure);


                    if (oBarangayList != null && oBarangayList.Count() > 0)
                    {
                        _barangayList = oBarangayList.ToList();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _barangayList;
        }

        public Barangay GetBarangay(int baranggayId)
        {
            _barangay = new Barangay()
            {
                BarangayId = baranggayId
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

                    var oBarangay = con.Query<Barangay>("sp_Barangay",
                        _barangay.SetParameters(_barangay, operationType),
                       commandType: CommandType.StoredProcedure).ToList();

                    if (oBarangay != null && oBarangay.Count() > 0)
                    {
                        _barangay = oBarangay.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _barangay;
        }


        public Barangay UpdateBarangay(int baranggayId, Barangay barangay)
        {

            barangay.BarangayId = baranggayId;

            try
            {
                int operationType = Convert.ToInt32(OperationType.Update);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oBarangay = con.Query<Barangay>("sp_Barangay",
                        _barangay.SetParameters(barangay, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oBarangay != null && oBarangay.Count() > 0)
                    {
                        _barangay = oBarangay.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _barangay;
        }
    }
}
