using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Bunifu.Framework.Lib;

namespace KutuphaneOtomasyon1
{
    public partial class Form1 : Form
    {
        private SqlConnection con = new SqlConnection("Data Source=DESKTOP-VV7AEEN\\SQLEXPRESS;Initial Catalog=KutuphaneOtomasyon;Integrated Security=True");
        private SqlCommand cmd;
        private SqlDataReader reader;


        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            string text1 = ((Control)this.bunifuMaterialTextbox1).Text;
            string text2 = ((Control)this.bunifuMaterialTextbox2).Text;
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = this.con;
            cmd.CommandText = "SELECT * FROM Uyeler where email='" + bunifuMaterialTextbox1.Text + "' AND sifre='" + bunifuMaterialTextbox2.Text + "'";
            reader = this.cmd.ExecuteReader();
            if (reader.Read())
            {
                new KullanıcıAnasayfa().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı ya da şifre yanlış");
            }
            this.con.Close();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            string text1 = bunifuMaterialTextbox1.Text;
            string text2 = bunifuMaterialTextbox2.Text;
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = this.con;
            cmd.CommandText = "SELECT * FROM Personel where email='" + bunifuMaterialTextbox1.Text + "' AND sifre='" + bunifuMaterialTextbox1.Text + "'"; 
            reader = this.cmd.ExecuteReader();
            if (this.reader.Read())
            {
                new StaffAnaSayfa().Show();
                this.Hide();
            }
            else
            {
                int num = (int)MessageBox.Show("Kullanıcı adı ya da şifre yanlış");
            }
            this.con.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new SifremıUnuttumcs().Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new UyeKayit().Show();
            this.Hide();
        }
    }
}
