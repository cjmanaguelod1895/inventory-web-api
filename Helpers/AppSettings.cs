﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.Helpers
{
    public class AppSettings
    {
        public static string ConnectionStrings { get; set; }
        public string Secret { get; set; }
    }
}
