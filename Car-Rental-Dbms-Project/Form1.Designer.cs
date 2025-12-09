namespace Car_Rental_Dbms_Project
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = Properties.Resources.Ekran_görüntüsü_2024_12_20_172517;
            pictureBox1.Location = new Point(40, 97);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(253, 250);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Image = Properties.Resources.Ekran_görüntüsü_2024_12_20_172526;
            pictureBox2.Location = new Point(415, 99);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(261, 248);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(193, 21);
            label1.Name = "label1";
            label1.Size = new Size(356, 50);
            label1.TabIndex = 3;
            label1.Text = "Akın Araç Kiralama";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            label2.Location = new Point(99, 365);
            label2.Name = "label2";
            label2.Size = new Size(135, 46);
            label2.TabIndex = 4;
            label2.Text = "Müşteri";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            label3.Location = new Point(480, 365);
            label3.Name = "label3";
            label3.Size = new Size(143, 46);
            label3.TabIndex = 5;
            label3.Text = "Yönetici";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumAquamarine;
            ClientSize = new Size(725, 437);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Giris";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
