namespace Car_Rental_Dbms_Project
{
    partial class MusteriGiris
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
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton4 = new RadioButton();
            radioButton5 = new RadioButton();
            radioButton6 = new RadioButton();
            btnKiralama = new Button();
            txtAd = new TextBox();
            txtSokak = new TextBox();
            txtMahalle = new TextBox();
            txtIlce = new TextBox();
            txtSehir = new TextBox();
            txtTelefon = new TextBox();
            txtEmail = new TextBox();
            txtSoyad = new TextBox();
            txtAd1 = new Label();
            txtSokak1 = new Label();
            txtMahalle1 = new Label();
            txtIlce1 = new Label();
            txtSehir1 = new Label();
            txtTelefon1 = new Label();
            txtSoyad1 = new Label();
            txtEmail1 = new Label();
            txtKiralamaTarihi1 = new Label();
            txtKiralamaBitisTarihi1 = new Label();
            txtPostaKodu1 = new Label();
            txtPostaKodu = new TextBox();
            dateTimePickerKiralamaTarihi = new DateTimePicker();
            dateTimePickerKiralamaBitisTarihi = new DateTimePicker();
            yoneticiBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 48F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            label1.Location = new Point(30, 24);
            label1.Name = "label1";
            label1.Size = new Size(783, 106);
            label1.TabIndex = 0;
            label1.Text = "Akın Araç Kiralama";
            label1.Click += label1_Click;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 162);
            radioButton1.Location = new Point(1104, 364);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(216, 79);
            radioButton1.TabIndex = 1;
            radioButton1.TabStop = true;
            radioButton1.Text = "Renault Clio\r\nKiralamak İstiyorum\r\n( Günlük Ücret : 749 TL)\r\n";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic);
            radioButton2.Location = new Point(1378, 364);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(226, 79);
            radioButton2.TabIndex = 2;
            radioButton2.TabStop = true;
            radioButton2.Text = "Toyota Corolla\r\nKiralamak İstiyorum\r\n( Günlük Ücret : 1299 TL)\r\n";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic);
            radioButton3.Location = new Point(1635, 364);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(216, 104);
            radioButton3.TabIndex = 3;
            radioButton3.TabStop = true;
            radioButton3.Text = "Fiat Egea\r\nKiralamak İstiyorum\r\n( Günlük Ücret : 899 TL)\r\n\r\n";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 162);
            radioButton4.Location = new Point(1104, 854);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(226, 79);
            radioButton4.TabIndex = 4;
            radioButton4.TabStop = true;
            radioButton4.Text = "Renualt Megane\r\nKiralamak İstiyorum\r\n( Günlük Ücret : 1699 TL)";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic);
            radioButton5.Location = new Point(1378, 854);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(226, 79);
            radioButton5.TabIndex = 5;
            radioButton5.TabStop = true;
            radioButton5.Text = "Ford Transit\r\nKiralamak İstiyorum\r\n( Günlük Ücret : 2149 TL)\r\n";
            radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            radioButton6.AutoSize = true;
            radioButton6.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic);
            radioButton6.Location = new Point(1635, 854);
            radioButton6.Name = "radioButton6";
            radioButton6.Size = new Size(216, 79);
            radioButton6.TabIndex = 6;
            radioButton6.TabStop = true;
            radioButton6.Text = "Fiat Combi\r\nKiralamak İstiyorum\r\n( Günlük Ücret : 849 TL)\r\n";
            radioButton6.UseVisualStyleBackColor = true;
            // 
            // btnKiralama
            // 
            btnKiralama.BackColor = Color.Teal;
            btnKiralama.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            btnKiralama.ForeColor = SystemColors.ControlLightLight;
            btnKiralama.Location = new Point(661, 807);
            btnKiralama.Name = "btnKiralama";
            btnKiralama.Size = new Size(357, 113);
            btnKiralama.TabIndex = 7;
            btnKiralama.Text = "Kirala";
            btnKiralama.UseVisualStyleBackColor = false;
            btnKiralama.Click += btnKiralama_Click;
            // 
            // txtAd
            // 
            txtAd.Font = new Font("Segoe UI", 12F);
            txtAd.Location = new Point(321, 188);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(191, 34);
            txtAd.TabIndex = 8;
            // 
            // txtSokak
            // 
            txtSokak.Font = new Font("Segoe UI", 12F);
            txtSokak.Location = new Point(321, 720);
            txtSokak.Name = "txtSokak";
            txtSokak.Size = new Size(191, 34);
            txtSokak.TabIndex = 9;
            // 
            // txtMahalle
            // 
            txtMahalle.Font = new Font("Segoe UI", 12F);
            txtMahalle.Location = new Point(321, 651);
            txtMahalle.Name = "txtMahalle";
            txtMahalle.Size = new Size(191, 34);
            txtMahalle.TabIndex = 10;
            // 
            // txtIlce
            // 
            txtIlce.Font = new Font("Segoe UI", 12F);
            txtIlce.Location = new Point(321, 579);
            txtIlce.Name = "txtIlce";
            txtIlce.Size = new Size(191, 34);
            txtIlce.TabIndex = 11;
            // 
            // txtSehir
            // 
            txtSehir.Font = new Font("Segoe UI", 12F);
            txtSehir.Location = new Point(321, 504);
            txtSehir.Name = "txtSehir";
            txtSehir.Size = new Size(191, 34);
            txtSehir.TabIndex = 12;
            // 
            // txtTelefon
            // 
            txtTelefon.Font = new Font("Segoe UI", 12F);
            txtTelefon.Location = new Point(321, 425);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(191, 34);
            txtTelefon.TabIndex = 13;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 12F);
            txtEmail.Location = new Point(321, 340);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(191, 34);
            txtEmail.TabIndex = 14;
            // 
            // txtSoyad
            // 
            txtSoyad.Font = new Font("Segoe UI", 12F);
            txtSoyad.Location = new Point(321, 262);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(191, 34);
            txtSoyad.TabIndex = 15;
            // 
            // txtAd1
            // 
            txtAd1.AutoSize = true;
            txtAd1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold);
            txtAd1.Location = new Point(230, 188);
            txtAd1.Name = "txtAd1";
            txtAd1.Size = new Size(60, 38);
            txtAd1.TabIndex = 18;
            txtAd1.Text = "Ad:";
            // 
            // txtSokak1
            // 
            txtSokak1.AutoSize = true;
            txtSokak1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold);
            txtSokak1.Location = new Point(188, 716);
            txtSokak1.Name = "txtSokak1";
            txtSokak1.Size = new Size(102, 38);
            txtSokak1.TabIndex = 19;
            txtSokak1.Text = "Sokak:";
            // 
            // txtMahalle1
            // 
            txtMahalle1.AutoSize = true;
            txtMahalle1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold);
            txtMahalle1.Location = new Point(167, 647);
            txtMahalle1.Name = "txtMahalle1";
            txtMahalle1.Size = new Size(125, 38);
            txtMahalle1.TabIndex = 20;
            txtMahalle1.Text = "Mahalle:";
            // 
            // txtIlce1
            // 
            txtIlce1.AutoSize = true;
            txtIlce1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold);
            txtIlce1.Location = new Point(223, 579);
            txtIlce1.Name = "txtIlce1";
            txtIlce1.Size = new Size(67, 38);
            txtIlce1.TabIndex = 21;
            txtIlce1.Text = "İlçe:";
            // 
            // txtSehir1
            // 
            txtSehir1.AutoSize = true;
            txtSehir1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold);
            txtSehir1.Location = new Point(202, 504);
            txtSehir1.Name = "txtSehir1";
            txtSehir1.Size = new Size(88, 38);
            txtSehir1.TabIndex = 22;
            txtSehir1.Text = "Şehir:";
            // 
            // txtTelefon1
            // 
            txtTelefon1.AutoSize = true;
            txtTelefon1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold);
            txtTelefon1.Location = new Point(174, 425);
            txtTelefon1.Name = "txtTelefon1";
            txtTelefon1.Size = new Size(116, 38);
            txtTelefon1.TabIndex = 23;
            txtTelefon1.Text = "Telefon:";
            // 
            // txtSoyad1
            // 
            txtSoyad1.AutoSize = true;
            txtSoyad1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold);
            txtSoyad1.Location = new Point(190, 258);
            txtSoyad1.Name = "txtSoyad1";
            txtSoyad1.Size = new Size(102, 38);
            txtSoyad1.TabIndex = 24;
            txtSoyad1.Text = "Soyad:";
            // 
            // txtEmail1
            // 
            txtEmail1.AutoSize = true;
            txtEmail1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold);
            txtEmail1.Location = new Point(197, 340);
            txtEmail1.Name = "txtEmail1";
            txtEmail1.Size = new Size(93, 38);
            txtEmail1.TabIndex = 25;
            txtEmail1.Text = "Email:";
            // 
            // txtKiralamaTarihi1
            // 
            txtKiralamaTarihi1.AutoSize = true;
            txtKiralamaTarihi1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            txtKiralamaTarihi1.Location = new Point(91, 845);
            txtKiralamaTarihi1.Name = "txtKiralamaTarihi1";
            txtKiralamaTarihi1.Size = new Size(210, 38);
            txtKiralamaTarihi1.TabIndex = 26;
            txtKiralamaTarihi1.Text = "Kiralama Tarihi:";
            // 
            // txtKiralamaBitisTarihi1
            // 
            txtKiralamaBitisTarihi1.AutoSize = true;
            txtKiralamaBitisTarihi1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            txtKiralamaBitisTarihi1.Location = new Point(30, 901);
            txtKiralamaBitisTarihi1.Name = "txtKiralamaBitisTarihi1";
            txtKiralamaBitisTarihi1.Size = new Size(271, 38);
            txtKiralamaBitisTarihi1.TabIndex = 27;
            txtKiralamaBitisTarihi1.Text = "Kiralama Bitiş Tarihi:";
            // 
            // txtPostaKodu1
            // 
            txtPostaKodu1.AutoSize = true;
            txtPostaKodu1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold);
            txtPostaKodu1.Location = new Point(122, 779);
            txtPostaKodu1.Name = "txtPostaKodu1";
            txtPostaKodu1.Size = new Size(168, 38);
            txtPostaKodu1.TabIndex = 31;
            txtPostaKodu1.Text = "Posta Kodu:";
            // 
            // txtPostaKodu
            // 
            txtPostaKodu.Font = new Font("Segoe UI", 12F);
            txtPostaKodu.Location = new Point(321, 783);
            txtPostaKodu.Name = "txtPostaKodu";
            txtPostaKodu.Size = new Size(191, 34);
            txtPostaKodu.TabIndex = 30;
            // 
            // dateTimePickerKiralamaTarihi
            // 
            dateTimePickerKiralamaTarihi.CalendarFont = new Font("Segoe UI", 18F);
            dateTimePickerKiralamaTarihi.Location = new Point(321, 854);
            dateTimePickerKiralamaTarihi.Name = "dateTimePickerKiralamaTarihi";
            dateTimePickerKiralamaTarihi.Size = new Size(250, 27);
            dateTimePickerKiralamaTarihi.TabIndex = 32;
            // 
            // dateTimePickerKiralamaBitisTarihi
            // 
            dateTimePickerKiralamaBitisTarihi.CalendarFont = new Font("Segoe UI", 18F);
            dateTimePickerKiralamaBitisTarihi.Location = new Point(321, 912);
            dateTimePickerKiralamaBitisTarihi.Name = "dateTimePickerKiralamaBitisTarihi";
            dateTimePickerKiralamaBitisTarihi.Size = new Size(250, 27);
            dateTimePickerKiralamaBitisTarihi.TabIndex = 33;
            // 
            // yoneticiBtn
            // 
            yoneticiBtn.BackColor = SystemColors.ScrollBar;
            yoneticiBtn.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            yoneticiBtn.Location = new Point(830, 57);
            yoneticiBtn.Name = "yoneticiBtn";
            yoneticiBtn.Size = new Size(188, 63);
            yoneticiBtn.TabIndex = 34;
            yoneticiBtn.Text = "Yönetici Panel";
            yoneticiBtn.UseVisualStyleBackColor = false;
            yoneticiBtn.Click += yoneticiBtn_Click;
            // 
            // MusteriGiris
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1872, 966);
            Controls.Add(yoneticiBtn);
            Controls.Add(dateTimePickerKiralamaBitisTarihi);
            Controls.Add(dateTimePickerKiralamaTarihi);
            Controls.Add(txtPostaKodu1);
            Controls.Add(txtPostaKodu);
            Controls.Add(txtKiralamaBitisTarihi1);
            Controls.Add(txtKiralamaTarihi1);
            Controls.Add(txtEmail1);
            Controls.Add(txtSoyad1);
            Controls.Add(txtTelefon1);
            Controls.Add(txtSehir1);
            Controls.Add(txtIlce1);
            Controls.Add(txtMahalle1);
            Controls.Add(txtSokak1);
            Controls.Add(txtAd1);
            Controls.Add(txtSoyad);
            Controls.Add(txtEmail);
            Controls.Add(txtTelefon);
            Controls.Add(txtSehir);
            Controls.Add(txtIlce);
            Controls.Add(txtMahalle);
            Controls.Add(txtSokak);
            Controls.Add(txtAd);
            Controls.Add(btnKiralama);
            Controls.Add(radioButton6);
            Controls.Add(radioButton5);
            Controls.Add(radioButton4);
            Controls.Add(radioButton3);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(label1);
            Name = "MusteriGiris";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Musteri";
            WindowState = FormWindowState.Maximized;
            Load += MusteriGiris_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private RadioButton radioButton5;
        private RadioButton radioButton6;
        private Button btnKiralama;
        private TextBox txtAd;
        private TextBox txtSokak;
        private TextBox txtMahalle;
        private TextBox txtIlce;
        private TextBox txtSehir;
        private TextBox txtTelefon;
        private TextBox txtEmail;
        private TextBox txtSoyad;
        private Label txtAd1;
        private Label txtSokak1;
        private Label txtMahalle1;
        private Label txtIlce1;
        private Label txtSehir1;
        private Label txtTelefon1;
        private Label txtSoyad1;
        private Label txtEmail1;
        private Label txtKiralamaTarihi1;
        private Label txtKiralamaBitisTarihi1;
        private Label txtPostaKodu1;
        private TextBox txtPostaKodu;
        private DateTimePicker dateTimePickerKiralamaTarihi;
        private DateTimePicker dateTimePickerKiralamaBitisTarihi;
        private Button yoneticiBtn;
    }
}