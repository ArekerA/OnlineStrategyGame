using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineStrategyGame.Database.MSSQL.Models;

namespace OnlineStrategyGame.Database.MSSQL
{
    public class ApplicationDbContext : IdentityDbContext<AppIdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
