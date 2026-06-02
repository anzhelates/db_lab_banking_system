namespace db_lab
{
    partial class EmployeeForm
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
            lblPassport = new Label();
            txtPassport = new TextBox();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblPosition = new Label();
            txtPosition = new TextBox();
            lblBranch = new Label();
            cmbBranch = new ComboBox();
            lblSupervisor = new Label();
            cmbSupervisor = new ComboBox();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(608, 589);
            btnAdd.Click += btnAdd_Click_1;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(608, 629);
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(608, 669);
            // 
            // btnClear
            // 
            btnClear.Location = new Point(26, 669);
            btnClear.Click += btnClear_Click;
            // 
            // lblPassport
            // 
            lblPassport.AutoSize = true;
            lblPassport.Location = new Point(26, 322);
            lblPassport.Name = "lblPassport";
            lblPassport.Size = new Size(153, 25);
            lblPassport.TabIndex = 12;
            lblPassport.Text = "Номер паспорта:";
            // 
            // txtPassport
            // 
            txtPassport.Location = new Point(420, 322);
            txtPassport.Name = "txtPassport";
            txtPassport.Size = new Size(300, 31);
            txtPassport.TabIndex = 11;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(26, 377);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(44, 25);
            lblFullName.TabIndex = 10;
            lblFullName.Text = "ПІБ:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(420, 377);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(300, 31);
            txtFullName.TabIndex = 9;
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Location = new Point(26, 431);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(76, 25);
            lblPosition.TabIndex = 8;
            lblPosition.Text = "Посада:";
            // 
            // txtPosition
            // 
            txtPosition.Location = new Point(420, 431);
            txtPosition.Name = "txtPosition";
            txtPosition.Size = new Size(300, 31);
            txtPosition.TabIndex = 7;
            // 
            // lblBranch
            // 
            lblBranch.AutoSize = true;
            lblBranch.Location = new Point(26, 485);
            lblBranch.Name = "lblBranch";
            lblBranch.Size = new Size(101, 25);
            lblBranch.TabIndex = 6;
            lblBranch.Text = "Відділення:";
            // 
            // cmbBranch
            // 
            cmbBranch.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBranch.FormattingEnabled = true;
            cmbBranch.Location = new Point(420, 485);
            cmbBranch.Name = "cmbBranch";
            cmbBranch.Size = new Size(300, 33);
            cmbBranch.TabIndex = 5;
            // 
            // lblSupervisor
            // 
            lblSupervisor.AutoSize = true;
            lblSupervisor.Location = new Point(26, 540);
            lblSupervisor.Name = "lblSupervisor";
            lblSupervisor.Size = new Size(89, 25);
            lblSupervisor.TabIndex = 4;
            lblSupervisor.Text = "Керівник:";
            // 
            // cmbSupervisor
            // 
            cmbSupervisor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSupervisor.FormattingEnabled = true;
            cmbSupervisor.Location = new Point(420, 540);
            cmbSupervisor.Name = "cmbSupervisor";
            cmbSupervisor.Size = new Size(300, 33);
            cmbSupervisor.TabIndex = 3;
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(819, 731);
            Controls.Add(cmbSupervisor);
            Controls.Add(lblSupervisor);
            Controls.Add(cmbBranch);
            Controls.Add(lblBranch);
            Controls.Add(txtPosition);
            Controls.Add(lblPosition);
            Controls.Add(txtFullName);
            Controls.Add(lblFullName);
            Controls.Add(txtPassport);
            Controls.Add(lblPassport);
            Name = "EmployeeForm";
            Text = "Управління персоналом";
            Load += EmployeeForm_Load;
            Controls.SetChildIndex(btnClear, 0);
            Controls.SetChildIndex(btnUpdate, 0);
            Controls.SetChildIndex(btnDelete, 0);
            Controls.SetChildIndex(btnAdd, 0);
            Controls.SetChildIndex(lblPassport, 0);
            Controls.SetChildIndex(txtPassport, 0);
            Controls.SetChildIndex(lblFullName, 0);
            Controls.SetChildIndex(txtFullName, 0);
            Controls.SetChildIndex(lblPosition, 0);
            Controls.SetChildIndex(txtPosition, 0);
            Controls.SetChildIndex(lblBranch, 0);
            Controls.SetChildIndex(cmbBranch, 0);
            Controls.SetChildIndex(lblSupervisor, 0);
            Controls.SetChildIndex(cmbSupervisor, 0);
            Controls.SetChildIndex(btnBack, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblPassport;
        private System.Windows.Forms.TextBox txtPassport;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.Label lblSupervisor;
        private System.Windows.Forms.ComboBox cmbSupervisor;
    }
}