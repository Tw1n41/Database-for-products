namespace Database_for_products
{
    partial class DeleteForm
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
            this.btnGoToMainForm = new System.Windows.Forms.Button();
            this.btnDeleteMultiRow = new System.Windows.Forms.Button();
            this.txtBoxNameToDel = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGoToMainForm
            // 
            this.btnGoToMainForm.Location = new System.Drawing.Point(668, 41);
            this.btnGoToMainForm.Name = "btnGoToMainForm";
            this.btnGoToMainForm.Size = new System.Drawing.Size(120, 76);
            this.btnGoToMainForm.TabIndex = 0;
            this.btnGoToMainForm.Text = "Вернуться на главный экран";
            this.btnGoToMainForm.UseVisualStyleBackColor = true;
            this.btnGoToMainForm.Click += new System.EventHandler(this.btnGoToMainForm_Click);
            // 
            // btnDeleteMultiRow
            // 
            this.btnDeleteMultiRow.Location = new System.Drawing.Point(530, 45);
            this.btnDeleteMultiRow.Name = "btnDeleteMultiRow";
            this.btnDeleteMultiRow.Size = new System.Drawing.Size(122, 72);
            this.btnDeleteMultiRow.TabIndex = 2;
            this.btnDeleteMultiRow.Text = "Удалить несколько строк";
            this.btnDeleteMultiRow.UseVisualStyleBackColor = true;
            this.btnDeleteMultiRow.Click += new System.EventHandler(this.btnDeleteMultiRow_Click);
            // 
            // txtBoxNameToDel
            // 
            this.txtBoxNameToDel.Location = new System.Drawing.Point(25, 41);
            this.txtBoxNameToDel.Name = "txtBoxNameToDel";
            this.txtBoxNameToDel.Size = new System.Drawing.Size(478, 22);
            this.txtBoxNameToDel.TabIndex = 3;
            // 
            // DeleteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtBoxNameToDel);
            this.Controls.Add(this.btnDeleteMultiRow);
            this.Controls.Add(this.btnGoToMainForm);
            this.Name = "DeleteForm";
            this.Text = "Delete data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGoToMainForm;
        private System.Windows.Forms.Button btnDeleteMultiRow;
        private System.Windows.Forms.TextBox txtBoxNameToDel;
    }
}