namespace db_lab
{
    partial class BankForm
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
            lblIdNbu = new Label();
            txtIdNbu = new TextBox();
            lblAppName = new Label();
            txtName = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(608, 487);
            btnAdd.Click += btnAdd_Click_1;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(608, 527);
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(608, 567);
            // 
            // btnClear
            // 
            btnClear.Location = new Point(26, 567);
            btnClear.Click += btnClear_Click;
            // 
            // lblIdNbu
            // 
            lblIdNbu.AutoSize = true;
            lblIdNbu.Location = new Point(26, 326);
            lblIdNbu.Name = "lblIdNbu";
            lblIdNbu.Size = new Size(85, 25);
            lblIdNbu.TabIndex = 8;
            lblIdNbu.Text = "Код НБУ:";
            // 
            // txtIdNbu
            // 
            txtIdNbu.Location = new Point(420, 326);
            txtIdNbu.Name = "txtIdNbu";
            txtIdNbu.Size = new Size(300, 31);
            txtIdNbu.TabIndex = 7;
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Location = new Point(26, 377);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(65, 25);
            lblAppName.TabIndex = 6;
            lblAppName.Text = "Назва:";
            // 
            // txtName
            // 
            txtName.Location = new Point(420, 377);
            txtName.Name = "txtName";
            txtName.Size = new Size(300, 31);
            txtName.TabIndex = 5;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(26, 429);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(75, 25);
            lblAddress.TabIndex = 4;
            lblAddress.Text = "Адреса:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(420, 429);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(300, 31);
            txtAddress.TabIndex = 3;
            // 
            // BankForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 625);
            Controls.Add(txtAddress);
            Controls.Add(lblAddress);
            Controls.Add(txtName);
            Controls.Add(lblAppName);
            Controls.Add(txtIdNbu);
            Controls.Add(lblIdNbu);
            Name = "BankForm";
            Text = "Управління банками";
            Load += BankForm_Load;
            Controls.SetChildIndex(btnClear, 0);
            Controls.SetChildIndex(btnUpdate, 0);
            Controls.SetChildIndex(btnDelete, 0);
            Controls.SetChildIndex(btnAdd, 0);
            Controls.SetChildIndex(lblIdNbu, 0);
            Controls.SetChildIndex(txtIdNbu, 0);
            Controls.SetChildIndex(lblAppName, 0);
            Controls.SetChildIndex(txtName, 0);
            Controls.SetChildIndex(lblAddress, 0);
            Controls.SetChildIndex(txtAddress, 0);
            Controls.SetChildIndex(btnBack, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblIdNbu;
        private System.Windows.Forms.TextBox txtIdNbu;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
    }
}