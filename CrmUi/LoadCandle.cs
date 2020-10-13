using CrmiMarket.Classes;
using CrmiMarket.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CrmUi
{

    public delegate void LoadCandleDelegate();
    public class LoadCandle
    {
        CrmContext db = new CrmContext();
        PropertySymbol propertySymbol = new PropertySymbol();
        public event LoadCandleDelegate LoadcandleEvent = null;
        public void InvokeEvent()
        {
            LoadcandleEvent.Invoke();
        }
        /// <summary>
        /// Метод выгрузки данных в DataTabel из файл XLS
        /// </summary>
        /// <param name="PathTofilename">Путь к файлу</param>
        /// <param name="sheetName">Имя фвйла</param>
        /// <returns></returns>
        public DataTable LoadExelSheetToTable(string PathTofilename, string sheetName)
        {

            DataTable table = new DataTable();
            using (System.Data.OleDb.OleDbConnection connect = new System.Data.OleDb.OleDbConnection(
                                                             "Provider = Microsoft.ACE.OLEDB.12.0; " +
                                                             "Data Source = '" + PathTofilename + "';" +
                                                             "Extended Properties=\"Excel 12.0; HDR=YES;IMEX=1\""))
                
            using (System.Data.OleDb.OleDbDataAdapter import =
              new System.Data.OleDb.OleDbDataAdapter
                  ("select * from [" + sheetName + "$]", connect))
                
                import.Fill(table);
            
            return table;
        }
        public void LoadDayStocksCandle(Symbol h, string pathtofile)
        {
            var tableDayStock = LoadExelSheetToTable(@"D:\DDE1.xlsx", pathtofile);
            h.DayStocks = new Collection<DayStock>();
            DayStock interval1 = new DayStock();
            foreach (DataRow p in tableDayStock.Rows)
            {

                interval1.Open = Convert.ToDecimal(p["Bid"]);
                interval1.Max = Convert.ToDecimal(p["High"]);
                interval1.Min = Convert.ToDecimal(p["low"]);
                interval1.Date = Convert.ToDateTime(p["Time"]);
                Thread.Sleep(90000);


            }
            
            var table2 = LoadExelSheetToTable(@"D:\DDE1.xlsx", pathtofile);
            foreach (DataRow j in table2.Rows)
            {
                interval1.Close = Convert.ToDecimal(j["Ask"]);
            }

            h.DayStocks.Add(interval1);
            db.days.Add(interval1);
        }
        public void LoadFourHoursCandle(Symbol h, string pathtofile)
        {
            var tableFourHour = LoadExelSheetToTable(@"D:\DDE1.xlsx", pathtofile);
            h.FourHours = new Collection<FourHour>();
            FourHour interval2 = new FourHour();
            foreach (DataRow p in tableFourHour.Rows)
            {
                interval2.Open = Convert.ToDecimal(p["Bid"]);
                interval2.Max = Convert.ToDecimal(p["High"]);
                interval2.Min = Convert.ToDecimal(p["low"]);
                interval2.Date = Convert.ToDateTime(p["Time"]);

            }
            Thread.Sleep(90000);
            var table3 = LoadExelSheetToTable(@"D:\DDE1.xlsx", pathtofile);
            foreach (DataRow j in table3.Rows)
            {
                interval2.Close = Convert.ToDecimal(j["Ask"]);
            }

            h.FourHours.Add(interval2);
            db.fourHours.Add(interval2);
        }
        public void LoadHoursCandle(Symbol h, string pathtofile)
        {
            var tableHour = LoadExelSheetToTable(@"D:\DDE1.xlsx", pathtofile);
            h.Hours = new Collection<Hour>();
            Hour interval3 = new Hour();
            foreach (DataRow p in tableHour.Rows)
            {

                interval3.Open = Convert.ToDecimal(p["Bid"]);
                interval3.Max = Convert.ToDecimal(p["High"]);
                interval3.Min = Convert.ToDecimal(p["low"]);
                interval3.Date = Convert.ToDateTime(p["Time"]);



            }
            Thread.Sleep(90000);
            var table4 = LoadExelSheetToTable(@"D:\DDE1.xlsx", pathtofile);
            foreach (DataRow j in table4.Rows)
            {
                interval3.Close = Convert.ToDecimal(j["Ask"]);
            }

            h.Hours.Add(interval3);
            db.hours.Add(interval3);
        }
        public void LoadHalfHoursCandle(Symbol h, string pathtofile)
        {
            var tableHalfHours = LoadExelSheetToTable(@"D:\DDE1.xlsx", pathtofile);
            h.HalfHours = new Collection<HalfHour>();
            HalfHour interval4 = new HalfHour();
            foreach (DataRow p in tableHalfHours.Rows)
            {

                interval4.Open = Convert.ToDecimal(p["Bid"]);
                interval4.Max = Convert.ToDecimal(p["High"]);
                interval4.Min = Convert.ToDecimal(p["low"]);
                interval4.Date = Convert.ToDateTime(p["Time"]);



            }
            Thread.Sleep(90000);
            var table5 = LoadExelSheetToTable(@"D:\DDE1.xlsx", pathtofile);
            foreach (DataRow j in table5.Rows)
            {
                interval4.Close = Convert.ToDecimal(j["Ask"]);
            }
            h.HalfHours.Add(interval4);
            db.halfHours.Add(interval4);
        }
        public LoadCandle()
        {

        }
        public void LoadNewCandle(List<PropertySymbol> collectionSymbols, string flag)
        {
            
            
            foreach (var k in collectionSymbols)
            {

                foreach (var t in k.properties)
                {

                    if (t.Equals("DayStocks") && flag == "DayStocks")
                    {
                        Task.Run(() => LoadStocksCandle(k, flag, "DDE1"));
                    }
                    if (t.Equals("FourHours") && flag == "FourHours")
                    {
                        LoadStocksCandle(k, flag, "DDE1");
                    }
                    if (t.Equals("Hours") && flag == "Hours")
                    {
                        LoadStocksCandle(k, flag, "DDE1");
                    }
                    if (t.Equals("HalfHours") && flag == "HalfHours")
                    {
                        LoadStocksCandle(k, flag, "DDE1");
                    }

                }



            }
        }
        // Дополнить метод, добавив флаги, стринг 4часа, час. + стринг имя таблицы.
        private void LoadStocksCandle(PropertySymbol k, string interval, string pathtofile)
        {
            
            string constring = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = iMarketDB; Integrated Security = True";
            var SqlConnection = new SqlConnection(constring);
            SqlConnection.Open();
            var result = from s in db.Symbols
                         where s.Name == k.Name.ToString()
                         select s;

            
            foreach (Symbol h in result)
            {
                if(interval == "DayStocks")
                {
                    Task.Run(() => LoadDayStocksCandle(h, pathtofile));
                }
                if(interval == "FourHours")
                {
                    Task.Run(() => LoadFourHoursCandle(h, pathtofile));
                }
                if(interval == "Hours")
                {
                    Task.Run(() => LoadHoursCandle(h, pathtofile));
                }
                if(interval == "HalfHours")
                {
                    Task.Run(() => LoadHalfHoursCandle(h, pathtofile));
                }
                
            }
            db.SaveChanges();
            SqlConnection.Close();
        }
    }
}
