using CrmiMarket.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.OleDb;

namespace CrmUi
{
    public partial class Main : Form
    {
        public string text1;
        public ProgressBar progressBar1 { get; set; }
        public Main()
        {
            progressBar1 = new ProgressBar();
            Controls.Add(progressBar1);
            InitializeComponent();
            //Information();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            progressBar1.Location = new Point(289, 103);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(100, 23);
            progressBar1.TabIndex = 1;


        }
        

        //private void dayToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    var CatalogDay = new DayStocks<Day>(db.days);

        //    CatalogDay.Show();
        //}


        private void newSymbolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var createNewSymbol = new CreateNewSymbol();
            createNewSymbol.Show();
        }

        private void openOrUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openOrUpdateSymbol = new OpenOrUpdateSymbol();
            openOrUpdateSymbol.Show();
        }
        public static void Information()
        {
            DataTable table = new OleDbEnumerator().GetElements();
            string inf = "";
            foreach (DataRow row in table.Rows)
                inf += row["SOURCES_NAME"] + "\n";

            MessageBox.Show(inf);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var StockLoad = new ControllerStock();
            StockLoad.Show();
        }
    }



}

