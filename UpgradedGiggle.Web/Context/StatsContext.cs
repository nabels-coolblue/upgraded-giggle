using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UpgradedGiggle.Context
{
    public class StatsContext : DbContext
    {
        public DbSet<UserStats> UserStats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./stats.db");
        }
    }

    public class UserStats
    {
        public int UserStatsId { get; set; }
        public string Nick { get; set; }
        public int NumberOfLines { get; set; }
    }
}
