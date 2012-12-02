namespace Recognition.Application
{
    partial class NetworkForm
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
            this.txtStatistics = new System.Windows.Forms.TextBox();
            this.imgLayersOutputs = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNetworkCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNetworkOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNetworkSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.изображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClearHistory = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgLayersOutputs)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStatistics
            // 
            this.txtStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStatistics.Location = new System.Drawing.Point(3, 3);
            this.txtStatistics.Multiline = true;
            this.txtStatistics.Name = "txtStatistics";
            this.txtStatistics.ReadOnly = true;
            this.txtStatistics.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatistics.Size = new System.Drawing.Size(275, 429);
            this.txtStatistics.TabIndex = 9;
            // 
            // imgLayersOutputs
            // 
            this.imgLayersOutputs.BackColor = System.Drawing.Color.White;
            this.imgLayersOutputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgLayersOutputs.Location = new System.Drawing.Point(284, 3);
            this.imgLayersOutputs.Name = "imgLayersOutputs";
            this.tableLayoutPanel1.SetRowSpan(this.imgLayersOutputs, 2);
            this.imgLayersOutputs.Size = new System.Drawing.Size(652, 458);
            this.imgLayersOutputs.TabIndex = 6;
            this.imgLayersOutputs.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.изображениеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(939, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNetworkCreate,
            this.menuNetworkOpen,
            this.menuNetworkSaveAs});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.файлToolStripMenuItem.Text = "Сеть";
            // 
            // menuNetworkCreate
            // 
            this.menuNetworkCreate.Name = "menuNetworkCreate";
            this.menuNetworkCreate.Size = new System.Drawing.Size(159, 22);
            this.menuNetworkCreate.Text = "Создать";
            this.menuNetworkCreate.Click += new System.EventHandler(this.MenuNetworkCreateClick);
            // 
            // menuNetworkOpen
            // 
            this.menuNetworkOpen.Name = "menuNetworkOpen";
            this.menuNetworkOpen.Size = new System.Drawing.Size(159, 22);
            this.menuNetworkOpen.Text = "Открыть...";
            this.menuNetworkOpen.Click += new System.EventHandler(this.MenuNetworkOpenClick);
            // 
            // menuNetworkSaveAs
            // 
            this.menuNetworkSaveAs.Name = "menuNetworkSaveAs";
            this.menuNetworkSaveAs.Size = new System.Drawing.Size(159, 22);
            this.menuNetworkSaveAs.Text = "Сохранить как..";
            this.menuNetworkSaveAs.Click += new System.EventHandler(this.MenuNetworkSaveAsClick);
            // 
            // изображениеToolStripMenuItem
            // 
            this.изображениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьКакToolStripMenuItem1});
            this.изображениеToolStripMenuItem.Enabled = false;
            this.изображениеToolStripMenuItem.Name = "изображениеToolStripMenuItem";
            this.изображениеToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.изображениеToolStripMenuItem.Text = "Изображение";
            // 
            // сохранитьКакToolStripMenuItem1
            // 
            this.сохранитьКакToolStripMenuItem1.Name = "сохранитьКакToolStripMenuItem1";
            this.сохранитьКакToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
            this.сохранитьКакToolStripMenuItem1.Text = "Сохранить как...";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.txtStatistics, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.imgLayersOutputs, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnClearHistory, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(939, 464);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // btnClearHistory
            // 
            this.btnClearHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClearHistory.Location = new System.Drawing.Point(3, 438);
            this.btnClearHistory.Name = "btnClearHistory";
            this.btnClearHistory.Size = new System.Drawing.Size(275, 23);
            this.btnClearHistory.TabIndex = 10;
            this.btnClearHistory.Text = "Очистить историю";
            this.btnClearHistory.UseVisualStyleBackColor = true;
            this.btnClearHistory.Click += new System.EventHandler(this.BtnClearHistoryClick);
            // 
            // NetworkForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(939, 488);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "NetworkForm";
            this.Text = "Нейронная сеть - Новая";
            ((System.ComponentModel.ISupportInitialize)(this.imgLayersOutputs)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStatistics;
        private System.Windows.Forms.PictureBox imgLayersOutputs;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuNetworkCreate;
        private System.Windows.Forms.ToolStripMenuItem menuNetworkOpen;
        private System.Windows.Forms.ToolStripMenuItem menuNetworkSaveAs;
        private System.Windows.Forms.ToolStripMenuItem изображениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem1;
        private System.Windows.Forms.Button btnClearHistory;
    }
}