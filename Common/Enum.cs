﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.Common
{
    public enum OperationType
    {
        SelectAll = 0,
        SelectSpecific = 1,
        Insert = 2,
        Update = 3,
        Delete = 4,
        Login = 5

    }

    public enum SettingServices
    {
        Roles = 1
    }
}
