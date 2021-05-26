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
    public class GeneralSettingsService : IGeneralSettings
    {
        GeneralSettings _oGeneralSetting = new GeneralSettings();

        private readonly AppSettings _appSettings;
        private IUploadImageService _uploadImageSservice;

        public GeneralSettingsService(IOptions<AppSettings> appsettings, IUploadImageService uploadImageSservice)
        {
            _appSettings = appsettings.Value;
            _uploadImageSservice = uploadImageSservice;

        }

        public GeneralSettings GetGeneralSettings()
        {
            try
            {
                int operationType = Convert.ToInt32(OperationType.SelectSpecific);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oGeneralSettings = con.Query<GeneralSettings>("[salespropos].[sp_GeneralSettings]",
                        _oGeneralSetting.SetParameters(_oGeneralSetting, operationType),
                       commandType: CommandType.StoredProcedure).ToList();

                    if (oGeneralSettings != null && oGeneralSettings.Count() > 0)
                    {
                        _oGeneralSetting = oGeneralSettings.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return _oGeneralSetting;
        }

        public GeneralSettings UpdateGeneralSettings(GeneralSettings oGeneralSettings)
        {

            _oGeneralSetting = new GeneralSettings();
            DateTime aDate = DateTime.Now;
            oGeneralSettings.Created_at = aDate;
            oGeneralSettings.Updated_at = aDate;

            try
            {
                int operationType = Convert.ToInt32(OperationType.Update);

                using (IDbConnection con = new SqlConnection(AppSettings.ConnectionStrings))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var getGeneralSetting = this.GetGeneralSettings();

                    //if (getGeneralSetting.ImageFile != null)
                    //{
                    //    if (!string.IsNullOrEmpty(getGeneralSetting.Image))
                    //    {
                    //        _uploadImageSservice.DeleteImage(getBiller.Image, "Biller");
                    //        _oGeneralSettings.Image = _uploadImageSservice.SaveImage(biller.ImageFile, billerId, "Biller");
                    //        biller.Image = _oGeneralSettings.Image;

                    //    }
                    //}

                    var oGeneralSetting = con.Query<GeneralSettings>("[salespropos].[sp_GeneralSettings]",
                        _oGeneralSetting.SetParameters(_oGeneralSetting, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oGeneralSetting != null && oGeneralSetting.Count() > 0)
                    {
                        _oGeneralSetting = oGeneralSetting.FirstOrDefault();
                    }



                }
            }
            catch (Exception)
            {


            }

            return _oGeneralSetting;
        }
    }
}
