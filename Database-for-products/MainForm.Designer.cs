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
            this.btnLoadMaterials = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnGoToMaterialFrame = new System.Windows.Forms.Button();
            this.btnGoToInsertData = new System.Windows.Forms.Button();
            this.btnExportData = new System.Windows.Forms.Button();
            this.btnSaveDataWithMaterials = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(491, 517);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnLoadDataToDGW1
            // 
            this.btnLoadDataToDGW1.Location = new System.Drawing.Point(509, 99);
            this.btnLoadDataToDGW1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoadDataToDGW1.Name = "btnLoadDataToDGW1";
            this.btnLoadDataToDGW1.Size = new System.Drawing.Size(116, 55);
            this.btnLoadDataToDGW1.TabIndex = 1;
            this.btnLoadDataToDGW1.Text = "Загрузить данные";
            this.btnLoadDataToDGW1.UseVisualStyleBackColor = true;
            this.btnLoadDataToDGW1.Click += new System.EventHandler(this.btnLoadDataToDGW1_Click);
            // 
            // btnSelectFileToImport
            // 
            this.btnSelectFileToImport.Location = new System.Drawing.Point(509, 14);
            this.btnSelectFileToImport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectFileToImport.Name = "btnSelectFileToImport";
            this.btnSelectFileToImport.Size = new System.Drawing.Size(116, 64);
            this.btnSelectFileToImport.TabIndex = 2;
            this.btnSelectFileToImport.Text = "Выбрать файл для загрузки";
            this.btnSelectFileToImport.UseVisualStyleBackColor = true;
            this.btnSelectFileToImport.Click += new System.EventHandler(this.btnSelectFileToImport_Click);
            // 
            // btGoToDeleteFrame
            // 
            this.btGoToDeleteFrame.Location = new System.Drawing.Point(1243, 11);
            this.btGoToDeleteFrame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btGoToDeleteFrame.Name = "btGoToDeleteFrame";
            this.btGoToDeleteFrame.Size = new System.Drawing.Size(116, 55);
            this.btGoToDeleteFrame.TabIndex = 3;
            this.btGoToDeleteFrame.Text = "Удалить данные";
            this.btGoToDeleteFrame.UseVisualStyleBackColor = true;
            this.btGoToDeleteFrame.Click += new System.EventHandler(this.btGoToDeleteFrame_Click);
            // 
            // btnLoadMaterials
            // 
            this.btnLoadMaterials.Location = new System.Drawing.Point(665, 14);
            this.btnLoadMaterials.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoadMaterials.Name = "btnLoadMaterials";
            this.btnLoadMaterials.Size = new System.Drawing.Size(116, 64);
            this.btnLoadMaterials.TabIndex = 4;
            this.btnLoadMaterials.Text = "Загрузить материалы";
            this.btnLoadMaterials.UseVisualStyleBackColor = true;
            this.btnLoadMaterials.Click += new System.EventHandler(this.btnLoadMaterials_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(536, 187);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(832, 342);
            this.dataGridView2.TabIndex = 5;
            // 
            // btnGoToMaterialFrame
            // 
            this.btnGoToMaterialFrame.Location = new System.Drawing.Point(665, 106);
            this.btnGoToMaterialFrame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGoToMaterialFrame.Name = "btnGoToMaterialFrame";
            this.btnGoToMaterialFrame.Size = new System.Drawing.Size(116, 55);
            this.btnGoToMaterialFrame.TabIndex = 6;
            this.btnGoToMaterialFrame.Text = "Таблица материалов";
            this.btnGoToMaterialFrame.UseVisualStyleBackColor = true;
            this.btnGoToMaterialFrame.Click += new System.EventHandler(this.btnGoToMaterialFrame_Click);
            // 
            // btnGoToInsertData
            // 
            this.btnGoToInsertData.Location = new System.Drawing.Point(800, 19);
            this.btnGoToInsertData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGoToInsertData.Name = "btnGoToInsertData";
            this.btnGoToInsertData.Size = new System.Drawing.Size(116, 55);
            this.btnGoToInsertData.TabIndex = 7;
            this.btnGoToInsertData.Text = "Ввод данных";
            this.btnGoToInsertData.UseVisualStyleBackColor = true;
            this.btnGoToInsertData.Click += new System.EventHandler(this.btnGoToInsertData_Click);
            // 
            // btnExportData
            // 
            this.btnExportData.Location = new System.Drawing.Point(940, 14);
            this.btnExportData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExportData.Name = "btnExportData";
            this.btnExportData.Size = new System.Drawing.Size(116, 55);
            this.btnExportData.TabIndex = 8;
            this.btnExportData.Text = "Сохранить в файл";
            this.btnExportData.UseVisualStyleBackColor = true;
            this.btnExportData.Click += new System.EventHandler(this.btnExportData_Click);
            // 
            // btnSaveDataWithMaterials
            // 
            this.btnSaveDataWithMaterials.Location = new System.Drawing.Point(921, 85);
            this.btnSaveDataWithMaterials.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveDataWithMaterials.Name = "btnSaveDataWithMaterials";
            this.btnSaveDataWithMaterials.Size = new System.Drawing.Size(151, 97);
            this.btnSaveDataWithMaterials.TabIndex = 9;
            this.btnSaveDataWithMaterials.Text = "Сохранить таблицу с материалами в файл";
            this.btnSaveDataWithMaterials.UseVisualStyleBackColor = true;
            this.btnSaveDataWithMaterials.Click += new System.EventHandler(this.btnSaveDataWithMaterials_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1380, 577);
            this.Controls.Add(this.btnSaveDataWithMaterials);
            this.Controls.Add(this.btnExportData);
            this.Controls.Add(this.btnGoToInsertData);
            this.Controls.Add(this.btnGoToMaterialFrame);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.btnLoadMaterials);
            this.Controls.Add(this.btGoToDeleteFrame);
            this.Controls.Add(this.btnSelectFileToImport);
            this.Controls.Add(this.btnLoadDataToDGW1);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Insert data";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnLoadDataToDGW1;
        private System.Windows.Forms.Button btnSelectFileToImport;
        private System.Windows.Forms.Button btGoToDeleteFrame;
        private System.Windows.Forms.Button btnLoadMaterials;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnGoToMaterialFrame;
        private System.Windows.Forms.Button btnGoToInsertData;
        private System.Windows.Forms.Button btnExportData;
        private System.Windows.Forms.Button btnSaveDataWithMaterials;
    }
}

