using Microsoft.EntityFrameworkCore;
using ProductUnitDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMIgrations.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<ProductUnitModel> ProductUnits { get; set; }
        Task<int> SaveChangesAsync();
    }
}
