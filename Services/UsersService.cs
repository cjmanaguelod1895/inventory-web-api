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
        private readonly IConfiguration _iConfig;

        public UsersService(IOptions<AppSettings> appsettings,  IConfiguration iConfig)
        {
            _appSettings = appsettings.Value;
            _iConfig = iConfig;
        }



        public List<Users> GetAllUsers()
        {
            string conn = _iConfig.GetValue<string>("MySettings:ConnectionStrings");

            _oUser = new Users();
            _oUsers = new List<Users>();

            try
            {
                int operationType = Convert.ToInt32(OperationType.SelectAll);

                using (IDbConnection con = new SqlConnection(conn))
                {
                    if (con.State != ConnectionState.Closed)
                    {
                    }
                    else
                    {
                        con.Open();
                    }

                    var oUsers = con.Query<Users>("sp_Users",
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

                _oUser.Message = ex.Message;
            }

            return _oUsers;
        }

        public Users GetUser(int userID)
        {
            string conn = _iConfig.GetValue<string>("MySettings:ConnectionStrings");

            _oUser = new Users()
            {
                UserId = userID
            };

            try
            {
                int operationType = Convert.ToInt32(OperationType.SelectSpecific);

                using (IDbConnection con = new SqlConnection(conn))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oUsers = con.Query<Users>("sp_Users",
                        _oUser.SetParameters(_oUser, operationType),
                       commandType: CommandType.StoredProcedure).ToList();

                    if (oUsers != null && oUsers.Count() > 0)
                    {
                        _oUser = oUsers.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _oUser.Message = ex.Message;
            }

            return _oUser;
        }


        public Users AddUser(Users users)
        {
            string conn = _iConfig.GetValue<string>("MySettings:ConnectionStrings");

            _oUser = new Users();

            try
            {
                int operationType = Convert.ToInt32(users.UserId == 0 ? OperationType.Insert : OperationType.Update);

                using (IDbConnection con = new SqlConnection(conn))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oUsers = con.Query<Users>("sp_Users",
                        _oUser.SetParameters(users, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oUsers != null && oUsers.Count() > 0)
                    {
                        _oUser = oUsers.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _oUser.Message = ex.Message;
            }

            return _oUser;


        }

        public Users UpdateUser(int userId, Users user)
        {
            string conn = _iConfig.GetValue<string>("MySettings:ConnectionStrings");

            _oUser = new Users();
            user.UserId = userId;

            try
            {
                int operationType = Convert.ToInt32(OperationType.Update);

                using (IDbConnection con = new SqlConnection(conn))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oUsers = con.Query<Users>("sp_Users",
                        _oUser.SetParameters(user, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oUsers != null && oUsers.Count() > 0)
                    {
                        _oUser = oUsers.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _oUser.Message = ex.Message;
            }

            return _oUser;
        }

        public string Delete(int userId)
        {
            string conn = _iConfig.GetValue<string>("MySettings:ConnectionStrings");

            string message = "";

            try
            {
                _oUser = new Users()
                {
                    UserId = userId
                };

                using (IDbConnection con = new SqlConnection(conn))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oUsers = con.Query<Users>("sp_Users",
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
