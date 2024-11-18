namespace Database_for_products
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnLoadDataToDGW1 = new System.Windows.Forms.Button();
            this.btnSelectFileToImport = new System.Windows.Forms.Button();
            this.btGoToDeleteFrame = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(491, 342);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnLoadDataToDGW1
            // 
            this.btnLoadDataToDGW1.Location = new System.Drawing.Point(518, 12);
            this.btnLoadDataToDGW1.Name = "btnLoadDataToDGW1";
            this.btnLoadDataToDGW1.Size = new System.Drawing.Size(116, 55);
            this.btnLoadDataToDGW1.TabIndex = 1;
            this.btnLoadDataToDGW1.Text = "Загрузить данные";
            this.btnLoadDataToDGW1.UseVisualStyleBackColor = true;
            this.btnLoadDataToDGW1.Click += new System.EventHandler(this.btnLoadDataToDGW1_Click);
            // 
            // btnSelectFileToImport
            // 
            this.btnSelectFileToImport.Location = new System.Drawing.Point(518, 94);
            this.btnSelectFileToImport.Name = "btnSelectFileToImport";
            this.btnSelectFileToImport.Size = new System.Drawing.Size(116, 64);
            this.btnSelectFileToImport.TabIndex = 2;
            this.btnSelectFileToImport.Text = "Выбрать файл для загрузки";
            this.btnSelectFileToImport.UseVisualStyleBackColor = true;
            this.btnSelectFileToImport.Click += new System.EventHandler(this.btnSelectFileToImport_Click);
            // 
            // btGoToDeleteFrame
            // 
            this.btGoToDeleteFrame.Location = new System.Drawing.Point(672, 12);
            this.btGoToDeleteFrame.Name = "btGoToDeleteFrame";
            this.btGoToDeleteFrame.Size = new System.Drawing.Size(116, 55);
            this.btGoToDeleteFrame.TabIndex = 3;
            this.btGoToDeleteFrame.Text = "Удалить данные";
            this.btGoToDeleteFrame.UseVisualStyleBackColor = true;
            this.btGoToDeleteFrame.Click += new System.EventHandler(this.btGoToDeleteFrame_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btGoToDeleteFrame);
            this.Controls.Add(this.btnSelectFileToImport);
            this.Controls.Add(this.btnLoadDataToDGW1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainForm";
            this.Text = "Insert data";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnLoadDataToDGW1;
        private System.Windows.Forms.Button btnSelectFileToImport;
        private System.Windows.Forms.Button btGoToDeleteFrame;
    }
}

