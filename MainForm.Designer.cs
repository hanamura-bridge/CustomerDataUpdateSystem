namespace CustomerDataUpdateSystem
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_filename = new System.Windows.Forms.TextBox();
            this.textBoxJumpRow = new System.Windows.Forms.TextBox();
            this.textBoxDataProcessing = new System.Windows.Forms.TextBox();
            this.buttonUpdateGo = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TSCustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TelNum1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MailMagazine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxCountNumber = new System.Windows.Forms.TextBox();
            this.labelUpdateInfo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.labelUpdateInfo);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.textBoxCountNumber);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox_filename);
            this.panel1.Controls.Add(this.textBoxJumpRow);
            this.panel1.Controls.Add(this.textBoxDataProcessing);
            this.panel1.Controls.Add(this.buttonUpdateGo);
            this.panel1.Controls.Add(this.labelInfo);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1500, 100);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("游ゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(266, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 40);
            this.label2.TabIndex = 0;
            this.label2.Text = "読込開始指定";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("游ゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "読み込み件数";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_filename
            // 
            this.textBox_filename.Location = new System.Drawing.Point(1411, -8);
            this.textBox_filename.Multiline = true;
            this.textBox_filename.Name = "textBox_filename";
            this.textBox_filename.Size = new System.Drawing.Size(65, 82);
            this.textBox_filename.TabIndex = 0;
            this.textBox_filename.Visible = false;
            // 
            // textBoxJumpRow
            // 
            this.textBoxJumpRow.Font = new System.Drawing.Font("游ゴシック", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxJumpRow.Location = new System.Drawing.Point(396, 42);
            this.textBoxJumpRow.MaxLength = 7;
            this.textBoxJumpRow.Name = "textBoxJumpRow";
            this.textBoxJumpRow.Size = new System.Drawing.Size(120, 40);
            this.textBoxJumpRow.TabIndex = 2;
            // 
            // textBoxDataProcessing
            // 
            this.textBoxDataProcessing.Font = new System.Drawing.Font("游ゴシック", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxDataProcessing.Location = new System.Drawing.Point(139, 42);
            this.textBoxDataProcessing.MaxLength = 7;
            this.textBoxDataProcessing.Name = "textBoxDataProcessing";
            this.textBoxDataProcessing.Size = new System.Drawing.Size(120, 40);
            this.textBoxDataProcessing.TabIndex = 1;
            // 
            // buttonUpdateGo
            // 
            this.buttonUpdateGo.BackColor = System.Drawing.Color.White;
            this.buttonUpdateGo.Font = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonUpdateGo.Location = new System.Drawing.Point(535, 17);
            this.buttonUpdateGo.Name = "buttonUpdateGo";
            this.buttonUpdateGo.Size = new System.Drawing.Size(200, 80);
            this.buttonUpdateGo.TabIndex = 3;
            this.buttonUpdateGo.Text = "更新実行";
            this.buttonUpdateGo.UseVisualStyleBackColor = false;
            this.buttonUpdateGo.Click += new System.EventHandler(this.button1_Click);
            this.buttonUpdateGo.Enter += new System.EventHandler(this.button1_Enter);
            // 
            // labelInfo
            // 
            this.labelInfo.Font = new System.Drawing.Font("游ゴシック", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelInfo.ForeColor = System.Drawing.Color.White;
            this.labelInfo.Location = new System.Drawing.Point(763, 12);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(700, 40);
            this.labelInfo.TabIndex = 0;
            this.labelInfo.Text = "進行状況：";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.White;
            this.progressBar1.ForeColor = System.Drawing.Color.Blue;
            this.progressBar1.Location = new System.Drawing.Point(766, 52);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(700, 40);
            this.progressBar1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TSCustomerId,
            this.Name1,
            this.Name2,
            this.Name3,
            this.Name4,
            this.CompanyName,
            this.TelNum1,
            this.MailMagazine,
            this.CustomerId});
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(3, 98);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1475, 845);
            this.dataGridView1.TabIndex = 1;
            // 
            // TSCustomerId
            // 
            dataGridViewCellStyle19.Font = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TSCustomerId.DefaultCellStyle = dataGridViewCellStyle19;
            this.TSCustomerId.HeaderText = "TSｺｰﾄﾞ";
            this.TSCustomerId.MaxInputLength = 24;
            this.TSCustomerId.Name = "TSCustomerId";
            this.TSCustomerId.ReadOnly = true;
            this.TSCustomerId.Width = 150;
            // 
            // Name1
            // 
            dataGridViewCellStyle20.Font = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Name1.DefaultCellStyle = dataGridViewCellStyle20;
            this.Name1.HeaderText = "氏(あ,ア,A)";
            this.Name1.Name = "Name1";
            this.Name1.ReadOnly = true;
            this.Name1.Width = 80;
            // 
            // Name2
            // 
            dataGridViewCellStyle21.Font = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Name2.DefaultCellStyle = dataGridViewCellStyle21;
            this.Name2.HeaderText = "名(あ,ア,A)";
            this.Name2.Name = "Name2";
            this.Name2.ReadOnly = true;
            this.Name2.Width = 80;
            // 
            // Name3
            // 
            dataGridViewCellStyle22.Font = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Name3.DefaultCellStyle = dataGridViewCellStyle22;
            this.Name3.HeaderText = "氏(漢字)";
            this.Name3.Name = "Name3";
            this.Name3.ReadOnly = true;
            this.Name3.Width = 80;
            // 
            // Name4
            // 
            dataGridViewCellStyle23.Font = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Name4.DefaultCellStyle = dataGridViewCellStyle23;
            this.Name4.HeaderText = "名(漢字)";
            this.Name4.Name = "Name4";
            this.Name4.ReadOnly = true;
            this.Name4.Width = 80;
            // 
            // CompanyName
            // 
            dataGridViewCellStyle24.Font = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CompanyName.DefaultCellStyle = dataGridViewCellStyle24;
            this.CompanyName.HeaderText = "会社名";
            this.CompanyName.Name = "CompanyName";
            this.CompanyName.ReadOnly = true;
            // 
            // TelNum1
            // 
            dataGridViewCellStyle25.Font = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TelNum1.DefaultCellStyle = dataGridViewCellStyle25;
            this.TelNum1.HeaderText = "電話1";
            this.TelNum1.Name = "TelNum1";
            this.TelNum1.ReadOnly = true;
            this.TelNum1.Width = 80;
            // 
            // MailMagazine
            // 
            dataGridViewCellStyle26.Font = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MailMagazine.DefaultCellStyle = dataGridViewCellStyle26;
            this.MailMagazine.HeaderText = "メルマガ";
            this.MailMagazine.Name = "MailMagazine";
            this.MailMagazine.ReadOnly = true;
            this.MailMagazine.Width = 80;
            // 
            // CustomerId
            // 
            dataGridViewCellStyle27.Font = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CustomerId.DefaultCellStyle = dataGridViewCellStyle27;
            this.CustomerId.HeaderText = "顧客ID";
            this.CustomerId.Name = "CustomerId";
            this.CustomerId.ReadOnly = true;
            this.CustomerId.Width = 80;
            // 
            // textBoxCountNumber
            // 
            this.textBoxCountNumber.Location = new System.Drawing.Point(1367, 3);
            this.textBoxCountNumber.Name = "textBoxCountNumber";
            this.textBoxCountNumber.Size = new System.Drawing.Size(38, 25);
            this.textBoxCountNumber.TabIndex = 4;
            this.textBoxCountNumber.Visible = false;
            // 
            // labelUpdateInfo
            // 
            this.labelUpdateInfo.BackColor = System.Drawing.Color.Transparent;
            this.labelUpdateInfo.Font = new System.Drawing.Font("游ゴシック", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelUpdateInfo.ForeColor = System.Drawing.Color.Red;
            this.labelUpdateInfo.Location = new System.Drawing.Point(12, 9);
            this.labelUpdateInfo.Name = "labelUpdateInfo";
            this.labelUpdateInfo.Size = new System.Drawing.Size(500, 25);
            this.labelUpdateInfo.TabIndex = 5;
            this.labelUpdateInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelUpdateInfo.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 944);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "顧客情報更新システム";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonUpdateGo;
        private System.Windows.Forms.TextBox textBox_filename;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TSCustomerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name4;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TelNum1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MailMagazine;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerId;
        private System.Windows.Forms.TextBox textBoxDataProcessing;
        private System.Windows.Forms.TextBox textBoxJumpRow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCountNumber;
        private System.Windows.Forms.Label labelUpdateInfo;
    }
}

