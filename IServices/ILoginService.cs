using Inventory_Web_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.IServices
{
    public interface ILoginService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
    }
}
