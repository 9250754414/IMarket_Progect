using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmiMarket.model
{
    public class DayStock 
    {
        
        
        public int DayStockId { get; set; }
        public Symbol symbol { get; set; }
        public decimal Open { get; set; }
        public decimal Close { get; set; }
        public decimal Max { get; set; }
        public decimal Min { get; set; }
        public DateTime Date { get; set; }

        public DayStock()
        {

        }
        public DayStock(DateTime date, decimal open, decimal close, decimal max, decimal min)
        {
            Date = date;
            Open = open;
            Close = close;
            Max = max;
            Min = min;
            
        }
    }
}

