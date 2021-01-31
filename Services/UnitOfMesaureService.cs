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
    public class UnitOfMesaureService : IUnitOfMeasureService
    {
        PSGC _psgc = new PSGC();
        UnitOfMeasure _unitOfMeasure = new UnitOfMeasure();
        List<UnitOfMeasure> _unitOfMeasureList = new List<UnitOfMeasure>();


        private readonly AppSettings _appSettings;

        public UnitOfMesaureService(IOptions<AppSettings> appsettings)
        {
            _appSettings = appsettings.Value;
        }

        public UnitOfMeasure AddUnitOfMeasure(UnitOfMeasure oUnitOfMeasure)
        {
            try
            {
                int operationType = Convert.ToInt32(oUnitOfMeasure.Id == 0 ? OperationType.Insert : OperationType.Update);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oUnitOfMeasureList = con.Query<UnitOfMeasure>("[salespropos].[sp_UnitOfMeasures]",
                        _unitOfMeasure.SetParameters(oUnitOfMeasure, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oUnitOfMeasureList != null && oUnitOfMeasureList.Count() > 0)
                    {
                        _unitOfMeasure = oUnitOfMeasureList.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _unitOfMeasure;
        }

        public string Delete(int unitId)
        {
            string message = "";

            try
            {
                _unitOfMeasure = new UnitOfMeasure()
                {
                    Id = unitId
                };

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oUnitOfMeasure = con.Query<UnitOfMeasure>("[salespropos].[sp_UnitOfMeasures]",
                        _unitOfMeasure.SetParameters(_unitOfMeasure, (int)OperationType.Delete),
                        commandType: CommandType.StoredProcedure);

                    if (oUnitOfMeasure != null && oUnitOfMeasure.Count() > 0)
                    {
                        _unitOfMeasure = oUnitOfMeasure.FirstOrDefault();

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

        public UnitOfMeasure GetUnitOfMeasure(int unitId)
        {
            _unitOfMeasure = new UnitOfMeasure()
            {
                Id = unitId
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

                    var oUnitOfMeasure = con.Query<UnitOfMeasure>("[salespropos].[sp_UnitOfMeasures]",
                        _unitOfMeasure.SetParameters(_unitOfMeasure, operationType),
                       commandType: CommandType.StoredProcedure).ToList();

                    if (oUnitOfMeasure != null && oUnitOfMeasure.Count() > 0)
                    {
                        _unitOfMeasure = oUnitOfMeasure.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _unitOfMeasure;
        }

        public List<UnitOfMeasure> GetUnitOfMeasureList()
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

                    var oUnitOfMeasureList = con.Query<UnitOfMeasure>("[salespropos].[sp_UnitOfMeasures]",
                       _unitOfMeasure.SetParameters(_unitOfMeasure, operationType),
                       commandType: CommandType.StoredProcedure);


                    if (oUnitOfMeasureList != null && oUnitOfMeasureList.Count() > 0)
                    {
                        _unitOfMeasureList = oUnitOfMeasureList.ToList();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _unitOfMeasureList;
        }

        public UnitOfMeasure UpdateUnitOfMeasure(int unitId, UnitOfMeasure oUnitOfMeasure)
        {
            oUnitOfMeasure.Id = unitId;

            try
            {
                int operationType = Convert.ToInt32(OperationType.Update);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oUnitOfMeasureList = con.Query<UnitOfMeasure>("[salespropos].[sp_UnitOfMeasures]",
                        _unitOfMeasure.SetParameters(oUnitOfMeasure, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oUnitOfMeasureList != null && oUnitOfMeasureList.Count() > 0)
                    {
                        _unitOfMeasure = oUnitOfMeasureList.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _unitOfMeasure;
        }
    }
}
