using Inventory_Web_API.Models.PSGC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.IServices
{
    public interface ICityMunicipalityService
    {
        List<CityMunicipality> GetCityMunicipalities();

        CityMunicipality GetCityMunicipality(int cityMunicipalityId);

        CityMunicipality AddCityMunicipality(CityMunicipality cityMunicipalities);

        CityMunicipality UpdateMunicipality(int cityMunicipalityId, CityMunicipality cityMunicipalities);

        string Delete(int cityMunicipalityId);
    }
}
