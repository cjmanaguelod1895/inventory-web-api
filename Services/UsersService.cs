using Dapper;
using Inventory_Web_API.Common;
using Inventory_Web_API.Helpers;
using Inventory_Web_API.IServices;
using Inventory_Web_API.Models;
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
    public class UsersService : IUsersService
    {
        Users _oUser = new Users();
        List<Users> _oUsers = new List<Users>();

        private readonly AppSettings _appSettings;

        public UsersService(IOptions<AppSettings> appsettings)
        {
            _appSettings = appsettings.Value;
        }


        public List<Users> GetAllUsers()
        {
            _oUser = new Users();
            _oUsers = new List<Users>();

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

                    var oUsers = con.Query<Users>("[salespropos].[sp_Users]",
                       _oUser.SetParameters(_oUser, operationType),
                       commandType: CommandType.StoredProcedure);


                    if (oUsers != null && oUsers.Count() > 0)
                    {
                        _oUsers = oUsers.ToList();
                    }
                }
            }
            catch (Exception ex)
            {

                
            }

            return _oUsers;
        }

        public Users GetUser(int userID)
        {

            _oUser = new Users()
            {
                Id = userID
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

                    var oUsers = con.Query<Users>("[salespropos].[sp_Users]",
                        _oUser.SetParameters(_oUser, operationType),
                       commandType: CommandType.StoredProcedure).ToList();

                    if (oUsers != null && oUsers.Count() > 0)
                    {
                        _oUser = oUsers.SingleOrDefault();
                    }
                }
            }
            catch (Exception)
            {

            }

            return _oUser;
        }


        public Users AddUser(Users users)
        {

            _oUser = new Users();
            DateTime aDate = DateTime.Now;
            users.Password = EncryptAndDecrypt.ConvertToEncrypt(users.Password);
            users.Created_at = aDate;
            users.Updated_at = aDate;

            try
            {
                int operationType = Convert.ToInt32(users.Id == 0 ? OperationType.Insert : OperationType.Update);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oUsers = con.Query<Users>("[salespropos].[sp_Users]",
                        _oUser.SetParameters(users, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oUsers != null && oUsers.Count() > 0)
                    {
                        _oUser = oUsers.FirstOrDefault();
                    }
                }
            }
            catch (Exception)
            {

               
            }

            return _oUser;


        }

        public Users UpdateUser(int userId, Users user)
        { 

            _oUser = new Users();
            DateTime aDate = DateTime.Now;
            user.Id = userId;
            user.Updated_at = aDate;

            try
            {
                int operationType = Convert.ToInt32(OperationType.Update);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oUsers = con.Query<Users>("[salespropos].[sp_Users]",
                        _oUser.SetParameters(user, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oUsers != null && oUsers.Count() > 0)
                    {
                        _oUser = oUsers.FirstOrDefault();
                    }
                }
            }
            catch (Exception)
            {

               
            }

            return _oUser;
        }

        public string Delete(int userId)
        {

            string message = "";

            try
            {
                _oUser = new Users()
                {
                    Id = userId
                };

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oUsers = con.Query<Users>("[salespropos].[sp_Users]",
                        _oUser.SetParameters(_oUser, (int)OperationType.Delete),
                        commandType: CommandType.StoredProcedure);

                    if (oUsers != null && oUsers.Count() > 0)
                    {
                        _oUser = oUsers.FirstOrDefault();

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
