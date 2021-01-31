using Inventory_Web_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.IServices
{
    public interface ISupplierService
    {
        List<Supplier> GetSupplierList();

        Supplier GetSupplier(int supplierId);

        Supplier AddSupplier(Supplier supplier);

        Supplier UpdateSupplier(int supplierId, Supplier supplier);


        string Delete(int supplierId);
    }
}
