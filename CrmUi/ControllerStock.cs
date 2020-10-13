
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using CrmiMarket.Classes;
using CrmiMarket.model;
using TabControl = System.Windows.Forms.TabControl;

namespace CrmUi
{
    
    public partial class ControllerStock : Form
    {
        
        private SqlConnection sqlConnection = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataSet dataSet = null;
        private DataTable table = null;
        private DataTable newTable = null;
        int minAxis = 0;
        int maxAxis = 0;
        CrmContext db = new CrmContext();
        string CurrentSymbol;
        bool dayStockFlag = false;
        bool fourHourFlag = false;
        bool hourFlag = false;
        bool halfHourFlag = false;

        bool flag = true;
        Stack<DataRow> rows = new Stack<DataRow>();
        Stack<DataRow> rows1 = new Stack<DataRow>();
        DataTable LittleTable = new DataTable();
        private int yAsix = 30;
        List<PropertySymbol> collectionSymbols = new List<PropertySymbol>();
        LoadCandle loadCandle = new LoadCandle();


        public ControllerStock()
        {
            InitializeComponent();
            
            FillCombobox();
            //SymbolName.Text = Data.NameSymbol;
            CurrentSymbol = Data.NameSymbol;
            plus.Click += plus_Click;
            btnMinus.Click += btnMinus_Click;
            createButton();
            
            
                        
        }
        
        private void ControllerStock_Load(object sender, EventArgs e)
        {
            ViewProgressBar viewProgressBar = new ViewProgressBar();
            var listofbars = viewProgressBar.ListOfProgressBars();
            foreach (var i in listofbars)
            {
                Controls.Add(i.progressBar);
                if (i.progressBar.Name == "Hours")
                {
                    Task.Run(() => i.ProgressBar(60, "Hours", collectionSymbols));
                }
                else if (i.progressBar.Name == "FourHours")
                {
                    Task.Run(() => i.ProgressBar(24, "FourHours", collectionSymbols));
                }
                else if (i.progressBar.Name == "HalfHours")
                {
                    Task.Run(() => i.ProgressBar(60, "HalfHours", collectionSymbols));
                }
                else if (i.progressBar.Name == "DayStocks")
                {
                    Task.Run(() => i.ProgressBar(24, "DayStocks", collectionSymbols));
                }
                else if (i.progressBar.Name == "Months")
                {
                    Task.Run(() => i.ProgressBar(30, "Months", collectionSymbols));
                }
                else if (i.progressBar.Name == "15min")
                {
                    Task.Run(() => i.ProgressBar(60, "15min", collectionSymbols));
                }
                else if (i.progressBar.Name == "5min")
                {
                    Task.Run(() => i.ProgressBar(60, "5min", collectionSymbols));
                }
                else if (i.progressBar.Name == "Weeks")
                {
                    Task.Run(() => i.ProgressBar(60, "Weeks", collectionSymbols));
                }


            }
            
            
        }
        /// <summary>
        /// Создание подключения к базе данных(ориентация по имени интервала(DayStocks,FourHours,Hours or HalfHours)) по соответсвующему ключу(idSymbol) и перенос данных в таблицу DataTable
        /// </summary>
        /// <param name="NameSymbol">Имя символа</param>
        /// <param name="NameTable">Имя интервала в базе данных(DayStocks,FourHours,Hours or HalfHours)</param>
        private void createAdapter(string NameTable, string NameSymbol)
        {
            #region
            int idSymbol = 0;
            string constring = @"Data Source =(localdb)\MSSQLLocalDB;Initial Catalog = iMarketDB;  Integrated Security = True";

            sqlConnection = new SqlConnection(constring);
            sqlConnection.Open();
            var result = from k in db.Symbols
                         where k.Name ==NameSymbol //toolStripComboBoxSymbol.SelectedItem.ToString()
                         select k.SymbolId;
            foreach (var t in result)
            {
                idSymbol = t;
            }
            string Query = $"SELECT * FROM dbo.{NameTable} WHERE symbol_SymbolId = {idSymbol};";
            SqlCommand cmd = new SqlCommand(Query, sqlConnection);
            cmd.CommandType = CommandType.Text;
            sqlDataAdapter = new SqlDataAdapter(Query, sqlConnection);
            sqlDataAdapter.SelectCommand = cmd;
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, NameTable);
            table = dataSet.Tables[NameTable];
            sqlConnection.Close();
            LittleTable = table.Clone();
            foreach (DataRow k in table.Rows)
            {
                rows.Push(k);
            }
            #endregion
        }

        private void checkInterval(string NameSymbol)
        {
            PropertySymbol newSymbol = new PropertySymbol();
            newSymbol.Name = NameSymbol;
            newSymbol.properties = new List<string>();
            int idSymbol = 0;
            string constring = @"Data Source =(localdb)\MSSQLLocalDB;Initial Catalog = iMarketDB;  Integrated Security = True";
            sqlConnection = new SqlConnection(constring);
            sqlConnection.Open();
            var result = from k in db.Symbols
                         where k.Name == NameSymbol //toolStripComboBoxSymbol.SelectedItem.ToString()
                         select k.SymbolId;
            foreach (var t in result)
            {
                
                idSymbol = t;
            }
            string Query = $"SELECT * FROM dbo.DayStocks WHERE symbol_SymbolId = {idSymbol};";
            string Query2 = $"SELECT * FROM dbo.FourHours WHERE symbol_SymbolId = {idSymbol};";
            string Query3 = $"SELECT * FROM dbo.Hours WHERE symbol_SymbolId = {idSymbol};";
            string Query4 = $"SELECT * FROM dbo.HalfHours WHERE symbol_SymbolId = {idSymbol};";
            SqlCommand cmd = new SqlCommand(Query, sqlConnection);
            cmd.CommandType = CommandType.Text;
            sqlDataAdapter = new SqlDataAdapter(Query, sqlConnection);
            sqlDataAdapter.SelectCommand = cmd;
            DataSet dataSetCheck = new DataSet();
            DataTable tableCheck = new DataTable();
            sqlDataAdapter.Fill(dataSetCheck, "DayStocks");
            tableCheck = dataSetCheck.Tables["DayStocks"];
            if(tableCheck.Rows.Count != 0)
            {
                btnDay.BackColor = Color.Red;
                dayStockFlag = true;
                newSymbol.properties.Add("DayStocks");

            }
            dataSetCheck.Clear();
            tableCheck.Clear();
            SqlCommand cmd2 = new SqlCommand(Query2, sqlConnection);
            cmd2.CommandType = CommandType.Text;
            sqlDataAdapter = new SqlDataAdapter(Query2, sqlConnection);
            sqlDataAdapter.SelectCommand = cmd2;
            
            sqlDataAdapter.Fill(dataSetCheck, "FourHours");
            tableCheck = dataSetCheck.Tables["FourHours"];
            if (tableCheck.Rows.Count != 0)
            {
                btnFourHour.BackColor = Color.Red;
                fourHourFlag = true;
                newSymbol.properties.Add("FourHours");
            }
            dataSetCheck.Clear();
            tableCheck.Clear();
            SqlCommand cmd3 = new SqlCommand(Query3, sqlConnection);
            cmd3.CommandType = CommandType.Text;
            sqlDataAdapter = new SqlDataAdapter(Query3, sqlConnection);
            sqlDataAdapter.SelectCommand = cmd3;
           
            sqlDataAdapter.Fill(dataSetCheck, "Hours");
            tableCheck = dataSetCheck.Tables["Hours"];
            if (tableCheck.Rows.Count != 0)
            {
                btnHour.BackColor = Color.Red;
                hourFlag = true;
                newSymbol.properties.Add("Hour");
            }
            dataSetCheck.Clear();
            tableCheck.Clear();
            SqlCommand cmd4 = new SqlCommand(Query4, sqlConnection);
            cmd4.CommandType = CommandType.Text;
            sqlDataAdapter = new SqlDataAdapter(Query4, sqlConnection);
            sqlDataAdapter.SelectCommand = cmd4;
            
            sqlDataAdapter.Fill(dataSetCheck, "HalfHours");
            tableCheck = dataSetCheck.Tables["HalfHours"];
            if (tableCheck.Rows.Count != 0)
            {
                btnHalfHour.BackColor = Color.Red;
                halfHourFlag = true;
                newSymbol.properties.Add("HalfHours");
            }
            sqlConnection.Close();
            collectionSymbols.Add(newSymbol);
        }


        /// <summary>
        /// Привязка базы данных к ComboBox с использование sqlConnection и sqlDatareader
        /// </summary>
        void FillCombobox() 
        {
            #region
            string constring = @"Data Source =(localdb)\MSSQLLocalDB;Initial Catalog = iMarketDB;  Integrated Security = True";
            string Query = "SELECT * FROM dbo.Symbols;";
            using (SqlConnection connection = new SqlConnection(constring))
            {
                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader myReader;
                try
                {
                    connection.Open();
                    myReader = command.ExecuteReader();
                    while (myReader.Read())
                    {
                        string sName = myReader.GetString(1);
                        toolStripComboBoxSymbol.Items.Add(sName);
                    }
                    connection.Close();
                    myReader.Close();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }

            }
            foreach(var k in toolStripComboBoxSymbol.Items)
            {
                var t = Convert.ToString(k);
                checkInterval(t);
            }
            
            #endregion
        }
        /// <summary>
        /// Если в базу данных загружены данные о днях, 4часах, часе или 30 мин. Соответствующие кнопки будут выкрашены в красный цвет.
        /// </summary>
        public void createButton()
        {
            if(Data.checkinterval == "Day")
            {
                btnDay.BackColor = Color.Red;
            }
        }
        /// <summary>
        /// Создает ветви, в TabContol. Каждая ветвь(TabPage) соответсвует Символу(Пример:Nvidia, Сбербанк пр.).
        /// В свою очередь ветви с симовалми деляться на ветви с интервалами(DayStock,FourHour,Hour or HalfHour)
        /// Настроена защита от повтора интервала для одного символа.
        /// </summary>
        /// <param name="nameSymbol">Имя символа выбранного из ComboBox(Пример:Nvidia, Сбербанк пр.)</param>
        /// <param name="interval">Интервал соответсвующий одному из DayStock,FourHour,Hour or HalfHour</param>
       
        private void createTab(string nameSymbol, string interval)
        {
            #region
            bool a = false;
            bool b = false;

            void method()
            {
                LittleTable = graphTable();
                var chartStock = createChart(minAxis, maxAxis, 180);
                chartStock.DataSource = LittleTable;
                TabPage tabPageInterval = new TabPage();
                TabControl tabControl1 = new TabControl();
                TabPage tab = new TabPage();
                tab.Text = nameSymbol;
                tabPageInterval.Controls.Add(chartStock);
                tabPageInterval.Text = interval;
                tabControl1.Dock = DockStyle.Fill;
                tabControl1.Controls.Add(tabPageInterval);
                tab.Controls.Add(tabControl1);
                tabControlSymbol.TabPages.Add(tab);
                chartStock.DataBind();
                
            }

            if (tabControlSymbol.TabPages.Count == 0)
            {
                method();

            }
            else
            {
                foreach (TabPage v in tabControlSymbol.TabPages)
                {

                    if (v.Text.Contains(nameSymbol))
                    {
                        b = true;
                        foreach (TabControl p in v.Controls)
                        {

                            foreach (TabPage s in p.TabPages)
                            {

                                if (s.Text.Equals(interval))
                                {
                                    MessageBox.Show("Указанный интервал уже добавлен");
                                    a = true;

                                }
                                else
                                {
                                    continue;
                                }
                            }
                            if (a == false)
                            {
                                LittleTable = graphTable();
                                var chartStock = createChart(minAxis, maxAxis, 180);
                                chartStock.DataSource = LittleTable;
                                chartStock.DataBind();
                                TabPage tabPage = new TabPage();
                                tabPage.Controls.Add(chartStock);
                                tabPage.Text = interval;
                                p.TabPages.Add(tabPage);
                                
                            }

                        }
                    }

                }
                if (b == false)
                {
                    method();
                }


            }
            #endregion
        }

        private void toolStripComboBoxSymbol_SelectedIndexChanged(object sender, EventArgs e)
        {
            dayStockFlag = false;
            fourHourFlag = false;
            hourFlag = false;
            halfHourFlag = false;
            Data.NameSymbol = toolStripComboBoxSymbol.SelectedItem.ToString();
            checkInterval(Data.NameSymbol);
            if(dayStockFlag == true)
            {
                createAdapter("DayStocks", Data.NameSymbol);
                createTab(Data.NameSymbol, "DayStocks");
                
            }
            else if(fourHourFlag == true)
            {
                createAdapter("FourHours", Data.NameSymbol);
                createTab(Data.NameSymbol, "FourHours");
                
            }
            else if(hourFlag == true)
            {
                createAdapter("Hours", Data.NameSymbol);
                createTab(Data.NameSymbol, "Hours");
                
            }
            else if(halfHourFlag == true)
            {
                createAdapter("HalfHours", Data.NameSymbol);
                createTab(Data.NameSymbol, "HalfHours");
                
            }
            
            
        }
            
                
        /// <summary>
        /// Увеличение масштаба отображаемых свечей.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plus_Click(object sender, EventArgs e)
        {
            #region
            flag = true;
            if (tabControlSymbol.TabPages.Count != 0)
            {
                foreach (TabPage k in tabControlSymbol.TabPages)
                {
                    foreach (TabControl l in k.Controls)
                    {

                        l.SelectedTab.Controls.Clear();
                        newTable = tableLittle();
                        var chart = createChart(minAxis, maxAxis, yAsix);

                        l.SelectedTab.Controls.Add(chart);

                    }
                }
            }
            #endregion
        }
        /// <summary>
        /// Уменьшение масшатаба отображаемых свечей.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinus_Click(object sender, EventArgs e)
        {
            #region
            flag = false;
            if (tabControlSymbol.TabPages.Count != 0)
            {
                foreach (TabPage k in tabControlSymbol.TabPages)
                {
                    foreach (TabControl l in k.Controls)
                    {

                        l.SelectedTab.Controls.Clear();
                        newTable = tableLittle();
                        var chart = createChart(minAxis, maxAxis, yAsix);

                        l.SelectedTab.Controls.Add(chart);

                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// Метод сортировки колличества отображемых свечей(Для работы с кнопкой "+" и "-")
        /// </summary>
        /// <returns></returns>
        private DataTable tableLittle()
        {
            #region
            if (flag == true)
            {
                if (LittleTable.Rows.Count == 0 || LittleTable.Rows.Count == table.Rows.Count ||LittleTable.Rows.Count==1019)
                {
                    metodZoom(656);
                    yAsix = 80;
                }
                else if(LittleTable.Rows.Count == 1312)
                {
                    metodZoom(656);
                    yAsix = 80;
                }
                else if (LittleTable.Rows.Count == 656)
                {
                    metodZoom(328);
                    yAsix = 40;
                }
                else if (LittleTable.Rows.Count == 328)
                {
                    metodZoom(164);
                    yAsix = 20;
                }
                else if (LittleTable.Rows.Count == 164)
                {
                    metodZoom(82);
                    yAsix = 10;
                }
                else if (LittleTable.Rows.Count == 82)
                {
                    metodZoom(41);
                    yAsix = 1;
                }
                else if (LittleTable.Rows.Count == 41)
                {
                    metodZoom(41);
                    yAsix = 1;
                }
                else
                {
                    LittleTable.Rows.Clear();
                }
            }
           
            while (flag == false)
            {
                if (LittleTable.Rows.Count == 41)
                {
                    metodZoom(82);
                    yAsix = 10;
                }
                else if (LittleTable.Rows.Count == 82)
                {
                    metodZoom(164);
                    yAsix = 20;
                }
                else if (LittleTable.Rows.Count == 164)
                {
                    metodZoom(328);
                    yAsix = 40;
                }
                else if (LittleTable.Rows.Count == 328)
                {
                    metodZoom(656);
                    yAsix = 80;
                }
                else if (LittleTable.Rows.Count == 656)
                {
                    metodZoom(1312);
                    yAsix = 160;
                }   
                break;
            }
            
            return LittleTable;
            #endregion
        }
        /// <summary>
        /// Метод создания Графика свечей. +Задание необходимых параметров.
        /// </summary>
        /// <param name="minA">Минимальная велечина оси Y</param>
        /// <param name="maxA">Максимальная велечина оси Y</param>
        /// <param name="interval"></param>
        /// <returns></returns>
        private Chart createChart(int minA, int maxA, int interval)
        {
            #region
            Chart chartStock = new Chart();
            chartStock.Series.Add("Daily");
            chartStock.ChartAreas.Add("ChartArea1");
            chartStock.Series["Daily"].ChartType = SeriesChartType.Candlestick;
            chartStock.Series["Daily"].XValueMember = "Date";
            chartStock.Series["Daily"].YValueMembers = "Max,Min,Open,Close";
            chartStock.DataBind();
            chartStock.Series["Daily"].BorderColor = System.Drawing.Color.Red;
            chartStock.Series["Daily"].Color = System.Drawing.Color.Red;
            chartStock.Series["Daily"].CustomProperties = "PriceUpColor=Green, PriceDownColor= Black";
            chartStock.Series["Daily"].XValueType = ChartValueType.DateTime;
            chartStock.Series["Daily"].YValueType = ChartValueType.Auto;
            chartStock.Series["Daily"]["ShowOpenClose"] = "Both";
            chartStock.Series["Daily"].IsXValueIndexed = true;
            chartStock.Series["Daily"].CustomProperties = "PriceUpColor=Green, PriceDownColor= Black";
            chartStock.DataManipulator.IsStartFromFirst = false;
            chartStock.ChartAreas["ChartArea1"].AxisX.IntervalType = DateTimeIntervalType.NotSet;
            chartStock.ChartAreas["ChartArea1"].AxisX.Interval = interval;
            chartStock.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 1;
            chartStock.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 1;
            chartStock.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.Gray;
            chartStock.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartStock.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = Color.Gray;
            chartStock.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartStock.ChartAreas["ChartArea1"].AxisY.Maximum = maxA;
            chartStock.ChartAreas["ChartArea1"].AxisY.Minimum = minA;
            //chartStock.DataManipulator.IsStartFromFirst = true;
            //chartStock.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, "15", "Daily", "MA");
            chartStock.Dock = DockStyle.Fill;
            chartStock.DataSource = newTable;
            return chartStock;
            #endregion
        }
        
        /// <summary>
        /// Метод первичной отрисовки графика свечей, посредсвом выборки через List, всех значений внутри DataTalble(Выгруженных из Базы даных))+ Нахождений максимальной и минимальной велечины оси Y.
        /// </summary>
        /// <returns></returns>
        private DataTable graphTable()
        {
            #region
            List<decimal> Min = new List<decimal>();
            List<decimal> Max = new List<decimal>();
            int count = rows.Count;
            var result = rows.Take(count);
            foreach(var h in result)
            {
                LittleTable.Rows.Add(h.ItemArray);
            }
            for (int i = 0; i < LittleTable.Rows.Count; i++)
            {
                var res = Convert.ToDecimal(LittleTable.Rows[i]["Max"].ToString());
                var res2 = Convert.ToDecimal(LittleTable.Rows[i]["Min"].ToString());
                Max.Add(res);
                Min.Add(res2);
            }
            maxAxis = Convert.ToInt32(Math.Truncate(Max.Max())) + 1;
            minAxis = Convert.ToInt32(Math.Truncate(Min.Min())) - 1;
            return LittleTable;
            #endregion
        }
        /// <summary>
        /// Метод вторичной отрисовки графика свечей, посредсвом выборки через List, всех значений внутри DataTalble(Выгруженных из Базы даных))+ Нахождений максимальной и минимальной велечины оси Y.
        /// </summary>
        /// <param name="number">Колличесвто отображаемых свечей на графике</param>
        /// <returns></returns>
        private DataTable metodZoom(int number)
        {
            #region
            List<decimal> Min = new List<decimal>();
            List<decimal> Max = new List<decimal>();
            var result = rows.Take(number);
            LittleTable.Clear();
            foreach (var i in result)
            {
                LittleTable.Rows.Add(i.ItemArray);
            }
            for (int i = 0; i < LittleTable.Rows.Count; i++)
            {
                var res = Convert.ToDecimal(LittleTable.Rows[i]["Max"].ToString());
                var res2 = Convert.ToDecimal(LittleTable.Rows[i]["Min"].ToString());
                Max.Add(res);
                Min.Add(res2);
            }
            maxAxis = Convert.ToInt32(Math.Truncate(Max.Max())) + 1;
            minAxis = Convert.ToInt32(Math.Truncate(Min.Min())) - 1;
            return LittleTable;
            #endregion
        }

        private void tabControlSymbol_Selecting(object sender, TabControlCancelEventArgs e)
        {
            btnDay.BackColor = Color.Empty;
            btnFourHour.BackColor = Color.Empty;
            btnHour.BackColor = Color.Empty;
            btnHalfHour.BackColor = Color.Empty;
            var result = from k in collectionSymbols
                         where k.Name == tabControlSymbol.SelectedTab.Text
                         select k;
            foreach(var i in result)
            {
                
                if (i.properties.Contains("DayStocks"))
                {
                    btnDay.BackColor = Color.Red;
                }
                if (i.properties.Contains("FourHours"))
                {
                    btnFourHour.BackColor = Color.Red;
                }
                if (i.properties.Contains("Hours"))
                {
                    btnHour.BackColor = Color.Red;
                }
                if (i.properties.Contains("HalfHours"))
                {
                    btnHalfHour.BackColor = Color.Red;
                }

            }    
        }
        
        private void btnDay_Click_1(object sender, EventArgs e)
        {
            if (btnDay.BackColor == Color.Red)
            {

                dataSet.Clear();
                rows.Clear();
                rows1.Clear();
                table.Clear();
                LittleTable.Clear();
                createAdapter("DayStocks", tabControlSymbol.SelectedTab.Text);
                createTab(tabControlSymbol.SelectedTab.Text, "DayStocks");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Интервал не добавлен");
            }
        }

        private void btnFourHour_Click_1(object sender, EventArgs e)
        {
            if (btnFourHour.BackColor == Color.Red)
            {
                dataSet.Clear();
                rows.Clear();
                rows1.Clear();
                table.Clear();
                LittleTable.Clear();
                createAdapter("FourHours", tabControlSymbol.SelectedTab.Text);
                createTab(tabControlSymbol.SelectedTab.Text, "FourHours");
            }
            else
            {
                MessageBox.Show("Интервал не добавлен");
            }
        }

        private void btnHour_Click_1(object sender, EventArgs e)
        {
            if (btnHour.BackColor == Color.Red)
            {

                dataSet.Clear();
                rows.Clear();
                rows1.Clear();
                table.Clear();
                LittleTable.Clear();
                createAdapter("Hours", (tabControlSymbol.SelectedTab.Text));
                createTab(tabControlSymbol.SelectedTab.Text, "Hours");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Интервал не добавлен");
            }
        }

        private void btnHalfHour_Click_1(object sender, EventArgs e)
        {
            if (btnHalfHour.BackColor == Color.Red)
            {

                dataSet.Clear();
                rows.Clear();
                rows1.Clear();
                table.Clear();
                LittleTable.Clear();
                createAdapter("HalfHours", tabControlSymbol.SelectedTab.Text);
                createTab(tabControlSymbol.SelectedTab.Text, "HalfHours");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Интервал не добавлен");
            }
        }

        

    }
}  

