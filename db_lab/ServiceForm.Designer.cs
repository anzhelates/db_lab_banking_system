namespace db_lab
{
    partial class ServiceForm
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
            lblName = new Label();
            txtName = new TextBox();
            lblCost = new Label();
            txtCost = new TextBox();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(608, 431);
            btnAdd.Click += btnAdd_Click_1;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(608, 471);
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(608, 511);
            // 
            // btnClear
            // 
            btnClear.Location = new Point(26, 511);
            btnClear.Click += btnClear_Click;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(26, 325);
            lblName.Name = "lblName";
            lblName.Size = new Size(134, 25);
            lblName.TabIndex = 6;
            lblName.Text = "Назва послуги:";
            // 
            // txtName
            // 
            txtName.Location = new Point(370, 325);
            txtName.Name = "txtName";
            txtName.Size = new Size(350, 31);
            txtName.TabIndex = 5;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // lblCost
            // 
            lblCost.AutoSize = true;
            lblCost.Location = new Point(26, 377);
            lblCost.Name = "lblCost";
            lblCost.Size = new Size(81, 25);
            lblCost.TabIndex = 4;
            lblCost.Text = "Вартість:";
            // 
            // txtCost
            // 
            txtCost.Location = new Point(370, 377);
            txtCost.Name = "txtCost";
            txtCost.Size = new Size(350, 31);
            txtCost.TabIndex = 3;
            // 
            // ServiceForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 574);
            Controls.Add(txtCost);
            Controls.Add(lblCost);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Name = "ServiceForm";
            Text = "Довідник послуг банку";
            Load += ServiceForm_Load;
            Controls.SetChildIndex(btnClear, 0);
            Controls.SetChildIndex(btnUpdate, 0);
            Controls.SetChildIndex(btnDelete, 0);
            Controls.SetChildIndex(btnAdd, 0);
            Controls.SetChildIndex(lblName, 0);
            Controls.SetChildIndex(txtName, 0);
            Controls.SetChildIndex(lblCost, 0);
            Controls.SetChildIndex(txtCost, 0);
            Controls.SetChildIndex(btnBack, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.TextBox txtCost;
    }
}