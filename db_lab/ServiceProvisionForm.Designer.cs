namespace db_lab
{
    partial class ServiceProvisionForm
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
            lblEmployee = new Label();
            cmbEmployee = new ComboBox();
            lblClient = new Label();
            cmbClient = new ComboBox();
            lblService = new Label();
            cmbService = new ComboBox();
            lblDate = new Label();
            dtpDate = new DateTimePicker();
            lblTime = new Label();
            dtpTime = new DateTimePicker();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(608, 583);
            btnAdd.Click += btnAdd_Click_1;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(608, 623);
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(608, 663);
            // 
            // btnClear
            // 
            btnClear.Click += btnClear_Click;
            // 
            // lblEmployee
            // 
            lblEmployee.AutoSize = true;
            lblEmployee.Location = new Point(26, 323);
            lblEmployee.Name = "lblEmployee";
            lblEmployee.Size = new Size(103, 25);
            lblEmployee.TabIndex = 12;
            lblEmployee.Text = "Працівник:";
            // 
            // cmbEmployee
            // 
            cmbEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmployee.FormattingEnabled = true;
            cmbEmployee.Location = new Point(400, 323);
            cmbEmployee.Name = "cmbEmployee";
            cmbEmployee.Size = new Size(320, 33);
            cmbEmployee.TabIndex = 11;
            // 
            // lblClient
            // 
            lblClient.AutoSize = true;
            lblClient.Location = new Point(26, 375);
            lblClient.Name = "lblClient";
            lblClient.Size = new Size(64, 25);
            lblClient.TabIndex = 10;
            lblClient.Text = "Клієнт:";
            // 
            // cmbClient
            // 
            cmbClient.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClient.FormattingEnabled = true;
            cmbClient.Location = new Point(400, 375);
            cmbClient.Name = "cmbClient";
            cmbClient.Size = new Size(320, 33);
            cmbClient.TabIndex = 9;
            // 
            // lblService
            // 
            lblService.AutoSize = true;
            lblService.Location = new Point(26, 429);
            lblService.Name = "lblService";
            lblService.Size = new Size(82, 25);
            lblService.TabIndex = 8;
            lblService.Text = "Послуга:";
            // 
            // cmbService
            // 
            cmbService.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbService.FormattingEnabled = true;
            cmbService.Location = new Point(400, 429);
            cmbService.Name = "cmbService";
            cmbService.Size = new Size(320, 33);
            cmbService.TabIndex = 7;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(26, 482);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(53, 25);
            lblDate.TabIndex = 6;
            lblDate.Text = "Дата:";
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(400, 482);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(320, 31);
            dtpDate.TabIndex = 5;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(26, 533);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(45, 25);
            lblTime.TabIndex = 4;
            lblTime.Text = "Час:";
            // 
            // dtpTime
            // 
            dtpTime.Format = DateTimePickerFormat.Time;
            dtpTime.Location = new Point(400, 533);
            dtpTime.Name = "dtpTime";
            dtpTime.ShowUpDown = true;
            dtpTime.Size = new Size(320, 31);
            dtpTime.TabIndex = 3;
            // 
            // ServiceProvisionForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(827, 723);
            Controls.Add(dtpTime);
            Controls.Add(lblTime);
            Controls.Add(dtpDate);
            Controls.Add(lblDate);
            Controls.Add(cmbService);
            Controls.Add(lblService);
            Controls.Add(cmbClient);
            Controls.Add(lblClient);
            Controls.Add(cmbEmployee);
            Controls.Add(lblEmployee);
            Name = "ServiceProvisionForm";
            Text = "Реєстрація надання послуг клієнтам";
            Load += ServiceProvisionForm_Load;
            Controls.SetChildIndex(btnClear, 0);
            Controls.SetChildIndex(btnUpdate, 0);
            Controls.SetChildIndex(btnDelete, 0);
            Controls.SetChildIndex(btnAdd, 0);
            Controls.SetChildIndex(lblEmployee, 0);
            Controls.SetChildIndex(cmbEmployee, 0);
            Controls.SetChildIndex(lblClient, 0);
            Controls.SetChildIndex(cmbClient, 0);
            Controls.SetChildIndex(lblService, 0);
            Controls.SetChildIndex(cmbService, 0);
            Controls.SetChildIndex(lblDate, 0);
            Controls.SetChildIndex(dtpDate, 0);
            Controls.SetChildIndex(lblTime, 0);
            Controls.SetChildIndex(dtpTime, 0);
            Controls.SetChildIndex(btnBack, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.ComboBox cmbService;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.DateTimePicker dtpTime;
    }
}