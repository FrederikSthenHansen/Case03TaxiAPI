using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewYorkTaxi.DataContext
{
    public class TaxiContext: DbContext

    {
        public DbSet<AvgPassenger> TaxiData { get; set; }
    }
}
