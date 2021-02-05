using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.Models
{
    public class AuthenticateResponse
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int Role_id { get; set; }

        public string Role { get; set; }

        public string Token { get; set; }

        public int Is_active { get; set; }

        public AuthenticateResponse(Users user, string token)
        {
            UserId = user.Id;
            Name = user.Name;
            Email = user.Email;
            Role_id = user.Role_id;
            Role = user.Role;
            Token = token;
            Is_active = user.Is_active;
        }

    }
}
