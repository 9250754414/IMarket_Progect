namespace CrmUi
{
    partial class ControllerStock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlSymbol = new System.Windows.Forms.TabControl();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabNews = new System.Windows.Forms.TabPage();
            this.tabTrade = new System.Windows.Forms.TabPage();
            this.tabAlert = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBoxSymbol = new System.Windows.Forms.ToolStripComboBox();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plus = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnFiveMin = new System.Windows.Forms.Button();
            this.btnFiveteenMin = new System.Windows.Forms.Button();
            this.btnHalfHour = new System.Windows.Forms.Button();
            this.btnHour = new System.Windows.Forms.Button();
            this.btnFourHour = new System.Windows.Forms.Button();
            this.btnDay = new System.Windows.Forms.Button();
            this.btnWeek = new System.Windows.Forms.Button();
            this.btnMonth = new System.Windows.Forms.Button();
            this.tabControl2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlSymbol
            // 
            this.tabControlSymbol.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSymbol.Location = new System.Drawing.Point(4, 73);
            this.tabControlSymbol.Name = "tabControlSymbol";
            this.tabControlSymbol.SelectedIndex = 0;
            this.tabControlSymbol.Size = new System.Drawing.Size(989, 278);
            this.tabControlSymbol.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControlSymbol.TabIndex = 0;
            this.tabControlSymbol.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControlSymbol_Selecting);
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabNews);
            this.tabControl2.Controls.Add(this.tabTrade);
            this.tabControl2.Controls.Add(this.tabAlert);
            this.tabControl2.Location = new System.Drawing.Point(13, 423);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(967, 148);
            this.tabControl2.TabIndex = 12;
            // 
            // tabNews
            // 
            this.tabNews.Location = new System.Drawing.Point(4, 22);
            this.tabNews.Name = "tabNews";
            this.tabNews.Size = new System.Drawing.Size(959, 122);
            this.tabNews.TabIndex = 0;
            this.tabNews.Text = "News";
            this.tabNews.UseVisualStyleBackColor = true;
            // 
            // tabTrade
            // 
            this.tabTrade.Location = new System.Drawing.Point(4, 22);
            this.tabTrade.Name = "tabTrade";
            this.tabTrade.Size = new System.Drawing.Size(959, 122);
            this.tabTrade.TabIndex = 1;
            this.tabTrade.Text = "Trade";
            this.tabTrade.UseVisualStyleBackColor = true;
            // 
            // tabAlert
            // 
            this.tabAlert.Location = new System.Drawing.Point(4, 22);
            this.tabAlert.Name = "tabAlert";
            this.tabAlert.Size = new System.Drawing.Size(959, 122);
            this.tabAlert.TabIndex = 2;
            this.tabAlert.Text = "Alert";
            this.tabAlert.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(997, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.newToolStripMenuItem.Text = "Create";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBoxSymbol});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.openToolStripMenuItem.Text = "Load";
            // 
            // toolStripComboBoxSymbol
            // 
            this.toolStripComboBoxSymbol.Name = "toolStripComboBoxSymbol";
            this.toolStripComboBoxSymbol.Size = new System.Drawing.Size(121, 23);
            this.toolStripComboBoxSymbol.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxSymbol_SelectedIndexChanged);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // plus
            // 
            this.plus.Location = new System.Drawing.Point(63, 12);
            this.plus.Name = "plus";
            this.plus.Size = new System.Drawing.Size(29, 24);
            this.plus.TabIndex = 17;
            this.plus.Text = "+";
            this.plus.UseVisualStyleBackColor = true;
            this.plus.Click += new System.EventHandler(this.plus_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.Location = new System.Drawing.Point(98, 12);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(29, 24);
            this.btnMinus.TabIndex = 18;
            this.btnMinus.Text = "-";
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnFiveMin
            // 
            this.btnFiveMin.Location = new System.Drawing.Point(23, 357);
            this.btnFiveMin.Name = "btnFiveMin";
            this.btnFiveMin.Size = new System.Drawing.Size(115, 23);
            this.btnFiveMin.TabIndex = 33;
            this.btnFiveMin.Text = "5 min";
            this.btnFiveMin.UseVisualStyleBackColor = true;
            // 
            // btnFiveteenMin
            // 
            this.btnFiveteenMin.Location = new System.Drawing.Point(144, 357);
            this.btnFiveteenMin.Name = "btnFiveteenMin";
            this.btnFiveteenMin.Size = new System.Drawing.Size(115, 23);
            this.btnFiveteenMin.TabIndex = 34;
            this.btnFiveteenMin.Text = "15 min";
            this.btnFiveteenMin.UseVisualStyleBackColor = true;
            // 
            // btnHalfHour
            // 
            this.btnHalfHour.Location = new System.Drawing.Point(265, 357);
            this.btnHalfHour.Name = "btnHalfHour";
            this.btnHalfHour.Size = new System.Drawing.Size(115, 23);
            this.btnHalfHour.TabIndex = 35;
            this.btnHalfHour.Text = "30 min";
            this.btnHalfHour.UseVisualStyleBackColor = true;
            this.btnHalfHour.Click += new System.EventHandler(this.btnHalfHour_Click_1);
            // 
            // btnHour
            // 
            this.btnHour.Location = new System.Drawing.Point(386, 357);
            this.btnHour.Name = "btnHour";
            this.btnHour.Size = new System.Drawing.Size(115, 23);
            this.btnHour.TabIndex = 36;
            this.btnHour.Text = "1 Hour";
            this.btnHour.UseVisualStyleBackColor = true;
            this.btnHour.Click += new System.EventHandler(this.btnHour_Click_1);
            // 
            // btnFourHour
            // 
            this.btnFourHour.Location = new System.Drawing.Point(507, 357);
            this.btnFourHour.Name = "btnFourHour";
            this.btnFourHour.Size = new System.Drawing.Size(115, 23);
            this.btnFourHour.TabIndex = 37;
            this.btnFourHour.Text = "4 Hours";
            this.btnFourHour.UseVisualStyleBackColor = true;
            this.btnFourHour.Click += new System.EventHandler(this.btnFourHour_Click_1);
            // 
            // btnDay
            // 
            this.btnDay.Location = new System.Drawing.Point(628, 357);
            this.btnDay.Name = "btnDay";
            this.btnDay.Size = new System.Drawing.Size(115, 23);
            this.btnDay.TabIndex = 38;
            this.btnDay.Text = "Day";
            this.btnDay.UseVisualStyleBackColor = true;
            this.btnDay.Click += new System.EventHandler(this.btnDay_Click_1);
            // 
            // btnWeek
            // 
            this.btnWeek.Location = new System.Drawing.Point(749, 357);
            this.btnWeek.Name = "btnWeek";
            this.btnWeek.Size = new System.Drawing.Size(115, 23);
            this.btnWeek.TabIndex = 39;
            this.btnWeek.Text = "Week";
            this.btnWeek.UseVisualStyleBackColor = true;
            // 
            // btnMonth
            // 
            this.btnMonth.Location = new System.Drawing.Point(870, 357);
            this.btnMonth.Name = "btnMonth";
            this.btnMonth.Size = new System.Drawing.Size(115, 23);
            this.btnMonth.TabIndex = 40;
            this.btnMonth.Text = "Month";
            this.btnMonth.UseVisualStyleBackColor = true;
            // 
            // ControllerStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 612);
            this.Controls.Add(this.btnMonth);
            this.Controls.Add(this.btnWeek);
            this.Controls.Add(this.btnDay);
            this.Controls.Add(this.btnFourHour);
            this.Controls.Add(this.btnHour);
            this.Controls.Add(this.btnHalfHour);
            this.Controls.Add(this.btnFiveteenMin);
            this.Controls.Add(this.btnFiveMin);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.plus);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.tabControlSymbol);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ControllerStock";
            this.Text = "ControllerStock";
            this.Load += new System.EventHandler(this.ControllerStock_Load);
            this.tabControl2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlSymbol;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabNews;
        private System.Windows.Forms.TabPage tabTrade;
        private System.Windows.Forms.TabPage tabAlert;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxSymbol;
        private System.Windows.Forms.Button plus;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnFiveMin;
        private System.Windows.Forms.Button btnFiveteenMin;
        private System.Windows.Forms.Button btnHalfHour;
        private System.Windows.Forms.Button btnHour;
        private System.Windows.Forms.Button btnFourHour;
        private System.Windows.Forms.Button btnDay;
        private System.Windows.Forms.Button btnWeek;
        private System.Windows.Forms.Button btnMonth;
    }
}