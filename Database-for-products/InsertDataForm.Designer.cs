namespace Database_for_products
{
    partial class InsertDataForm
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
            this.btnGoToMainFrame = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DSE_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSaveDataDSE = new System.Windows.Forms.Button();
            this.btnSaveDataWithMaterials = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.DSE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DSE_name_w_materials = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.component_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.component_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.component_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_of_measurement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGoToMainFrame
            // 
            this.btnGoToMainFrame.Location = new System.Drawing.Point(907, 26);
            this.btnGoToMainFrame.Name = "btnGoToMainFrame";
            this.btnGoToMainFrame.Size = new System.Drawing.Size(116, 55);
            this.btnGoToMainFrame.TabIndex = 7;
            this.btnGoToMainFrame.Text = "Вернуться на главную";
            this.btnGoToMainFrame.UseVisualStyleBackColor = true;
            this.btnGoToMainFrame.Click += new System.EventHandler(this.btnGoToMainFrame_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.DSE_name});
            this.dataGridView1.Location = new System.Drawing.Point(32, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(507, 150);
            this.dataGridView1.TabIndex = 8;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Width = 125;
            // 
            // DSE_name
            // 
            this.DSE_name.HeaderText = "Имя ДСЕ";
            this.DSE_name.MinimumWidth = 6;
            this.DSE_name.Name = "DSE_name";
            this.DSE_name.Width = 125;
            // 
            // btnSaveDataDSE
            // 
            this.btnSaveDataDSE.Location = new System.Drawing.Point(687, 26);
            this.btnSaveDataDSE.Name = "btnSaveDataDSE";
            this.btnSaveDataDSE.Size = new System.Drawing.Size(116, 55);
            this.btnSaveDataDSE.TabIndex = 9;
            this.btnSaveDataDSE.Text = "Сохранить ввод ДСЕ";
            this.btnSaveDataDSE.UseVisualStyleBackColor = true;
            this.btnSaveDataDSE.Click += new System.EventHandler(this.btnSaveDataDSE_Click);
            // 
            // btnSaveDataWithMaterials
            // 
            this.btnSaveDataWithMaterials.Location = new System.Drawing.Point(907, 121);
            this.btnSaveDataWithMaterials.Name = "btnSaveDataWithMaterials";
            this.btnSaveDataWithMaterials.Size = new System.Drawing.Size(116, 55);
            this.btnSaveDataWithMaterials.TabIndex = 10;
            this.btnSaveDataWithMaterials.Text = "Сохранить материалы";
            this.btnSaveDataWithMaterials.UseVisualStyleBackColor = true;
            this.btnSaveDataWithMaterials.Click += new System.EventHandler(this.btnSaveDataWithMaterials_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DSE_ID,
            this.DSE_name_w_materials,
            this.component_type,
            this.component_code,
            this.component_name,
            this.quantity,
            this.unit_of_measurement});
            this.dataGridView2.Location = new System.Drawing.Point(32, 220);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(1031, 150);
            this.dataGridView2.TabIndex = 11;
            // 
            // DSE_ID
            // 
            this.DSE_ID.HeaderText = "ID ДСЕ";
            this.DSE_ID.MinimumWidth = 6;
            this.DSE_ID.Name = "DSE_ID";
            this.DSE_ID.Width = 125;
            // 
            // DSE_name_w_materials
            // 
            this.DSE_name_w_materials.HeaderText = "Имя ДСЕ";
            this.DSE_name_w_materials.MinimumWidth = 6;
            this.DSE_name_w_materials.Name = "DSE_name_w_materials";
            this.DSE_name_w_materials.Width = 125;
            // 
            // component_type
            // 
            this.component_type.HeaderText = "Тип комплектующей";
            this.component_type.MinimumWidth = 6;
            this.component_type.Name = "component_type";
            this.component_type.Width = 125;
            // 
            // component_code
            // 
            this.component_code.HeaderText = "Код комплектующей";
            this.component_code.MinimumWidth = 6;
            this.component_code.Name = "component_code";
            this.component_code.Width = 125;
            // 
            // component_name
            // 
            this.component_name.HeaderText = "Имя комплектующей";
            this.component_name.MinimumWidth = 6;
            this.component_name.Name = "component_name";
            this.component_name.Width = 125;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Количество";
            this.quantity.MinimumWidth = 6;
            this.quantity.Name = "quantity";
            this.quantity.Width = 125;
            // 
            // unit_of_measurement
            // 
            this.unit_of_measurement.HeaderText = "Единица измерения";
            this.unit_of_measurement.MinimumWidth = 6;
            this.unit_of_measurement.Name = "unit_of_measurement";
            this.unit_of_measurement.Width = 125;
            // 
            // InsertDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 450);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.btnSaveDataWithMaterials);
            this.Controls.Add(this.btnSaveDataDSE);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnGoToMainFrame);
            this.Name = "InsertDataForm";
            this.Text = "InsertDataForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGoToMainFrame;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DSE_name;
        private System.Windows.Forms.Button btnSaveDataDSE;
        private System.Windows.Forms.Button btnSaveDataWithMaterials;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DSE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DSE_name_w_materials;
        private System.Windows.Forms.DataGridViewTextBoxColumn component_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn component_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn component_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_of_measurement;
    }
}