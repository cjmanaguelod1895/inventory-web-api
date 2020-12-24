using Dapper;
using Inventory_Web_API.Common;
using Inventory_Web_API.Helpers;
using Inventory_Web_API.IServices;
using Inventory_Web_API.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        List<Users> _oUsers = new List<Users>();

        private readonly AppSettings _appSettings;

        private readonly IConfiguration _iConfig;

        public LoginService(IOptions<AppSettings> appsettings, IConfiguration iConfig)
        {
            _appSettings = appsettings.Value;
            _iConfig = iConfig;
        }


        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            string conn = _iConfig.GetValue<string>("MySettings:ConnectionStrings");

            var token = "";
            _oUsers = new List<Users>();

            _oUser = new Users()
            {
                Username = model.Username,
                Password = model.Password
            };

            try
            {
                int operationType = Convert.ToInt32(OperationType.Login);

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
                        _oUser = oUsers.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);


                        // authentication successful so generate jwt token
                        token = GenerateJWTToken(_oUser);
                    }
                }

                // return null if user not found
                if (_oUser == null) { return null; };


            }
            catch (Exception)
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
                Subject = new ClaimsIdentity(new[] { new Claim("userId", user.UserId.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
