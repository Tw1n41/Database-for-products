namespace Database_for_products
{
    partial class MaterialForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSelectFileToImport = new System.Windows.Forms.Button();
            this.btnLoadMaterials = new System.Windows.Forms.Button();
            this.btnGoToMainForm = new System.Windows.Forms.Button();
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
            this.dataGridView1.TabIndex = 1;
            // 
            // btnSelectFileToImport
            // 
            this.btnSelectFileToImport.Location = new System.Drawing.Point(532, 104);
            this.btnSelectFileToImport.Name = "btnSelectFileToImport";
            this.btnSelectFileToImport.Size = new System.Drawing.Size(116, 64);
            this.btnSelectFileToImport.TabIndex = 3;
            this.btnSelectFileToImport.Text = "Выбрать файл для загрузки";
            this.btnSelectFileToImport.UseVisualStyleBackColor = true;
            this.btnSelectFileToImport.Click += new System.EventHandler(this.btnSelectFileToImport_Click);
            // 
            // btnLoadMaterials
            // 
            this.btnLoadMaterials.Location = new System.Drawing.Point(532, 12);
            this.btnLoadMaterials.Name = "btnLoadMaterials";
            this.btnLoadMaterials.Size = new System.Drawing.Size(116, 64);
            this.btnLoadMaterials.TabIndex = 5;
            this.btnLoadMaterials.Text = "Загрузить материалы";
            this.btnLoadMaterials.UseVisualStyleBackColor = true;
            this.btnLoadMaterials.Click += new System.EventHandler(this.btnLoadMaterials_Click);
            // 
            // btnGoToMainForm
            // 
            this.btnGoToMainForm.Location = new System.Drawing.Point(712, 12);
            this.btnGoToMainForm.Name = "btnGoToMainForm";
            this.btnGoToMainForm.Size = new System.Drawing.Size(120, 76);
            this.btnGoToMainForm.TabIndex = 6;
            this.btnGoToMainForm.Text = "Вернуться на главный экран";
            this.btnGoToMainForm.UseVisualStyleBackColor = true;
            this.btnGoToMainForm.Click += new System.EventHandler(this.btnGoToMainForm_Click);
            // 
            // MaterialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 569);
            this.Controls.Add(this.btnGoToMainForm);
            this.Controls.Add(this.btnLoadMaterials);
            this.Controls.Add(this.btnSelectFileToImport);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MaterialForm";
            this.Text = "MaterialForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSelectFileToImport;
        private System.Windows.Forms.Button btnLoadMaterials;
        private System.Windows.Forms.Button btnGoToMainForm;
    }
}