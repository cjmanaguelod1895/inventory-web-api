using Inventory_Web_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.IServices
{
    public interface IBillerService
    {
        List<Biller> GetBillerList();

        Biller GetBiller(int billerId);

        Biller AddBiller(Biller biller);

        Biller UpdateBiller(int billerId, Biller biller);


        string Delete(int billerId);
    }
}
