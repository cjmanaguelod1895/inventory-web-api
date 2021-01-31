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
    public class SupplierService : ISupplierService
    {
        Supplier _oSupplier = new Supplier();
        List<Supplier> _oSuppliers = new List<Supplier>();

        private readonly AppSettings _appSettings;

        public SupplierService(IOptions<AppSettings> appsettings)
        {
            _appSettings = appsettings.Value;
        }

        public Supplier AddSupplier(Supplier supplier)
        {
            _oSupplier = new Supplier();
            DateTime aDate = DateTime.Now;
            supplier.Created_at = aDate;

            try
            {
                int operationType = Convert.ToInt32(supplier.Id == 0 ? OperationType.Insert : OperationType.Update);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oSuppliers = con.Query<Supplier>("[salespropos].[sp_Suppliers]",
                        _oSupplier.SetParameters(supplier, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oSuppliers != null && oSuppliers.Count() > 0)
                    {
                        _oSupplier = oSuppliers.FirstOrDefault();
                    }
                }
            }
            catch (Exception)
            {


            }

            return _oSupplier;
        }

        public string Delete(int supplierId)
        {
            string message = "";

            try
            {
                _oSupplier = new Supplier()
                {
                    Id = supplierId
                };

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oSuppliers = con.Query<Supplier>("[salespropos].[sp_Suppliers]",
                        _oSupplier.SetParameters(_oSupplier, (int)OperationType.Delete),
                        commandType: CommandType.StoredProcedure);

                    if (oSuppliers != null && oSuppliers.Count() > 0)
                    {
                        _oSupplier = oSuppliers.FirstOrDefault();

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

        public Supplier GetSupplier(int supplierId)
        {
            _oSupplier = new Supplier()
            {
                Id = supplierId
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

                    var oSuppliers = con.Query<Supplier>("[salespropos].[sp_Suppliers]",
                        _oSupplier.SetParameters(_oSupplier, operationType),
                       commandType: CommandType.StoredProcedure).ToList();

                    if (oSuppliers != null && oSuppliers.Count() > 0)
                    {
                        _oSupplier = oSuppliers.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return _oSupplier;
        }

        public List<Supplier> GetSupplierList()
        {
            _oSupplier = new Supplier();
            _oSuppliers = new List<Supplier>();

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

                    var oSuppliers = con.Query<Supplier>("[salespropos].[sp_Suppliers]",
                       _oSupplier.SetParameters(_oSupplier, operationType),
                       commandType: CommandType.StoredProcedure);


                    if (oSuppliers != null && oSuppliers.Count() > 0)
                    {
                        _oSuppliers = oSuppliers.ToList();
                    }
                }
            }
            catch (Exception ex)
            {


            }

            return _oSuppliers;
        }

        public Supplier UpdateSupplier(int supplierId, Supplier supplier)
        {
            _oSupplier = new Supplier();
            DateTime aDate = DateTime.Now;
            supplier.Id = supplierId;
            supplier.Updated_at = aDate;

            try
            {
                int operationType = Convert.ToInt32(OperationType.Update);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oSuppliers = con.Query<Supplier>("[salespropos].[sp_Suppliers]",
                        _oSupplier.SetParameters(supplier, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oSuppliers != null && oSuppliers.Count() > 0)
                    {
                        _oSupplier = oSuppliers.FirstOrDefault();
                    }
                }
            }
            catch (Exception)
            {


            }

            return _oSupplier;
        }
    }
}
