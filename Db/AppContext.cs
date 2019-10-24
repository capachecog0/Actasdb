using Db.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace Db
{    public class AppContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\Mexbol\source\repos\Db\Db\CustomerDB.db");            
        }

        public DbSet<ActaPublicada> Actas { get; set; }


    }
}
