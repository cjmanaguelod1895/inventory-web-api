﻿using Dapper;
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
    public class BillerService : IBillerService
    {
        Biller _oBiller = new Biller();
        List<Biller> _oBillers = new List<Biller>();

        private readonly AppSettings _appSettings;

        public BillerService(IOptions<AppSettings> appsettings)
        {
            _appSettings = appsettings.Value;
        }


        public Biller AddBiller(Biller biller)
        {
            _oBiller = new Biller();
            DateTime aDate = DateTime.Now;
            biller.Created_at = aDate;

            try
            {
                int operationType = Convert.ToInt32(biller.Id == 0 ? OperationType.Insert : OperationType.Update);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oBillers = con.Query<Biller>("[salespropos].[sp_Billers]",
                        _oBiller.SetParameters(biller, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oBillers != null && oBillers.Count() > 0)
                    {
                        _oBiller = oBillers.FirstOrDefault();
                    }
                }
            }
            catch (Exception)
            {


            }

            return _oBiller;
        }

        public string Delete(int billerId)
        {
            string message = "";

            try
            {
                _oBiller = new Biller()
                {
                    Id = billerId
                };

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oBillers = con.Query<Biller>("[salespropos].[sp_Billers]",
                        _oBiller.SetParameters(_oBiller, (int)OperationType.Delete),
                        commandType: CommandType.StoredProcedure);

                    if (oBillers != null && oBillers.Count() > 0)
                    {
                        _oBiller = oBillers.FirstOrDefault();

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

        public Biller GetBiller(int billerId)
        {
            _oBiller = new Biller()
            {
                Id = billerId
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

                    var oBiller = con.Query<Biller>("[salespropos].[sp_Billers]",
                        _oBiller.SetParameters(_oBiller, operationType),
                       commandType: CommandType.StoredProcedure).ToList();

                    if (oBiller != null && oBiller.Count() > 0)
                    {
                        _oBiller = oBiller.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return _oBiller;
        }

        public List<Biller> GetBillerList()
        {
           

            _oBiller = new Biller();
            _oBillers = new List<Biller>();

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

                    var oBillers = con.Query<Biller>("[salespropos].[sp_Billers]",
                       _oBiller.SetParameters(_oBiller, operationType),
                       commandType: CommandType.StoredProcedure);


                    if (oBillers != null && oBillers.Count() > 0)
                    {
                        _oBillers = oBillers.ToList();
                    }
                }
            }
            catch (Exception ex)
            {


            }

            return _oBillers;
        }

        public Biller UpdateBiller(int billerId, Biller biller)
        {
            _oBiller = new Biller();
            DateTime aDate = DateTime.Now;
            biller.Id = billerId;
            biller.Updated_at = aDate;

            try
            {
                int operationType = Convert.ToInt32(OperationType.Update);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oBillers = con.Query<Biller>("[salespropos].[sp_Billers]",
                        _oBiller.SetParameters(biller, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oBillers != null && oBillers.Count() > 0)
                    {
                        _oBiller = oBillers.FirstOrDefault();
                    }
                }
            }
            catch (Exception)
            {


            }

            return _oBiller;
        }
    }
}