﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.Models
{
    public class Login
    {
        public string Username { get; set; }

        public int Role_id { get; set; }

        public string Password { get; set; }


    }
}
