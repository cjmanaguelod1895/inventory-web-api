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
    public class CustomerGroupService : ICustomerGroupService
    {
        CustomerGroup _oCustomerGroup = new CustomerGroup();
        List<CustomerGroup> _oCustomerGroups = new List<CustomerGroup>();

        private readonly AppSettings _appSettings;

        public CustomerGroupService(IOptions<AppSettings> appsettings)
        {
            _appSettings = appsettings.Value;
        }
        public CustomerGroup AddCustomerGroup(CustomerGroup customerGroup)
        {
            _oCustomerGroup = new CustomerGroup();
            DateTime aDate = DateTime.Now;
            customerGroup.Created_at = aDate;

            try
            {
                int operationType = Convert.ToInt32(customerGroup.Id == 0 ? OperationType.Insert : OperationType.Update);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oCustomerGroup = con.Query<CustomerGroup>("[salespropos].[sp_CustomerGroups]",
                        _oCustomerGroup.SetParameters(customerGroup, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oCustomerGroup != null && oCustomerGroup.Count() > 0)
                    {
                        _oCustomerGroup = oCustomerGroup.FirstOrDefault();
                    }
                }
            }
            catch (Exception)
            {


            }

            return _oCustomerGroup;
        }

        public string Delete(int customerGroupId)
        {
            string message = "";

            try
            {
                _oCustomerGroup = new CustomerGroup()
                {
                    Id = customerGroupId
                };

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oCustomerGroup = con.Query<CustomerGroup>("[salespropos].[sp_CustomerGroup]",
                        _oCustomerGroup.SetParameters(_oCustomerGroup, (int)OperationType.Delete),
                        commandType: CommandType.StoredProcedure);

                    if (oCustomerGroup != null && oCustomerGroup.Count() > 0)
                    {
                        _oCustomerGroup = oCustomerGroup.FirstOrDefault();

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

        public CustomerGroup GetCustomerGroup(int customerGroupId)
        {
            _oCustomerGroup = new CustomerGroup()
            {
                Id = customerGroupId
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

                    var oCustomerGroup = con.Query<CustomerGroup>("[salespropos].[sp_CustomerGroup]",
                        _oCustomerGroup.SetParameters(_oCustomerGroup, operationType),
                       commandType: CommandType.StoredProcedure).ToList();

                    if (oCustomerGroup != null && oCustomerGroup.Count() > 0)
                    {
                        _oCustomerGroup = oCustomerGroup.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return _oCustomerGroup;
        }

        public List<CustomerGroup> GetCustomerGroupList()
        {
            _oCustomerGroup = new CustomerGroup();
            _oCustomerGroups = new List<CustomerGroup>();

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

                    var oCustomerGroup = con.Query<CustomerGroup>("[salespropos].[sp_CustomerGroup]",
                       _oCustomerGroup.SetParameters(_oCustomerGroup, operationType),
                       commandType: CommandType.StoredProcedure);


                    if (oCustomerGroup != null && oCustomerGroup.Count() > 0)
                    {
                        _oCustomerGroups = oCustomerGroup.ToList();
                    }
                }
            }
            catch (Exception ex)
            {


            }

            return _oCustomerGroups;
        }

        public CustomerGroup UpdateCustomerGroup(int customerGroupId, CustomerGroup customerGroup)
        {
            _oCustomerGroup = new CustomerGroup();
            DateTime aDate = DateTime.Now;
            customerGroup.Id = customerGroupId;
            customerGroup.Updated_at = aDate;

            try
            {
                int operationType = Convert.ToInt32(OperationType.Update);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oCustomerGroup = con.Query<CustomerGroup>("[salespropos].[sp_CustomerGroup]",
                        _oCustomerGroup.SetParameters(customerGroup, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oCustomerGroup != null && oCustomerGroup.Count() > 0)
                    {
                        _oCustomerGroup = oCustomerGroup.FirstOrDefault();
                    }
                }
            }
            catch (Exception)
            {


            }

            return _oCustomerGroup;
        }
    }
}
