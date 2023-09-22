using DatabaseMIgrations.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using ProductUnitDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMIgrations.Services
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ProductUnitModel> ProductUnits { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}