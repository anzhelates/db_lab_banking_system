namespace db_lab
{
    partial class BranchForm
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtBranchNumber = new TextBox();
            txtAddress = new TextBox();
            lblBank = new Label();
            lblBranchNumber = new Label();
            lblAddress = new Label();
            cmbBank = new ComboBox();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(608, 485);
            btnAdd.Click += btnAdd_Click_1;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(608, 525);
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(608, 565);
            // 
            // btnClear
            // 
            btnClear.Location = new Point(26, 565);
            btnClear.Click += btnClear_Click;
            // 
            // txtBranchNumber
            // 
            txtBranchNumber.Location = new Point(457, 377);
            txtBranchNumber.Name = "txtBranchNumber";
            txtBranchNumber.Size = new Size(263, 31);
            txtBranchNumber.TabIndex = 3;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(457, 431);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(263, 31);
            txtAddress.TabIndex = 5;
            // 
            // lblBank
            // 
            lblBank.AutoSize = true;
            lblBank.Location = new Point(26, 323);
            lblBank.Name = "lblBank";
            lblBank.Size = new Size(54, 25);
            lblBank.TabIndex = 0;
            lblBank.Text = "Банк:";
            lblBank.Click += lblBank_Click;
            // 
            // lblBranchNumber
            // 
            lblBranchNumber.AutoSize = true;
            lblBranchNumber.Location = new Point(26, 377);
            lblBranchNumber.Name = "lblBranchNumber";
            lblBranchNumber.Size = new Size(163, 25);
            lblBranchNumber.TabIndex = 2;
            lblBranchNumber.Text = "Номер відділення:";
            lblBranchNumber.Click += lblBranchNumber_Click;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(26, 431);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(75, 25);
            lblAddress.TabIndex = 4;
            lblAddress.Text = "Адреса:";
            // 
            // cmbBank
            // 
            cmbBank.FormattingEnabled = true;
            cmbBank.Location = new Point(457, 323);
            cmbBank.Name = "cmbBank";
            cmbBank.Size = new Size(263, 33);
            cmbBank.TabIndex = 6;
            // 
            // BranchForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(809, 627);
            Controls.Add(cmbBank);
            Controls.Add(txtAddress);
            Controls.Add(lblAddress);
            Controls.Add(txtBranchNumber);
            Controls.Add(lblBranchNumber);
            Controls.Add(lblBank);
            Name = "BranchForm";
            Text = "Управління відділеннями";
            Load += BranchForm_Load;
            Controls.SetChildIndex(btnClear, 0);
            Controls.SetChildIndex(btnUpdate, 0);
            Controls.SetChildIndex(btnDelete, 0);
            Controls.SetChildIndex(btnAdd, 0);
            Controls.SetChildIndex(btnBack, 0);
            Controls.SetChildIndex(lblBank, 0);
            Controls.SetChildIndex(lblBranchNumber, 0);
            Controls.SetChildIndex(txtBranchNumber, 0);
            Controls.SetChildIndex(lblAddress, 0);
            Controls.SetChildIndex(txtAddress, 0);
            Controls.SetChildIndex(cmbBank, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtBranchNumber;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.Label lblBranchNumber;
        private System.Windows.Forms.Label lblAddress;
        private ComboBox cmbBank;
    }
}