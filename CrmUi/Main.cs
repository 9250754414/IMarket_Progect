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
        
        public Main()
        {
            
            InitializeComponent();
            //Information();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            

        }
        
               


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

