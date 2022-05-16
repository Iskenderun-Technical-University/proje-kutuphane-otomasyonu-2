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


namespace KutuphaneOtomasyon1
{
    public partial class UyeKayit : Form
    {
        private SqlConnection con = new SqlConnection("Data Source=DESKTOP-VV7AEEN\\SQLEXPRESS;Initial Catalog=KutuphaneOtomasyon;Integrated Security=True");
        private SqlCommand cmd;
        private SqlDataReader reader;
        public UyeKayit()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection("Data Source=DESKTOP-VV7AEEN\\SQLEXPRESS;Initial Catalog=KutuphaneOtomasyon;Integrated Security=True");
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into Uyeler (Uye_ad,Uye_soyad,email,Dogum_trh,tc_no,tel_no,sifre) values (@Uye_ad, @Uye_soyad, @email, @Dogum_trh, @tc_no, @tel_no, @sifre)";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Tebrikler başarıyla kayıt oldunuz.");
                this.Close();
                new Form1().Show();
                
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
