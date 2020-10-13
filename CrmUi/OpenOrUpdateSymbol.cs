using CrmiMarket.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Media.Animation;

namespace CrmUi
{
    public partial class OpenOrUpdateSymbol : Form
    {
        
        private string NameTable = null;
        private SqlConnection sqlConnection = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataSet dataSet = null;
        private DataTable table = null;
        CrmContext db = new CrmContext();
        public OpenOrUpdateSymbol()
        {
            InitializeComponent();
            FillCombobox();
            
            comboBoxCelect_Symbols.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;

        }
        void FillCombobox()
        {
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
                        comboBoxCelect_Symbols.Items.Add(sName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }


        private void btnLoad_Click(object sender, EventArgs e)
        {

            createAdapter(NameTable);
            createTab(comboBoxCelect_Symbols.SelectedItem.ToString(), comboBox2.SelectedItem.ToString());
            
            //CheckInterval = Data.checkinterval;



        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                Data.checkinterval = "DayStock";
                NameTable = "DayStocks";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                Data.checkinterval = "FourHour";
                NameTable = "FourHours";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                Data.checkinterval = "Hour";
                NameTable = "Hours";
            }
            if (comboBox2.SelectedIndex == 3)
            {
                Data.checkinterval = "HalfHour";
                NameTable = "HalfHours";
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data.NameSymbol = comboBoxCelect_Symbols.SelectedItem.ToString();
            

        }
        private void createTab(string nameSymbol, string interval)
        {

            bool a = false;
            bool b = false;

            void method()
            {

                DataGridView dataGridView = new DataGridView();
                TabPage tabPageInterval = new TabPage();
                TabControl tabControl1 = new TabControl();
                TabPage tab = new TabPage();
                tab.Text = nameSymbol;
                dataGridView.Dock = DockStyle.Fill;
                tabPageInterval.Controls.Add(dataGridView);
                tabPageInterval.Text = interval;
                tabControl1.Dock = DockStyle.Fill;
                tabControl1.Controls.Add(tabPageInterval);
                tab.Controls.Add(tabControl1);
                tabControl.TabPages.Add(tab);
                dataGridView.DataSource = table;
            }

            if (tabControl.TabPages.Count == 0)
            {
                method();

            }
            else
            {
                foreach (TabPage v in tabControl.TabPages)
                {

                    if (v.Text.Contains(nameSymbol))
                    {
                        b = true;
                        foreach (TabControl p in v.Controls)
                        {

                            foreach (TabPage s in p.TabPages)
                            {

                                if (s.Text.Contains(interval))
                                {
                                    MessageBox.Show("Указанный интервал уже добавлен");
                                    a = true;

                                }

                            }
                            if (a == false)
                            {
                                DataGridView dataGridView1 = new DataGridView();
                                dataGridView1.Dock = DockStyle.Fill;
                                TabPage tabPage = new TabPage();
                                tabPage.Controls.Add(dataGridView1);
                                tabPage.Text = interval;
                                p.TabPages.Add(tabPage);
                                dataGridView1.DataSource = table;

                            }

                        }
                    }

                }
                if (b == false)
                {
                    method();
                }


            }

        }

        private void createAdapter(string NameTable)
        {
            int idSymbol = 0;
            string constring = @"Data Source =(localdb)\MSSQLLocalDB;Initial Catalog = iMarketDB;  Integrated Security = True";
            
            sqlConnection = new SqlConnection(constring);
            sqlConnection.Open();
            var result = from k in db.Symbols
                         where k.Name == comboBoxCelect_Symbols.SelectedItem.ToString()
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
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            
            
            foreach(TabPage k in tabControl.TabPages)
            {
                foreach(TabControl p in k.Controls)
                {
                    int symbolId = 0;
                    string constring = @"Data Source =(localdb)\MSSQLLocalDB;Initial Catalog = iMarketDB;  Integrated Security = True";
                    sqlConnection = new SqlConnection(constring);
                    sqlConnection.Open();
                    var result1 = from i in db.Symbols
                                  where i.Name == tabControl.SelectedTab.Text
                                  select i.SymbolId;
                    foreach(var z in result1)
                    {
                        symbolId = z;
                    }
                    var result = from n in db.Symbols
                                 where n.Name == tabControl.SelectedTab.Text
                                 select n;

                    foreach (var t in result)
                    {
                        db.Symbols.Remove(t);

                    }
                    string Query = $"DELETE FROM dbo.{p.SelectedTab.Text} where symbol_SymbolId = {symbolId}";
                    SqlCommand cmd = new SqlCommand(Query, sqlConnection);
                    cmd.CommandType = CommandType.Text;
                    sqlDataAdapter = new SqlDataAdapter(Query, sqlConnection);
                    sqlDataAdapter.SelectCommand = cmd;
                    dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet, p.SelectedTab.Text);
                    table = dataSet.Tables[p.SelectedTab.Text];
                    sqlConnection.Close();
                    
                    db.SaveChanges();
                    
                    
                    
                }
            }
            Close();
        }



}   }   

