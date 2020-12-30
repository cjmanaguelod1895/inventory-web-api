using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_Web_API.IServices;
using Inventory_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Web_API.Controllers
{
    [ApiExplorerSettings(GroupName = "Login CRUD Endpoint")]
    [Route("Inventory/[controller]")]
    [ApiController]
    public class Login : ControllerBase
    {
        private ILoginService _oLoginService;
        public Login(ILoginService oLoginService)
        {
            _oLoginService = oLoginService;
        }

        /// <summary>
        /// Login Autentication.
        /// </summary>
        /// <returns>Login Authentication</returns>
        // POST: Inventory/Login
        [HttpPost]
        public IActionResult Authenticate(AuthenticateRequest model)
        {

            if (model == null)
            {
                return Unauthorized();
            }

            var userAccount = _oLoginService.Authenticate(model);

            if (userAccount.Token == null || userAccount.Token == "")
            {
                return BadRequest(new { message = "Incorrect username or password" });
            }

            return Ok(userAccount);
        }
    }
}
