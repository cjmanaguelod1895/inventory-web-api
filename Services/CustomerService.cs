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
    public class CustomerService : ICustomerService
    {
        Customer _oCustomer = new Customer();
        List<Customer> _oCustomers = new List<Customer>();

        private readonly AppSettings _appSettings;

        public CustomerService(IOptions<AppSettings> appsettings)
        {
            _appSettings = appsettings.Value;
        }

        public Customer AddCustomer(Customer customer)
        {
            _oCustomer = new Customer();
            DateTime aDate = DateTime.Now;
            customer.Created_at = aDate;

            try
            {
                int operationType = Convert.ToInt32(customer.Id == 0 ? OperationType.Insert : OperationType.Update);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oCustomers = con.Query<Customer>("[salespropos].[sp_Customers]",
                        _oCustomer.SetParameters(customer, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oCustomers != null && oCustomers.Count() > 0)
                    {
                        _oCustomer = oCustomers.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {


            }

            return _oCustomer;
        }

        public string Delete(int customerId)
        {
            string message = "";

            try
            {
                _oCustomer = new Customer()
                {
                    Id = customerId
                };

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oCustomers = con.Query<Customer>("[salespropos].[sp_Customers]",
                        _oCustomer.SetParameters(_oCustomer, (int)OperationType.Delete),
                        commandType: CommandType.StoredProcedure);

                    if (oCustomers != null && oCustomers.Count() > 0)
                    {
                        _oCustomer = oCustomers.FirstOrDefault();

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

        public Customer GetCustomer(int customerId)
        {
            _oCustomer = new Customer()
            {
                Id  = customerId
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

                    var oCustomers = con.Query<Customer>("[salespropos].[sp_Customers]",
                        _oCustomer.SetParameters(_oCustomer, operationType),
                       commandType: CommandType.StoredProcedure).ToList();

                    if (oCustomers != null && oCustomers.Count() > 0)
                    {
                        _oCustomer = oCustomers.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return _oCustomer;
        }

        public List<Customer> GetCustomerList()
        {
            _oCustomer = new Customer();
            _oCustomers = new List<Customer>();

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

                    var oCustomers = con.Query<Customer>("[salespropos].[sp_Customers]",
                       _oCustomer.SetParameters(_oCustomer, operationType),
                       commandType: CommandType.StoredProcedure);


                    if (oCustomers != null && oCustomers.Count() > 0)
                    {
                        _oCustomers = oCustomers.ToList();
                    }
                }
            }
            catch (Exception ex)
            {


            }

            return _oCustomers;
        }

        public Customer UpdateCustomer(int customerId, Customer customer)
        {
            _oCustomer = new Customer();
            DateTime aDate = DateTime.Now;
            customer.Id = customerId;
            customer.Updated_at = aDate;

            try
            {
                int operationType = Convert.ToInt32(OperationType.Update);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oCustomers = con.Query<Customer>("[salespropos].[sp_Customers]",
                        _oCustomer.SetParameters(customer, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oCustomers != null && oCustomers.Count() > 0)
                    {
                        _oCustomer = oCustomers.FirstOrDefault();
                    }
                }
            }
            catch (Exception)
            {


            }

            return _oCustomer;
        }
    }
}
