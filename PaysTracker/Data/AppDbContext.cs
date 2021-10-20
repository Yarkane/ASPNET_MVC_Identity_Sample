using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaysTracker.Models;

namespace PaysTracker.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Pays> ListePays { get; set; }
        public DbSet<Regime> ListeRegimes { get; set; }

    }
}
