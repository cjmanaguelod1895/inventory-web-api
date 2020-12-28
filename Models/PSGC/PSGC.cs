using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.Models.PSGC
{
    public class PSGC
    {
        public Barangay Barangay { get; set; }
        public CityMunicipality CityMunicipality { get; set; }
        public Province Province { get; set; }
        public Region Region { get; set; }

        

    }
    #region Barangay
    public class Barangay
    {
        public int BarangayId { get; set; }

        public string BarangayCode { get; set; }

        public string BarangayDescription { get; set; }

        public string RegCode { get; set; }

        public string ProvinceCode { get; set; }

        public string CityMunicipalityCode { get; set; }

        public string Message { get; set; }

        public DynamicParameters SetParameters(Barangay barangay, int operationType)
        {


            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@BarangayId", barangay.BarangayId);
            parameters.Add("@BarangayCode", barangay.BarangayCode);
            parameters.Add("@BarangayDescription", barangay.BarangayDescription);
            parameters.Add("@RegCode", barangay.RegCode);
            parameters.Add("@ProvinceCode", barangay.ProvinceCode);
            parameters.Add("@CityMunicipalityCode", barangay.CityMunicipalityCode);
            parameters.Add("@OperationType", operationType);

            return parameters;
        }
    }
    #endregion

    #region CityMunicipality
    public class CityMunicipality
    {
        public int MunicipalityId { get; set; }

        public string PSGCCode { get; set; }

        public string CityMunDescription { get; set; }

        public string RegDescription { get; set; }

        public string ProvinceCode { get; set; }

        public string CityMunCode { get; set; }

        public string Message { get; set; }

        public DynamicParameters SetParameters(CityMunicipality cityMunicipality, int operationType)
        {


            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@MunicipalityId", cityMunicipality.MunicipalityId);
            parameters.Add("@PSGCCode", cityMunicipality.PSGCCode);
            parameters.Add("@CityMunDescription", cityMunicipality.CityMunDescription);
            parameters.Add("@RegDescription", cityMunicipality.RegDescription);
            parameters.Add("@ProvinceCode", cityMunicipality.ProvinceCode);
            parameters.Add("@CityMunCode", cityMunicipality.CityMunCode);
            parameters.Add("@OperationType", operationType);

            return parameters;
        }
    }
    #endregion

    #region Province
    public class Province
    {
        public int ProvinceId { get; set; }

        public string PSGCCode { get; set; }

        public string ProvinceDescription { get; set; }

        public string RegCode { get; set; }

        public string ProvinceCode { get; set; }

        public string Message { get; set; }

        public DynamicParameters SetParameters(Province province, int operationType)
        {


            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ProvinceId", province.ProvinceId);
            parameters.Add("@PSGCCode", province.PSGCCode);
            parameters.Add("@ProvinceDescription", province.ProvinceDescription);
            parameters.Add("@RegCode", province.RegCode);
            parameters.Add("@ProvinceCode", province.ProvinceCode);
            parameters.Add("@OperationType", operationType);

            return parameters;
        }
    }

    #endregion

    #region Region
    public class Region
    {
        public int RegionId { get; set; }

        public string PSGCCode { get; set; }

        public string RegDesc { get; set; }

        public string RegCode { get; set; }

        public string Message { get; set; }

        public DynamicParameters SetParameters(Region region, int operationType)
        {


            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@RegionId", region.RegionId);
            parameters.Add("@PSGCCode", region.PSGCCode);
            parameters.Add("@RegDesc", region.RegDesc);
            parameters.Add("@RegCode", region.RegCode);
            parameters.Add("@OperationType", operationType);

            return parameters;
        }
    }
    #endregion

}
