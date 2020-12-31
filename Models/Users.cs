﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Inventory_Web_API.Models
{
    public class Users
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Age { get; set; }

        public string Address { get; set; }

        public string BirthDate { get; set; }

        public string EmailAddress { get; set; }

        public string Role { get; set; }


        public string Username { get; set; }

        //[JsonIgnore]
        public string Password { get; set; }

        public string IsActive { get; set; }

        
        public DateTime? DateCreated { get; set; }

        [IgnoreDataMember]
        public DateTime? LastLoginDate { get; set; }


        public string Message { get; set; }


        public DynamicParameters SetParameters(Users oUser, int operationType)
        {


            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserId", oUser.UserId);
            parameters.Add("@Name", oUser.Name);
            parameters.Add("@Age", oUser.Age);
            parameters.Add("@Address", oUser.Address);
            parameters.Add("@BirthDate", oUser.BirthDate);
            parameters.Add("@EmailAddress", oUser.EmailAddress);
            parameters.Add("@Role", oUser.Role);
            parameters.Add("@Username", oUser.Username);
            parameters.Add("@Password", oUser.Password);
            parameters.Add("@IsActive", oUser.IsActive);
            parameters.Add("@DateCreated", oUser.DateCreated);
            parameters.Add("@LastLoginDate", oUser.LastLoginDate);
            parameters.Add("@OperationType", operationType);

            return parameters;
        }

    }
}
