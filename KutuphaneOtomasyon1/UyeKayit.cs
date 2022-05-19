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
                if (bunifuMaterialTextbox6.Text.Length > 6 && bunifuMaterialTextbox4.Text.Length == 11 && bunifuDatepicker1.Value.Year >= 01 / 01 / 2001 && bunifuMaterialTextbox5.Text.Length == 10)

                {
                    con = new SqlConnection("Data Source=DESKTOP-VV7AEEN\\SQLEXPRESS;Initial Catalog=KutuphaneOtomasyon;Integrated Security=True");
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into Uyeler (Uye_ad,Uye_soyad,email,Dogum_trh,tc_no,tel_no,sifre) values (@Uye_ad, @Uye_soyad, @email, @Dogum_trh, @tc_no, @tel_no, @sifre)";
                    cmd.Parameters.AddWithValue("@Uye_ad", bunifuMaterialTextbox1.Text);
                    cmd.Parameters.AddWithValue("@Uye_soyad", bunifuMaterialTextbox2.Text);
                    cmd.Parameters.AddWithValue("@email", bunifuMaterialTextbox3.Text);
                    cmd.Parameters.AddWithValue("@Dogum_trh", bunifuDatepicker1.Value);
                    cmd.Parameters.AddWithValue("@tc_no", bunifuMaterialTextbox4.Text);
                    cmd.Parameters.AddWithValue("@tel_no", bunifuMaterialTextbox5.Text);
                    cmd.Parameters.AddWithValue("@sifre", bunifuMaterialTextbox6.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Tebrikler başarıyla kayıt oldunuz.");
                    
                }
                else
                    MessageBox.Show("Lütfen girmiş olduğunuz bilgilerin uzunluğunu veya Doğum tarihinizi kontrol ediniz.");
                
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
