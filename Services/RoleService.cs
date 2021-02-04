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
    public class RoleService : IRoleService
    {
        PSGC _psgc = new PSGC();
        Role _role = new Role();
        List<Role> _roleList = new List<Role>();


        private readonly AppSettings _appSettings;

        public RoleService(IOptions<AppSettings> appsettings)
        {
            _appSettings = appsettings.Value;
        }

        public List<Role> GetRoleList()
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

                    var oRoleList = con.Query<Role>("[salespropos].[sp_Roles]",
                       _role.SetParameters(_role, operationType),
                       commandType: CommandType.StoredProcedure);


                    if (oRoleList != null && oRoleList.Count() > 0)
                    {
                        _roleList = oRoleList.ToList();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _roleList;
        }

        public Role GetRole(int roleId)
        {
            _role = new Role()
            {
                Id = roleId
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

                    var oRoleList = con.Query<Role>("[salespropos].[sp_Roles]",
                        _role.SetParameters(_role, operationType),
                       commandType: CommandType.StoredProcedure).ToList();

                    if (oRoleList != null && oRoleList.Count() > 0)
                    {
                        _role = oRoleList.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _role;
        }

        public Role AddRole(Role role)
        {
            try
            {
                int operationType = Convert.ToInt32(role.Id == 0 ? OperationType.Insert : OperationType.Update);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oRoleList = con.Query<Role>("[salespropos].[sp_Roles]",
                       _role.SetParameters(role, operationType),
                       commandType: CommandType.StoredProcedure); ;

                    if (oRoleList != null && oRoleList.Count() > 0)
                    {
                        _role = oRoleList.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _role;
        }

        public Role UpdateRole(int roleId, Role role)
        {
            role.Id = roleId;

            try
            {
                int operationType = Convert.ToInt32(OperationType.Update);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oRoleList = con.Query<Role>("[salespropos].[sp_Roles]",
                        _role.SetParameters(role, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oRoleList != null && oRoleList.Count() > 0)
                    {
                        _role = oRoleList.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _psgc.Message = ex.Message;
            }

            return _role;
        }

        public string Delete(int roleId)
        {
            string message = "";

            try
            {
                _role = new Role()
                {
                    Id = roleId
                };

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oRoleList = con.Query<Role>("[salespropos].[sp_Roles]",
                        _role.SetParameters(_role, (int)OperationType.Delete),
                        commandType: CommandType.StoredProcedure);

                    if (oRoleList != null && oRoleList.Count() > 0)
                    {
                        _role = oRoleList.FirstOrDefault();

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
