using CrmiMarket.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUi
{
    
    public class ViewProgressBar : Form
    {
        
        public bool flag;
        public ProgressBar progressBar { get; set; }
        LoadCandle loadCandle = new LoadCandle();
        
        public ViewProgressBar()
        {

        }
        public ViewProgressBar(int x, int y, int TabIndex, string Name)
        {
            progressBar = new ProgressBar();
            progressBar.Location = new System.Drawing.Point(x, y);
            progressBar.Name = Name;
            progressBar.Size = new System.Drawing.Size(115, 10);
            progressBar.TabIndex = TabIndex;



        }
        public List<ViewProgressBar> ListOfProgressBars()
        {
            List<ViewProgressBar> ListOfBars = new List<ViewProgressBar>();

            ViewProgressBar bar1 = new ViewProgressBar(870, 386, 48, "Months");
            ListOfBars.Add(bar1);
            ViewProgressBar bar2 = new ViewProgressBar(749, 386, 47, "Weeks");
            ListOfBars.Add(bar2);
            ViewProgressBar bar3 = new ViewProgressBar(628, 386, 46, "DayStocks");
            ListOfBars.Add(bar3);
            ViewProgressBar bar4 = new ViewProgressBar(507, 386, 45, "FourHours");
            ListOfBars.Add(bar4);
            ViewProgressBar bar5 = new ViewProgressBar(386, 386, 44, "Hours");
            ListOfBars.Add(bar5);
            ViewProgressBar bar6 = new ViewProgressBar(265, 386, 43, "HalfHours");
            ListOfBars.Add(bar6);
            ViewProgressBar bar7 = new ViewProgressBar(144, 386, 42, "15min");
            ListOfBars.Add(bar7);
            ViewProgressBar bar8 = new ViewProgressBar(23, 386, 20, "5min");
            ListOfBars.Add(bar8);
            return ListOfBars;
        }
        public void ProgressBar(int value, string flag, List<PropertySymbol> collectionSymbols)
        {
            
            while (flag == "Months")
            {

                progressBar.Invoke((Action)delegate
                {
                    progressBar.Visible = true;
                    progressBar.Minimum = 0;
                    progressBar.Maximum = value;
                    progressBar.Value = DateTime.Now.Day;
                    progressBar.Step = 1;
                    if (progressBar.Value % 30 == value)
                    {
                        progressBar.Value = 0;
                        
                    };
                });
                Thread.Sleep(1000);
                
            }
            while (flag == "Weeks")
            {

                progressBar.Invoke((Action)delegate
                {
                    progressBar.Visible = true;
                    progressBar.Minimum = 0;
                    progressBar.Maximum = value;
                    progressBar.Value = DateTime.Now.Day;
                    progressBar.Step = 1;
                    if (progressBar.Value % 7 == value)
                    {
                        progressBar.Value = 0;
                    };
                });
                Thread.Sleep(1000);

            }
            while (flag == "DayStocks")
            {


                progressBar.Invoke((Action)delegate
                {
                    progressBar.Visible = true;
                    progressBar.Minimum = 0;
                    progressBar.Maximum = value;
                    progressBar.Value = DateTime.Now.Hour;
                    progressBar.Step = 1;
                    if (progressBar.Value == value)
                    {
                        
                        progressBar.Value = 0;
                        loadCandle.LoadNewCandle(collectionSymbols, flag);
                    };
                });
                Thread.Sleep(1000);

            }
            while (flag == "FourHours")
            {

                progressBar.Invoke((Action)delegate
                {
                    progressBar.Visible = true;
                    progressBar.Minimum = 0;
                    progressBar.Maximum = value;
                    progressBar.Value = DateTime.Now.Hour;
                    progressBar.Step = 1;
                    if (progressBar.Value % 4 == value) // деление без остатка
                    {
                        progressBar.Value = 0;
                        loadCandle.LoadNewCandle(collectionSymbols, flag);
                    };
                });
                Thread.Sleep(1000);
            }
            while (flag == "Hours")
            {

                progressBar.Invoke((Action)delegate
                {
                    progressBar.Visible = true;
                    progressBar.Minimum = 0;
                    progressBar.Maximum = value;
                    progressBar.Value = DateTime.Now.Minute;
                    progressBar.Step = 1;
                    if (progressBar.Value == value) // деление без остатка
                    {
                        progressBar.Value = 0;
                    };
                });
                Thread.Sleep(1000);
            }
            while (flag == "HalfHours")
            {

                progressBar.Invoke((Action)delegate
                {
                    progressBar.Visible = true;
                    progressBar.Minimum = 0;
                    progressBar.Maximum = value;
                    progressBar.Value = DateTime.Now.Minute;
                    progressBar.Step = 1;
                    if (progressBar.Value % 30 == value) // деление без остатка
                    {
                        progressBar.Value = 0;
                        loadCandle.LoadNewCandle(collectionSymbols, flag);
                    };
                });
                Thread.Sleep(1000);
            }
            while (flag == "15min")
            {

                progressBar.Invoke((Action)delegate
                {
                    progressBar.Visible = true;
                    progressBar.Minimum = 0;
                    progressBar.Maximum = value;
                    progressBar.Value = DateTime.Now.Minute;
                    progressBar.Step = 1;
                    if (progressBar.Value % 15 == value) // деление без остатка
                    {
                        progressBar.Value = 0;
                    };
                });
                Thread.Sleep(1000);
            }
            while (flag == "5min")
            {

                progressBar.Invoke((Action)delegate
                {
                    progressBar.Visible = true;
                    progressBar.Minimum = 0;
                    progressBar.Maximum = value;
                    progressBar.Value = DateTime.Now.Minute;
                    progressBar.Step = 10;
                    if (progressBar.Value % 5 == 0) // деление без остатка
                    {
                        progressBar.Value = 0;
                        loadCandle.LoadNewCandle(collectionSymbols, "DayStocks");
                    };
                });
                Thread.Sleep(1000);
            }

        }

        
    }
}
