namespace db_lab
{
    partial class ManagerForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblBranch = new Label();
            cmbBranch = new ComboBox();
            lblEmployee = new Label();
            cmbEmployee = new ComboBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(608, 481);
            btnAdd.Click += btnAdd_Click_1;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(608, 521);
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(608, 561);
            // 
            // btnClear
            // 
            btnClear.Location = new Point(26, 561);
            btnClear.Click += btnClear_Click;
            // 
            // lblBranch
            // 
            lblBranch.AutoSize = true;
            lblBranch.Location = new Point(26, 323);
            lblBranch.Name = "lblBranch";
            lblBranch.Size = new Size(101, 25);
            lblBranch.TabIndex = 8;
            lblBranch.Text = "Відділення:";
            // 
            // cmbBranch
            // 
            cmbBranch.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBranch.FormattingEnabled = true;
            cmbBranch.Location = new Point(400, 323);
            cmbBranch.Name = "cmbBranch";
            cmbBranch.Size = new Size(320, 33);
            cmbBranch.TabIndex = 7;
            // 
            // lblEmployee
            // 
            lblEmployee.AutoSize = true;
            lblEmployee.Location = new Point(26, 375);
            lblEmployee.Name = "lblEmployee";
            lblEmployee.Size = new Size(141, 25);
            lblEmployee.TabIndex = 6;
            lblEmployee.Text = "Працівник філії:";
            // 
            // cmbEmployee
            // 
            cmbEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmployee.FormattingEnabled = true;
            cmbEmployee.Location = new Point(400, 375);
            cmbEmployee.Name = "cmbEmployee";
            cmbEmployee.Size = new Size(320, 33);
            cmbEmployee.TabIndex = 5;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(26, 429);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(118, 25);
            lblPhone.TabIndex = 4;
            lblPhone.Text = "Робочий тел:";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(400, 429);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(320, 31);
            txtPhone.TabIndex = 3;
            // 
            // ManagerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(822, 621);
            Controls.Add(txtPhone);
            Controls.Add(lblPhone);
            Controls.Add(cmbEmployee);
            Controls.Add(lblEmployee);
            Controls.Add(cmbBranch);
            Controls.Add(lblBranch);
            Name = "ManagerForm";
            Text = "Призначення керівників відділень";
            Load += ManagerForm_Load;
            Controls.SetChildIndex(btnClear, 0);
            Controls.SetChildIndex(btnUpdate, 0);
            Controls.SetChildIndex(btnDelete, 0);
            Controls.SetChildIndex(btnAdd, 0);
            Controls.SetChildIndex(lblBranch, 0);
            Controls.SetChildIndex(cmbBranch, 0);
            Controls.SetChildIndex(lblEmployee, 0);
            Controls.SetChildIndex(cmbEmployee, 0);
            Controls.SetChildIndex(lblPhone, 0);
            Controls.SetChildIndex(txtPhone, 0);
            Controls.SetChildIndex(btnBack, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
    }
}