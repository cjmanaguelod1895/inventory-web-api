using Dapper;
using Inventory_Web_API.Common;
using Inventory_Web_API.Helpers;
using Inventory_Web_API.IServices;
using Inventory_Web_API.Models;
using Inventory_Web_API.Models.PSGC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Web_API.Services
{
    public class LoginService : ILoginService
    {
        Users _oUser = new Users();
        PSGC _psgc = new PSGC();
        private readonly AppSettings _appSettings;


        public LoginService(IOptions<AppSettings> appsettings)
        {
            _appSettings = appsettings.Value;
        }


        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            DateTime currentDate = DateTime.UtcNow.AddHours(8);
            var token = "";
            model.Password = EncryptAndDecrypt.ConvertToEncrypt(model.Password);

            _oUser = new Users()
            {
                Username = model.Username,
                Password = model.Password,
                Last_login_date = currentDate
            };

            try
            {
                int operationType = Convert.ToInt32(OperationType.Login);

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
                        _oUser = oUsers.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);


                        // authentication successful so generate jwt token
                        token = GenerateJWTToken(_oUser);
                    }
                }

                // return null if user not found
                if (_oUser == null) { return null; };


            }
            catch (Exception ex)
            {

                throw;
            }

            return new AuthenticateResponse(_oUser, token);
        }


        private string GenerateJWTToken(Users user)
        {
            //generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("userId", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }

    }
}
