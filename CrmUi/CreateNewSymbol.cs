using CrmiMarket.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CrmUi
{
    public partial class CreateNewSymbol : Form
    {
        CrmContext db;
        private SqlConnection sqlConnection = null;
        LoadCandle loadCandle = new LoadCandle();
        
        public CreateNewSymbol()
        {
            Data.symbolNameList = new List<string>();
            InitializeComponent();
            db = new CrmContext();
            //Database.SetInitializer(new System.Data.Entity.CreateDatabaseIfNotExists<CrmContext>());
            comboBox.SelectedIndexChanged += comboBox_SelectedIndexChanged;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            List<string> symbolNameList1 = db.Symbols.Where(c => c.Name == c.Name).Select(c => c.Name).ToList();
            foreach (var n in symbolNameList1)
            {

                listBox1.Items.Add(n);
            }


        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox.SelectedIndex == 0)
            {
                Data.checkinterval = "Day";
            }
            if (comboBox.SelectedIndex == 1)
            {
                Data.checkinterval = "FourHour";
            }
            if (comboBox.SelectedIndex == 2)
            {
                Data.checkinterval = "Hour";
            }
            if (comboBox.SelectedIndex == 3)
            {
                Data.checkinterval = "HalfHour";
            }




        }

        private void button1_Click(object sender, EventArgs e)
        {
            createSymbol();
            
        }

        private void PlaceTableToDataTable(DataTable table, string Name)
        {
            if (Data.symbolNameList.Count == 0)
            {
                Symbol symbol1 = new Symbol();
                symbol1.Name = textBoxNameSymbol.Text.ToString(); ;

                switch (Name)
                {
                    case "Day":

                        symbol1.DayStocks = new Collection<DayStock>();
                        foreach (DataRow t in table.Rows)
                        {
                            DayStock interval = new DayStock();
                            interval.Open = Convert.ToDecimal(t["Open"]);
                            interval.Close = Convert.ToDecimal(t["Close"]);
                            interval.Max = Convert.ToDecimal(t["High"]);
                            interval.Min = Convert.ToDecimal(t["low"]);
                            interval.Date = Convert.ToDateTime(t["Date"]);
                            symbol1.DayStocks.Add(interval);

                        }
                        db.Symbols.Add(symbol1);
                        db.SaveChanges();
                        break;
                    case "FourHour":
                        symbol1.FourHours = new Collection<FourHour>();
                        foreach (DataRow t in table.Rows)
                        {
                            FourHour interval = new FourHour();
                            interval.Open = Convert.ToDecimal(t["Open"]);
                            interval.Close = Convert.ToDecimal(t["Close"]);
                            interval.Max = Convert.ToDecimal(t["High"]);
                            interval.Min = Convert.ToDecimal(t["low"]);
                            interval.Date = Convert.ToDateTime(t["Date"]);
                            symbol1.FourHours.Add(interval);
                        }
                        db.Symbols.Add(symbol1);
                        db.SaveChanges();
                        break;
                    case "Hour":
                        symbol1.Hours = new Collection<Hour>();
                        foreach (DataRow t in table.Rows)
                        {
                            Hour interval = new Hour();
                            interval.Open = Convert.ToDecimal(t["Open"]);
                            interval.Close = Convert.ToDecimal(t["Close"]);
                            interval.Max = Convert.ToDecimal(t["High"]);
                            interval.Min = Convert.ToDecimal(t["low"]);
                            interval.Date = Convert.ToDateTime(t["Date"]);
                            symbol1.Hours.Add(interval);
                        }
                        db.Symbols.Add(symbol1);
                        db.SaveChanges();
                        break;
                    case "HalfHour":
                        symbol1.HalfHours = new Collection<HalfHour>();
                        foreach (DataRow t in table.Rows)
                        {
                            HalfHour interval = new HalfHour();
                            interval.Open = Convert.ToDecimal(t["Open"]);
                            interval.Close = Convert.ToDecimal(t["Close"]);
                            interval.Max = Convert.ToDecimal(t["High"]);
                            interval.Min = Convert.ToDecimal(t["low"]);
                            interval.Date = Convert.ToDateTime(t["Date"]);
                            symbol1.HalfHours.Add(interval);
                        }
                        break;

                }

            }
            else if (Data.symbolNameList.Contains(textBoxNameSymbol.Text))
            {
                switch (Name)
                {
                    case "Day":

                        string constring = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = iMarketDB; Integrated Security = True";
                        sqlConnection = new SqlConnection(constring);
                        sqlConnection.Open();
                        var result = from k in db.Symbols
                                     where k.Name == textBoxNameSymbol.Text
                                     select k;
                        foreach (var l in result)
                        {
                            l.DayStocks = new Collection<DayStock>();
                            foreach (DataRow t in table.Rows)
                            {

                                DayStock interval = new DayStock();
                                interval.Open = Convert.ToDecimal(t["Open"]);
                                interval.Close = Convert.ToDecimal(t["Close"]);
                                interval.Max = Convert.ToDecimal(t["High"]);
                                interval.Min = Convert.ToDecimal(t["low"]);
                                interval.Date = Convert.ToDateTime(t["Date"]);

                                l.DayStocks.Add(interval);
                                db.days.Add(interval);
                            }

                        }
                        sqlConnection.Close();
                        db.SaveChanges();
                        break;

                    case "FourHour":
                        string constring1 = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = iMarketDB; Integrated Security = True";
                        sqlConnection = new SqlConnection(constring1);
                        sqlConnection.Open();
                        var result1 = from k in db.Symbols
                                      where k.Name == textBoxNameSymbol.Text
                                      select k;
                        foreach (var l in result1)
                        {
                            l.FourHours = new Collection<FourHour>();
                            foreach (DataRow t in table.Rows)
                            {

                                FourHour interval = new FourHour();
                                interval.Open = Convert.ToDecimal(t["Open"]);
                                interval.Close = Convert.ToDecimal(t["Close"]);
                                interval.Max = Convert.ToDecimal(t["High"]);
                                interval.Min = Convert.ToDecimal(t["low"]);
                                interval.Date = Convert.ToDateTime(t["Date"]);

                                l.FourHours.Add(interval);
                                db.fourHours.Add(interval);
                            }

                        }
                        db.SaveChanges();
                        break;
                    case "Hour":
                        string constring2 = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = iMarketDB; Integrated Security = True";
                        sqlConnection = new SqlConnection(constring2);
                        sqlConnection.Open();
                        var result2 = from k in db.Symbols
                                      where k.Name == textBoxNameSymbol.Text
                                      select k;
                        foreach (var l in result2)
                        {
                            l.Hours = new Collection<Hour>();
                            foreach (DataRow t in table.Rows)
                            {

                                Hour interval = new Hour();
                                interval.Open = Convert.ToDecimal(t["Open"]);
                                interval.Close = Convert.ToDecimal(t["Close"]);
                                interval.Max = Convert.ToDecimal(t["High"]);
                                interval.Min = Convert.ToDecimal(t["low"]);
                                interval.Date = Convert.ToDateTime(t["Date"]);

                                l.Hours.Add(interval);
                                db.hours.Add(interval);
                            }

                        }
                        db.SaveChanges();
                        break;
                    case "HalfHour":
                        string constring3 = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = iMarketDB; Integrated Security = True";
                        sqlConnection = new SqlConnection(constring3);
                        sqlConnection.Open();
                        var result3 = from k in db.Symbols
                                      where k.Name == textBoxNameSymbol.Text
                                      select k;
                        foreach (var l in result3)
                        {
                            l.HalfHours = new Collection<HalfHour>();
                            foreach (DataRow t in table.Rows)
                            {

                                HalfHour interval = new HalfHour();
                                interval.Open = Convert.ToDecimal(t["Open"]);
                                interval.Close = Convert.ToDecimal(t["Close"]);
                                interval.Max = Convert.ToDecimal(t["High"]);
                                interval.Min = Convert.ToDecimal(t["low"]);
                                interval.Date = Convert.ToDateTime(t["Date"]);

                                l.HalfHours.Add(interval);
                                db.halfHours.Add(interval);
                            }

                        }
                        db.SaveChanges();
                        break;

                }
               
            }
            else if (Data.symbolNameList.Count != 0)
            {
                Symbol symbol1 = new Symbol();
                symbol1.Name = textBoxNameSymbol.Text;

                switch (Name)
                {
                    case "Day":

                        symbol1.DayStocks = new Collection<DayStock>();
                        foreach (DataRow t in table.Rows)
                        {
                            DayStock interval = new DayStock();
                            interval.Open = Convert.ToDecimal(t["Open"]);
                            interval.Close = Convert.ToDecimal(t["Close"]);
                            interval.Max = Convert.ToDecimal(t["High"]);
                            interval.Min = Convert.ToDecimal(t["low"]);
                            interval.Date = Convert.ToDateTime(t["Date"]);
                            symbol1.DayStocks.Add(interval);

                        }
                        db.Symbols.Add(symbol1);
                        db.SaveChanges();
                        break;
                    case "FourHour":
                        symbol1.FourHours = new Collection<FourHour>();
                        foreach (DataRow t in table.Rows)
                        {
                            FourHour interval = new FourHour();
                            interval.Open = Convert.ToDecimal(t["Open"]);
                            interval.Close = Convert.ToDecimal(t["Close"]);
                            interval.Max = Convert.ToDecimal(t["High"]);
                            interval.Min = Convert.ToDecimal(t["low"]);
                            interval.Date = Convert.ToDateTime(t["Date"]);
                            symbol1.FourHours.Add(interval);
                        }
                        db.Symbols.Add(symbol1);
                        db.SaveChanges();
                        break;
                    case "Hour":
                        symbol1.Hours = new Collection<Hour>();
                        foreach (DataRow t in table.Rows)
                        {
                            Hour interval = new Hour();
                            interval.Open = Convert.ToDecimal(t["Open"]);
                            interval.Close = Convert.ToDecimal(t["Close"]);
                            interval.Max = Convert.ToDecimal(t["High"]);
                            interval.Min = Convert.ToDecimal(t["low"]);
                            interval.Date = Convert.ToDateTime(t["Date"]);
                            symbol1.Hours.Add(interval);
                        }
                        db.Symbols.Add(symbol1);
                        db.SaveChanges();
                        break;
                    case "HalfHour":
                        symbol1.HalfHours = new Collection<HalfHour>();
                        foreach (DataRow t in table.Rows)
                        {
                            HalfHour interval = new HalfHour();
                            interval.Open = Convert.ToDecimal(t["Open"]);
                            interval.Close = Convert.ToDecimal(t["Close"]);
                            interval.Max = Convert.ToDecimal(t["High"]);
                            interval.Min = Convert.ToDecimal(t["low"]);
                            interval.Date = Convert.ToDateTime(t["Date"]);
                            symbol1.HalfHours.Add(interval);
                        }
                        break;

                }
            }
        }
        private void createSymbol()
        {
            
            List<string> symbolNameList1 = db.Symbols.Where(c => c.Name == c.Name).Select(c => c.Name).ToList();
            foreach (var n in symbolNameList1)
            {
                Data.symbolNameList.Add(n);
                listBox1.Items.Add(n);
            }

            var interval = Data.checkinterval;
            var PathToFile = @textBoxpathtofile.Text;
            var FileName = textBoxfilename.Text;
            switch (interval)
            {
                case "Day":
                    CreateTable(PathToFile, FileName, interval);
                    //DataTable table = LoadExelSheetToTable(PathToFile, FileName);
                    //PlaceTableToDataTable(table, interval);
                    break;
                case "FourHour":
                    CreateTable(PathToFile, FileName, interval);
                    //DataTable table1 = LoadExelSheetToTable(PathToFile, FileName);
                    //PlaceTableToDataTable(table1, interval);
                    break;
                case "Hour":
                    CreateTable(PathToFile, FileName, interval);
                    //DataTable table2 = LoadExelSheetToTable(PathToFile, FileName);
                    //PlaceTableToDataTable(table2, interval);
                    break;
                case "HalfHour":
                    CreateTable(PathToFile, FileName, interval);
                    //DataTable table3 = LoadExelSheetToTable(PathToFile, FileName);
                    //PlaceTableToDataTable(table3, interval);
                    break;
            }
            Close();
        }
        /// <summary>
        /// Асинхронный метод создания/добавления символа. Метод включает в себя, две задачи, вторая начинает работу, после окончания первой.
        /// </summary>
        /// <param name="PathTofilename"></param>
        /// <param name="sheetName"></param>
        /// <param name="interval"></param>
        /// <returns></returns>
        private void CreateTable(string PathTofilename, string sheetName, string interval)
        {
            var table = loadCandle.LoadExelSheetToTable(PathTofilename, sheetName);
            Task.Run(() => PlaceTableToDataTable(table, interval));
            //PlaceTableToDataTable(table, interval);
            MessageBox.Show("Интервал успешно добавлен");
        }
        

        void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCountry = listBox1.SelectedItem.ToString();
            textBoxNameSymbol.Text=selectedCountry;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
                       
            
        }

        private void listBox1_MouseLeave(object sender, EventArgs e)
        {
            listBox1.Visible = false;
        }
        /// <summary>
        /// Метод выбора пути и имени файла
        /// </summary>
        public void ChooseFolder()
        {
            openFileDialog1.Title = "Выберите файл с расширением xlsx";
            openFileDialog1.Filter = "xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxpathtofile.Text = openFileDialog1.FileName;
            }
        }

        private void btnDialog_Click(object sender, EventArgs e)
        {
            ChooseFolder();
        }
    }
}


    
 
