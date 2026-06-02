namespace db_lab
{
    partial class QueryForm
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
            btnPrev = new Button();
            btnNext = new Button();
            lblQueryDescription = new Label();
            txtParameter = new TextBox();
            btnExecute = new Button();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(683, 617);
            btnAdd.Text = "";
            // 
            // btnPrev
            // 
            btnPrev.Location = new Point(26, 314);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(40, 40);
            btnPrev.TabIndex = 7;
            btnPrev.Text = "<-";
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(72, 314);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(40, 40);
            btnNext.TabIndex = 6;
            btnNext.Text = "->";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // lblQueryDescription
            // 
            lblQueryDescription.AutoSize = true;
            lblQueryDescription.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblQueryDescription.Location = new Point(26, 68);
            lblQueryDescription.Name = "lblQueryDescription";
            lblQueryDescription.Size = new Size(148, 28);
            lblQueryDescription.TabIndex = 5;
            lblQueryDescription.Text = "[Опис запиту]";
            // 
            // txtParameter
            // 
            txtParameter.Location = new Point(835, 65);
            txtParameter.Name = "txtParameter";
            txtParameter.Size = new Size(92, 31);
            txtParameter.TabIndex = 4;
            // 
            // btnExecute
            // 
            btnExecute.Location = new Point(777, 314);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new Size(150, 38);
            btnExecute.TabIndex = 3;
            btnExecute.Text = "Виконати";
            btnExecute.UseVisualStyleBackColor = true;
            btnExecute.Click += btnExecute_Click;
            // 
            // QueryForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(989, 600);
            Controls.Add(btnExecute);
            Controls.Add(txtParameter);
            Controls.Add(lblQueryDescription);
            Controls.Add(btnNext);
            Controls.Add(btnPrev);
            Name = "QueryForm";
            Text = "Перегляд запитів";
            Load += QueryForm_Load;
            Controls.SetChildIndex(btnPrev, 0);
            Controls.SetChildIndex(btnNext, 0);
            Controls.SetChildIndex(lblQueryDescription, 0);
            Controls.SetChildIndex(txtParameter, 0);
            Controls.SetChildIndex(btnExecute, 0);
            Controls.SetChildIndex(btnBack, 0);
            Controls.SetChildIndex(btnAdd, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblQueryDescription;
        private System.Windows.Forms.TextBox txtParameter;
        private System.Windows.Forms.Button btnExecute;
    }
}