﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStrategyGame.Database.MSSQL.Models
{
    public class AppIdentityUser : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }
    }
}