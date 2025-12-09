using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Rental_Dbms_Project
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = textBox1.Text;
            string sifre = textBox2.Text;

    
            if (kullaniciAdi == "admin" && sifre == "123")
            {
          
                yonetici personelForm = new yonetici();
                personelForm.Show();
                this.Hide();
            }
            else
            {
                label4.Text = "Kullanıcı adı veya şifre yanlış!";
                label4.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
