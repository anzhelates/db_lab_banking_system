namespace db_lab
{
    partial class AccountForm
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
            lblIban = new Label();
            txtIban = new TextBox();
            lblBalance = new Label();
            txtBalance = new TextBox();
            lblCurrency = new Label();
            cmbCurrency = new ComboBox();
            lblExpiryDate = new Label();
            dtpExpiryDate = new DateTimePicker();
            grpSubForm = new GroupBox();
            lblSelectedAccount = new Label();
            dgvClientAccounts = new DataGridView();
            lblClient = new Label();
            cmbClient = new ComboBox();
            btnLinkClient = new Button();
            grpSubForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientAccounts).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(608, 536);
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(608, 576);
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(608, 616);
            // 
            // btnClear
            // 
            btnClear.Location = new Point(26, 616);
            btnClear.Click += btnClear_Click;
            // 
            // lblIban
            // 
            lblIban.AutoSize = true;
            lblIban.Location = new Point(26, 323);
            lblIban.Name = "lblIban";
            lblIban.Size = new Size(56, 25);
            lblIban.TabIndex = 11;
            lblIban.Text = "IBAN:";
            // 
            // txtIban
            // 
            txtIban.Location = new Point(470, 323);
            txtIban.Name = "txtIban";
            txtIban.Size = new Size(250, 31);
            txtIban.TabIndex = 10;
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Location = new Point(26, 375);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(71, 25);
            lblBalance.TabIndex = 9;
            lblBalance.Text = "Баланс:";
            // 
            // txtBalance
            // 
            txtBalance.Location = new Point(470, 375);
            txtBalance.Name = "txtBalance";
            txtBalance.Size = new Size(250, 31);
            txtBalance.TabIndex = 8;
            txtBalance.Text = "0,00";
            // 
            // lblCurrency
            // 
            lblCurrency.AutoSize = true;
            lblCurrency.Location = new Point(26, 419);
            lblCurrency.Name = "lblCurrency";
            lblCurrency.Size = new Size(75, 25);
            lblCurrency.TabIndex = 7;
            lblCurrency.Text = "Валюта:";
            // 
            // cmbCurrency
            // 
            cmbCurrency.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCurrency.FormattingEnabled = true;
            cmbCurrency.Location = new Point(470, 424);
            cmbCurrency.Name = "cmbCurrency";
            cmbCurrency.Size = new Size(250, 33);
            cmbCurrency.TabIndex = 6;
            // 
            // lblExpiryDate
            // 
            lblExpiryDate.AutoSize = true;
            lblExpiryDate.Location = new Point(26, 475);
            lblExpiryDate.Name = "lblExpiryDate";
            lblExpiryDate.Size = new Size(121, 25);
            lblExpiryDate.TabIndex = 5;
            lblExpiryDate.Text = "Термін дії до:";
            // 
            // dtpExpiryDate
            // 
            dtpExpiryDate.Location = new Point(470, 475);
            dtpExpiryDate.Name = "dtpExpiryDate";
            dtpExpiryDate.Size = new Size(250, 31);
            dtpExpiryDate.TabIndex = 4;
            // 
            // grpSubForm
            // 
            grpSubForm.Controls.Add(lblSelectedAccount);
            grpSubForm.Controls.Add(dgvClientAccounts);
            grpSubForm.Controls.Add(lblClient);
            grpSubForm.Controls.Add(cmbClient);
            grpSubForm.Controls.Add(btnLinkClient);
            grpSubForm.Location = new Point(826, 99);
            grpSubForm.Name = "grpSubForm";
            grpSubForm.Size = new Size(500, 320);
            grpSubForm.TabIndex = 3;
            grpSubForm.TabStop = false;
            grpSubForm.Text = "Клієнти рахунку";
            // 
            // lblSelectedAccount
            // 
            lblSelectedAccount.AutoSize = true;
            lblSelectedAccount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSelectedAccount.Location = new Point(15, 30);
            lblSelectedAccount.Name = "lblSelectedAccount";
            lblSelectedAccount.Size = new Size(181, 25);
            lblSelectedAccount.TabIndex = 0;
            lblSelectedAccount.Text = "Рахунок не обрано";
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
            // lblClient
            // 
            lblClient.AutoSize = true;
            lblClient.Location = new Point(15, 260);
            lblClient.Name = "lblClient";
            lblClient.Size = new Size(64, 25);
            lblClient.TabIndex = 2;
            lblClient.Text = "Клієнт:";
            // 
            // cmbClient
            // 
            cmbClient.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClient.FormattingEnabled = true;
            cmbClient.Location = new Point(85, 257);
            cmbClient.Name = "cmbClient";
            cmbClient.Size = new Size(230, 33);
            cmbClient.TabIndex = 3;
            // 
            // btnLinkClient
            // 
            btnLinkClient.Location = new Point(325, 254);
            btnLinkClient.Name = "btnLinkClient";
            btnLinkClient.Size = new Size(160, 38);
            btnLinkClient.TabIndex = 4;
            btnLinkClient.Text = "Прив'язати";
            btnLinkClient.UseVisualStyleBackColor = true;
            btnLinkClient.Click += btnLinkClient_Click;
            // 
            // AccountForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 666);
            Controls.Add(grpSubForm);
            Controls.Add(dtpExpiryDate);
            Controls.Add(lblExpiryDate);
            Controls.Add(cmbCurrency);
            Controls.Add(lblCurrency);
            Controls.Add(txtBalance);
            Controls.Add(lblBalance);
            Controls.Add(txtIban);
            Controls.Add(lblIban);
            Name = "AccountForm";
            Text = "Управління рахунками та власниками";
            Load += AccountForm_Load;
            Controls.SetChildIndex(btnClear, 0);
            Controls.SetChildIndex(btnUpdate, 0);
            Controls.SetChildIndex(btnDelete, 0);
            Controls.SetChildIndex(btnAdd, 0);
            Controls.SetChildIndex(lblIban, 0);
            Controls.SetChildIndex(txtIban, 0);
            Controls.SetChildIndex(lblBalance, 0);
            Controls.SetChildIndex(txtBalance, 0);
            Controls.SetChildIndex(lblCurrency, 0);
            Controls.SetChildIndex(cmbCurrency, 0);
            Controls.SetChildIndex(lblExpiryDate, 0);
            Controls.SetChildIndex(dtpExpiryDate, 0);
            Controls.SetChildIndex(grpSubForm, 0);
            Controls.SetChildIndex(btnBack, 0);
            grpSubForm.ResumeLayout(false);
            grpSubForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientAccounts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblIban;
        private System.Windows.Forms.TextBox txtIban;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.Label lblExpiryDate;
        private System.Windows.Forms.DateTimePicker dtpExpiryDate;

        private System.Windows.Forms.GroupBox grpSubForm;
        private System.Windows.Forms.Label lblSelectedAccount;
        private System.Windows.Forms.DataGridView dgvClientAccounts;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.Button btnLinkClient;
    }
}