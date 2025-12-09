namespace Car_Rental_Dbms_Project
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label3 = new Label();
            button1 = new Button();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold | FontStyle.Italic);
            label1.Location = new Point(147, 162);
            label1.Name = "label1";
            label1.Size = new Size(186, 38);
            label1.TabIndex = 0;
            label1.Text = "Kullanici Adi:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold | FontStyle.Italic);
            label2.Location = new Point(251, 229);
            label2.Name = "label2";
            label2.Size = new Size(80, 38);
            label2.TabIndex = 1;
            label2.Text = "Sifre:";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F);
            textBox1.Location = new Point(360, 166);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(191, 34);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 12F);
            textBox2.Location = new Point(360, 233);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(191, 34);
            textBox2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            label3.Location = new Point(72, 39);
            label3.Name = "label3";
            label3.Size = new Size(678, 54);
            label3.TabIndex = 4;
            label3.Text = "Akın Araç Kiralama Personel Girişi";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            button1.Location = new Point(311, 340);
            button1.Name = "button1";
            button1.Size = new Size(185, 65);
            button1.TabIndex = 5;
            button1.Text = "Giriş";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label4.Location = new Point(251, 292);
            label4.Name = "label4";
            label4.Size = new Size(0, 25);
            label4.TabIndex = 6;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumSpringGreen;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label3;
        private Button button1;
        private Label label4;
    }
}