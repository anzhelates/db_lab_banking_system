namespace db_lab
{
    partial class MainMenu
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button7 = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(48, 419);
            button2.Name = "button2";
            button2.Size = new Size(183, 34);
            button2.TabIndex = 1;
            button2.Text = "Запити";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnQuery_Click;
            // 
            // button3
            // 
            button3.Location = new Point(274, 295);
            button3.Name = "button3";
            button3.Size = new Size(175, 34);
            button3.TabIndex = 2;
            button3.Text = "Рахунок";
            button3.UseVisualStyleBackColor = true;
            button3.Click += btnAccount_Click;
            // 
            // button4
            // 
            button4.Location = new Point(48, 95);
            button4.Name = "button4";
            button4.Size = new Size(175, 34);
            button4.TabIndex = 3;
            button4.Text = "Банк";
            button4.UseVisualStyleBackColor = true;
            button4.Click += btnBank_Click;
            // 
            // button5
            // 
            button5.Location = new Point(274, 160);
            button5.Name = "button5";
            button5.Size = new Size(175, 34);
            button5.TabIndex = 4;
            button5.Text = "Відділення";
            button5.UseVisualStyleBackColor = true;
            button5.Click += btnBranch_Click;
            // 
            // button6
            // 
            button6.Location = new Point(274, 226);
            button6.Name = "button6";
            button6.Size = new Size(175, 34);
            button6.TabIndex = 5;
            button6.Text = "Клієнт";
            button6.UseVisualStyleBackColor = true;
            button6.Click += btnClient_Click;
            // 
            // button8
            // 
            button8.Location = new Point(274, 95);
            button8.Name = "button8";
            button8.Size = new Size(175, 34);
            button8.TabIndex = 7;
            button8.Text = "Керівник";
            button8.UseVisualStyleBackColor = true;
            button8.Click += btnManager_Click;
            // 
            // button9
            // 
            button9.Location = new Point(48, 226);
            button9.Name = "button9";
            button9.Size = new Size(175, 34);
            button9.TabIndex = 8;
            button9.Text = "Послуга";
            button9.UseVisualStyleBackColor = true;
            button9.Click += btnService_Click;
            // 
            // button10
            // 
            button10.Location = new Point(48, 295);
            button10.Name = "button10";
            button10.Size = new Size(175, 34);
            button10.TabIndex = 9;
            button10.Text = "Надання послуги";
            button10.UseVisualStyleBackColor = true;
            button10.Click += btnServiceProvision_Click;
            // 
            // button7
            // 
            button7.Location = new Point(48, 160);
            button7.Name = "button7";
            button7.Size = new Size(175, 34);
            button7.TabIndex = 6;
            button7.Text = "Працівник";
            button7.UseVisualStyleBackColor = true;
            button7.Click += btnEmployee_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 50);
            label1.Name = "label1";
            label1.Size = new Size(144, 25);
            label1.TabIndex = 10;
            label1.Text = "Форми таблиць:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 373);
            label2.Name = "label2";
            label2.Size = new Size(136, 25);
            label2.TabIndex = 11;
            label2.Text = "Форма запитів:";
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1005, 578);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Name = "MainMenu";
            Text = "Main Menu";
            Load += MainMenu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button7;
        private Label label1;
        private Label label2;
    }
}
