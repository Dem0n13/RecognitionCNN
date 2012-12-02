namespace Recognition.Application
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.imgMNistImage = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.MNistDBPage = new System.Windows.Forms.TabPage();
            this.pnlTesting = new System.Windows.Forms.GroupBox();
            this.btnStopTesting = new System.Windows.Forms.Button();
            this.btnStartTesting = new System.Windows.Forms.Button();
            this.pnlTraining = new System.Windows.Forms.GroupBox();
            this.btnStopTraining = new System.Windows.Forms.Button();
            this.btnStartTraining = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.udMNistImageIndex = new System.Windows.Forms.NumericUpDown();
            this.pnlOpening = new System.Windows.Forms.GroupBox();
            this.lblMNistInfo = new System.Windows.Forms.Label();
            this.btnOpenMNist = new System.Windows.Forms.Button();
            this.lblMNistImage = new System.Windows.Forms.Label();
            this.btnRecognizeImage = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlRecognizing = new System.Windows.Forms.GroupBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblImageInfo = new System.Windows.Forms.Label();
            this.btnOpenImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgMNistImage)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.MNistDBPage.SuspendLayout();
            this.pnlTesting.SuspendLayout();
            this.pnlTraining.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udMNistImageIndex)).BeginInit();
            this.pnlOpening.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlRecognizing.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgMNistImage
            // 
            this.imgMNistImage.BackColor = System.Drawing.Color.White;
            this.imgMNistImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgMNistImage.Location = new System.Drawing.Point(10, 30);
            this.imgMNistImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.imgMNistImage.Name = "imgMNistImage";
            this.imgMNistImage.Size = new System.Drawing.Size(60, 60);
            this.imgMNistImage.TabIndex = 0;
            this.imgMNistImage.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.MNistDBPage);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(3, 4);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(417, 176);
            this.tabControl1.TabIndex = 2;
            // 
            // MNistDBPage
            // 
            this.MNistDBPage.Controls.Add(this.pnlTesting);
            this.MNistDBPage.Controls.Add(this.pnlTraining);
            this.MNistDBPage.Controls.Add(this.groupBox2);
            this.MNistDBPage.Controls.Add(this.pnlOpening);
            this.MNistDBPage.Location = new System.Drawing.Point(4, 26);
            this.MNistDBPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MNistDBPage.Name = "MNistDBPage";
            this.MNistDBPage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MNistDBPage.Size = new System.Drawing.Size(409, 146);
            this.MNistDBPage.TabIndex = 0;
            this.MNistDBPage.Text = "База MNist";
            this.MNistDBPage.UseVisualStyleBackColor = true;
            // 
            // pnlTesting
            // 
            this.pnlTesting.Controls.Add(this.btnStopTesting);
            this.pnlTesting.Controls.Add(this.btnStartTesting);
            this.pnlTesting.Location = new System.Drawing.Point(210, 80);
            this.pnlTesting.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlTesting.Name = "pnlTesting";
            this.pnlTesting.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlTesting.Size = new System.Drawing.Size(190, 60);
            this.pnlTesting.TabIndex = 14;
            this.pnlTesting.TabStop = false;
            this.pnlTesting.Text = "Тестирование";
            // 
            // btnStopTesting
            // 
            this.btnStopTesting.Location = new System.Drawing.Point(100, 20);
            this.btnStopTesting.Margin = new System.Windows.Forms.Padding(0);
            this.btnStopTesting.Name = "btnStopTesting";
            this.btnStopTesting.Size = new System.Drawing.Size(80, 30);
            this.btnStopTesting.TabIndex = 11;
            this.btnStopTesting.Text = "Закончить";
            this.btnStopTesting.UseVisualStyleBackColor = true;
            this.btnStopTesting.Click += new System.EventHandler(this.BtnStopTestingClick);
            // 
            // btnStartTesting
            // 
            this.btnStartTesting.Location = new System.Drawing.Point(10, 20);
            this.btnStartTesting.Margin = new System.Windows.Forms.Padding(0);
            this.btnStartTesting.Name = "btnStartTesting";
            this.btnStartTesting.Size = new System.Drawing.Size(80, 30);
            this.btnStartTesting.TabIndex = 10;
            this.btnStartTesting.Text = "Начать";
            this.btnStartTesting.UseVisualStyleBackColor = true;
            this.btnStartTesting.Click += new System.EventHandler(this.BtnStartTestingClick);
            // 
            // pnlTraining
            // 
            this.pnlTraining.Controls.Add(this.btnStopTraining);
            this.pnlTraining.Controls.Add(this.btnStartTraining);
            this.pnlTraining.Location = new System.Drawing.Point(10, 80);
            this.pnlTraining.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlTraining.Name = "pnlTraining";
            this.pnlTraining.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlTraining.Size = new System.Drawing.Size(190, 60);
            this.pnlTraining.TabIndex = 13;
            this.pnlTraining.TabStop = false;
            this.pnlTraining.Text = "Обучение";
            // 
            // btnStopTraining
            // 
            this.btnStopTraining.Location = new System.Drawing.Point(100, 20);
            this.btnStopTraining.Margin = new System.Windows.Forms.Padding(0);
            this.btnStopTraining.Name = "btnStopTraining";
            this.btnStopTraining.Size = new System.Drawing.Size(80, 30);
            this.btnStopTraining.TabIndex = 9;
            this.btnStopTraining.Text = "Закончить";
            this.btnStopTraining.UseVisualStyleBackColor = true;
            this.btnStopTraining.Click += new System.EventHandler(this.BtnStopTrainingClick);
            // 
            // btnStartTraining
            // 
            this.btnStartTraining.Location = new System.Drawing.Point(10, 20);
            this.btnStartTraining.Margin = new System.Windows.Forms.Padding(0);
            this.btnStartTraining.Name = "btnStartTraining";
            this.btnStartTraining.Size = new System.Drawing.Size(80, 30);
            this.btnStartTraining.TabIndex = 7;
            this.btnStartTraining.Text = "Начать";
            this.btnStartTraining.UseVisualStyleBackColor = true;
            this.btnStartTraining.Click += new System.EventHandler(this.BtnStartTrainingClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.udMNistImageIndex);
            this.groupBox2.Location = new System.Drawing.Point(210, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(190, 60);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "По индексу";
            // 
            // udMNistImageIndex
            // 
            this.udMNistImageIndex.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udMNistImageIndex.Location = new System.Drawing.Point(10, 20);
            this.udMNistImageIndex.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.udMNistImageIndex.Name = "udMNistImageIndex";
            this.udMNistImageIndex.Size = new System.Drawing.Size(170, 29);
            this.udMNistImageIndex.TabIndex = 2;
            this.udMNistImageIndex.ValueChanged += new System.EventHandler(this.UdMNistImageIndexValueChanged);
            // 
            // pnlOpening
            // 
            this.pnlOpening.Controls.Add(this.lblMNistInfo);
            this.pnlOpening.Controls.Add(this.btnOpenMNist);
            this.pnlOpening.Location = new System.Drawing.Point(10, 10);
            this.pnlOpening.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlOpening.Name = "pnlOpening";
            this.pnlOpening.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlOpening.Size = new System.Drawing.Size(190, 60);
            this.pnlOpening.TabIndex = 10;
            this.pnlOpening.TabStop = false;
            this.pnlOpening.Text = "Информация о базе";
            // 
            // lblMNistInfo
            // 
            this.lblMNistInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMNistInfo.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMNistInfo.ForeColor = System.Drawing.Color.DarkRed;
            this.lblMNistInfo.Location = new System.Drawing.Point(10, 20);
            this.lblMNistInfo.Name = "lblMNistInfo";
            this.lblMNistInfo.Size = new System.Drawing.Size(130, 30);
            this.lblMNistInfo.TabIndex = 12;
            this.lblMNistInfo.Text = "База не загружена";
            this.lblMNistInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOpenMNist
            // 
            this.btnOpenMNist.Location = new System.Drawing.Point(150, 20);
            this.btnOpenMNist.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOpenMNist.Name = "btnOpenMNist";
            this.btnOpenMNist.Size = new System.Drawing.Size(30, 30);
            this.btnOpenMNist.TabIndex = 4;
            this.btnOpenMNist.Text = "...";
            this.btnOpenMNist.UseVisualStyleBackColor = true;
            this.btnOpenMNist.Click += new System.EventHandler(this.BtnOpenMNistClick);
            // 
            // lblMNistImage
            // 
            this.lblMNistImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMNistImage.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMNistImage.Location = new System.Drawing.Point(80, 30);
            this.lblMNistImage.Name = "lblMNistImage";
            this.lblMNistImage.Size = new System.Drawing.Size(130, 60);
            this.lblMNistImage.TabIndex = 1;
            this.lblMNistImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRecognizeImage
            // 
            this.btnRecognizeImage.Location = new System.Drawing.Point(70, 140);
            this.btnRecognizeImage.Margin = new System.Windows.Forms.Padding(3, 0, 3, 4);
            this.btnRecognizeImage.Name = "btnRecognizeImage";
            this.btnRecognizeImage.Size = new System.Drawing.Size(141, 30);
            this.btnRecognizeImage.TabIndex = 7;
            this.btnRecognizeImage.Text = "Распознать";
            this.btnRecognizeImage.UseVisualStyleBackColor = true;
            this.btnRecognizeImage.Click += new System.EventHandler(this.BtnRecognizeImageClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlRecognizing, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(679, 205);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // pnlRecognizing
            // 
            this.pnlRecognizing.Controls.Add(this.imgMNistImage);
            this.pnlRecognizing.Controls.Add(this.btnRecognizeImage);
            this.pnlRecognizing.Controls.Add(this.lblMNistImage);
            this.pnlRecognizing.Location = new System.Drawing.Point(426, 3);
            this.pnlRecognizing.Name = "pnlRecognizing";
            this.pnlRecognizing.Size = new System.Drawing.Size(214, 177);
            this.pnlRecognizing.TabIndex = 8;
            this.pnlRecognizing.TabStop = false;
            this.pnlRecognizing.Text = "На входе сети";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(409, 146);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Изображение";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblImageInfo);
            this.groupBox1.Controls.Add(this.btnOpenImage);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(390, 60);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация об изображении";
            // 
            // lblImageInfo
            // 
            this.lblImageInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblImageInfo.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblImageInfo.ForeColor = System.Drawing.Color.DarkRed;
            this.lblImageInfo.Location = new System.Drawing.Point(10, 20);
            this.lblImageInfo.Name = "lblImageInfo";
            this.lblImageInfo.Size = new System.Drawing.Size(330, 30);
            this.lblImageInfo.TabIndex = 12;
            this.lblImageInfo.Text = "Изображение не загружено";
            this.lblImageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOpenImage
            // 
            this.btnOpenImage.Location = new System.Drawing.Point(350, 20);
            this.btnOpenImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(30, 30);
            this.btnOpenImage.TabIndex = 4;
            this.btnOpenImage.Text = "...";
            this.btnOpenImage.UseVisualStyleBackColor = true;
            this.btnOpenImage.Click += new System.EventHandler(this.BtnOpenImageClick);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnRecognizeImage;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(679, 205);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.imgMNistImage)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.MNistDBPage.ResumeLayout(false);
            this.pnlTesting.ResumeLayout(false);
            this.pnlTraining.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.udMNistImageIndex)).EndInit();
            this.pnlOpening.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlRecognizing.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgMNistImage;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage MNistDBPage;
        private System.Windows.Forms.Button btnOpenMNist;
        private System.Windows.Forms.NumericUpDown udMNistImageIndex;
        private System.Windows.Forms.Label lblMNistImage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox pnlOpening;
        private System.Windows.Forms.Button btnRecognizeImage;
        private System.Windows.Forms.Label lblMNistInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox pnlTraining;
        private System.Windows.Forms.Button btnStartTraining;
        private System.Windows.Forms.Button btnStopTraining;
        private System.Windows.Forms.GroupBox pnlTesting;
        private System.Windows.Forms.Button btnStopTesting;
        private System.Windows.Forms.Button btnStartTesting;
        private System.Windows.Forms.GroupBox pnlRecognizing;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblImageInfo;
        private System.Windows.Forms.Button btnOpenImage;
    }
}

