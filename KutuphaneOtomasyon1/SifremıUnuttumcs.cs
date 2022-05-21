using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Data.SqlClient;


namespace KutuphaneOtomasyon1
{

   
    public partial class SifremıUnuttumcs : Form
    {
        private SqlConnection con = new SqlConnection("Data Source=DESKTOP-VV7AEEN\\SQLEXPRESS;Initial Catalog=KutuphaneOtomasyon;Integrated Security=True");
        private const int V = 90;
        private const int v = V;
        private SqlCommand cmd;
        private SqlDataReader reader;


        public SifremıUnuttumcs()
        {
            InitializeComponent();
        }
        public bool MailGonder(string konu, string icerik)
        {
            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("837842@unizar.es");
            ePosta.To.Add(bunifuMaterialTextbox1.Text); //göndereceğimiz mail adresi

            ePosta.Subject = konu; //mail konusu
            ePosta.Body = icerik; //mail içeriği 

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("837842@unizar.es", "014500km");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Send(ePosta);
            object userState = true;
            bool kontrol = true;
            try
            {
                client.SendAsync(ePosta, (object)ePosta);
            }
            catch (SmtpException ex)
            {
                kontrol = false;
                MessageBox.Show(ex.Message);
            }
            return kontrol;
        }


        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            string sifre;
            try
            {
                SqlConnection baglanti = new SqlConnection("Data Source = DESKTOP-VV7AEEN\\SQLEXPRESS; Initial Catalog = KutuphaneOtomasyon; Integrated Security = True");
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                SqlCommand komut = new SqlCommand("select * from Uyeler where email='" + bunifuMaterialTextbox1.Text + "'");
                komut.Connection = baglanti;
                SqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    sifre = oku["sifre"].ToString();

                    label2.Visible = true;
                    label2.ForeColor = Color.Green;
                    label2.Text = "Girmiş Olduğunuz Bilgiler Uyuşuyor Şifreniz Mail Olarak Gönderildi";

                    bunifuProgressBar1.Visible = true;
                    bunifuProgressBar1.MaximumValue = 900000;
                    

                    for (int j = V; j < 900000; j++)
                    {
                        bunifuProgressBar1.Value = j;
                    }

                    MailGonder("ŞİFRE HATIRLATMA", "Şifreniz: " + sifre);
                    baglanti.Close();
                }
                else
                {
                    label2.Visible = true;
                    label2.ForeColor = Color.Red;
                    label2.Text = "Girmiş Olduğunuz Bilgiler Uyuşmuyor";
                }
            }
            catch (Exception ex)
            {
                label2.Visible = true;
                label2.ForeColor = Color.Red;
                label2.Text = "Mail Gönderme Hatası";
                MessageBox.Show(ex.Message);
            }

        }
    }
}
