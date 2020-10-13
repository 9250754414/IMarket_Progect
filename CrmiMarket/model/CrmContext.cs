using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmiMarket.model
{
    public class CrmContext: DbContext
    {
        public CrmContext() : base("iMarketConnect") { }
        public DbSet<DayStock> days { get; set; }
        public DbSet<FourHour> fourHours { get; set; }
        public DbSet<Hour> hours { get; set; }
        public DbSet<HalfHour> halfHours { get; set; }
        public DbSet<Symbol> Symbols { get; set; }

       
       
    }
}
