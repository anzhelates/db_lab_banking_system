namespace db_lab
{
    partial class ClientForm
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
            lblPhone = new Label();
            txtPhone = new TextBox();
            grpSubForm = new GroupBox();
            lblSelectedClient = new Label();
            dgvClientAccounts = new DataGridView();
            lblAccount = new Label();
            cmbAccount = new ComboBox();
            btnLinkAccount = new Button();
            grpSubForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientAccounts).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(608, 488);
            btnAdd.Click += btnAdd_Click_1;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(608, 528);
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(608, 568);
            // 
            // btnClear
            // 
            btnClear.Location = new Point(26, 568);
            btnClear.Click += btnClear_Click;
            // 
            // lblPassport
            // 
            lblPassport.AutoSize = true;
            lblPassport.Location = new Point(26, 321);
            lblPassport.Name = "lblPassport";
            lblPassport.Size = new Size(153, 25);
            lblPassport.TabIndex = 9;
            lblPassport.Text = "Номер паспорта:";
            // 
            // txtPassport
            // 
            txtPassport.Location = new Point(470, 321);
            txtPassport.Name = "txtPassport";
            txtPassport.Size = new Size(250, 31);
            txtPassport.TabIndex = 8;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(26, 377);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(44, 25);
            lblFullName.TabIndex = 7;
            lblFullName.Text = "ПІБ:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(470, 377);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(250, 31);
            txtFullName.TabIndex = 6;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(26, 434);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(85, 25);
            lblPhone.TabIndex = 5;
            lblPhone.Text = "Телефон:";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(470, 434);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(250, 31);
            txtPhone.TabIndex = 4;
            // 
            // grpSubForm
            // 
            grpSubForm.Controls.Add(lblSelectedClient);
            grpSubForm.Controls.Add(dgvClientAccounts);
            grpSubForm.Controls.Add(lblAccount);
            grpSubForm.Controls.Add(cmbAccount);
            grpSubForm.Controls.Add(btnLinkAccount);
            grpSubForm.Location = new Point(792, 99);
            grpSubForm.Name = "grpSubForm";
            grpSubForm.Size = new Size(500, 320);
            grpSubForm.TabIndex = 3;
            grpSubForm.TabStop = false;
            grpSubForm.Text = "Рахунки клієнта";
            grpSubForm.Enter += grpSubForm_Enter;
            // 
            // lblSelectedClient
            // 
            lblSelectedClient.AutoSize = true;
            lblSelectedClient.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSelectedClient.Location = new Point(15, 30);
            lblSelectedClient.Name = "lblSelectedClient";
            lblSelectedClient.Size = new Size(175, 25);
            lblSelectedClient.TabIndex = 0;
            lblSelectedClient.Text = "Клієнта не обрано";
            // 
            // dgvClientAccounts
            // 
            dgvClientAccounts.AllowUserToAddRows = false;
            dgvClientAccounts.AllowUserToDeleteRows = false;
            dgvClientAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientAccounts.Location = new Point(15, 65);
            dgvClientAccounts.Name = "dgvClientAccounts";
            dgvClientAccounts.ReadOnly = true;
            dgvClientAccounts.RowHeadersWidth = 62;
            dgvClientAccounts.Size = new Size(470, 170);
            dgvClientAccounts.TabIndex = 1;
            // 
            // lblAccount
            // 
            lblAccount.AutoSize = true;
            lblAccount.Location = new Point(15, 260);
            lblAccount.Name = "lblAccount";
            lblAccount.Size = new Size(56, 25);
            lblAccount.TabIndex = 2;
            lblAccount.Text = "IBAN:";
            // 
            // cmbAccount
            // 
            cmbAccount.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAccount.FormattingEnabled = true;
            cmbAccount.Location = new Point(85, 257);
            cmbAccount.Name = "cmbAccount";
            cmbAccount.Size = new Size(230, 33);
            cmbAccount.TabIndex = 3;
            // 
            // btnLinkAccount
            // 
            btnLinkAccount.Location = new Point(325, 254);
            btnLinkAccount.Name = "btnLinkAccount";
            btnLinkAccount.Size = new Size(160, 38);
            btnLinkAccount.TabIndex = 4;
            btnLinkAccount.Text = "Прив'язати";
            btnLinkAccount.UseVisualStyleBackColor = true;
            btnLinkAccount.Click += btnLinkAccount_Click;
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1372, 631);
            Controls.Add(grpSubForm);
            Controls.Add(txtPhone);
            Controls.Add(lblPhone);
            Controls.Add(txtFullName);
            Controls.Add(lblFullName);
            Controls.Add(txtPassport);
            Controls.Add(lblPassport);
            Name = "ClientForm";
            Text = "Управління клієнтами та їх рахунками";
            Load += ClientForm_Load;
            Controls.SetChildIndex(btnClear, 0);
            Controls.SetChildIndex(btnUpdate, 0);
            Controls.SetChildIndex(btnDelete, 0);
            Controls.SetChildIndex(btnAdd, 0);
            Controls.SetChildIndex(lblPassport, 0);
            Controls.SetChildIndex(txtPassport, 0);
            Controls.SetChildIndex(lblFullName, 0);
            Controls.SetChildIndex(txtFullName, 0);
            Controls.SetChildIndex(lblPhone, 0);
            Controls.SetChildIndex(txtPhone, 0);
            Controls.SetChildIndex(grpSubForm, 0);
            Controls.SetChildIndex(btnBack, 0);
            grpSubForm.ResumeLayout(false);
            grpSubForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientAccounts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblPassport;
        private System.Windows.Forms.TextBox txtPassport;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;

        private System.Windows.Forms.GroupBox grpSubForm;
        private System.Windows.Forms.Label lblSelectedClient;
        private System.Windows.Forms.DataGridView dgvClientAccounts;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.ComboBox cmbAccount;
        private System.Windows.Forms.Button btnLinkAccount;
    }
}