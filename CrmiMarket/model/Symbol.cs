using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmiMarket.model
{
    public class Symbol
    {
              
       [Key]
        public int SymbolId { get; set; }
        public string Name { get; set; }

        
        

        public ICollection<DayStock> DayStocks { get; set; }
        public ICollection<FourHour> FourHours { get; set; }
        public ICollection<Hour> Hours { get; set; }
        public ICollection<HalfHour> HalfHours { get; set; }

        



    }
}
