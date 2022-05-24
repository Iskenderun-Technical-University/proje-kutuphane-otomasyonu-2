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
    public partial class uyeEdit : Form
    {

        private SqlConnection con = new SqlConnection("Data Source=DESKTOP-VV7AEEN\\SQLEXPRESS;Initial Catalog=KutuphaneOtomasyon;Integrated Security=True");
        SqlDataReader dr;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;


        public uyeEdit()
        {
            InitializeComponent();
        }

        private void uyeEdit_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kutuphaneOtomasyonDataSet.Uyeler' table. You can move, or remove it, as needed.
            this.uyelerTableAdapter.Fill(this.kutuphaneOtomasyonDataSet.Uyeler);

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        void Yenile()
        {

            da = new SqlDataAdapter("Select *From Uyeler", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "ogrenci");
            bunifuCustomDataGrid1.DataSource = ds.Tables["Uyeler"];
            con.Close();
        }


        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable tablo = new DataTable();
            bunifuMaterialTextbox1.Text = bunifuCustomDataGrid1.CurrentRow.Cells[1].Value.ToString();
            bunifuMaterialTextbox2.Text = bunifuCustomDataGrid1.CurrentRow.Cells[2].Value.ToString();
            bunifuMaterialTextbox3.Text = bunifuCustomDataGrid1.CurrentRow.Cells[3].Value.ToString();
            bunifuDatepicker1.Text = bunifuCustomDataGrid1.CurrentRow.Cells[4].Value.ToString();
            bunifuMaterialTextbox4.Text = bunifuCustomDataGrid1.CurrentRow.Cells[5].Value.ToString();
            bunifuMaterialTextbox5.Text = bunifuCustomDataGrid1.CurrentRow.Cells[6].Value.ToString();
           


        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Update Uyeler set Uye_ad=@Uye_ad, Uye_soyad=@Uye_soyad, email=@email, tel_no=@tel_no where UyeId=@UyeId";
                cmd.Parameters.AddWithValue("@Uye_ad", bunifuMaterialTextbox1.Text);
                cmd.Parameters.AddWithValue("@Uye_soyad", bunifuMaterialTextbox2.Text);
                cmd.Parameters.AddWithValue("@email", bunifuMaterialTextbox3.Text);
                cmd.Parameters.AddWithValue("@tel_no", bunifuMaterialTextbox5.Text);


                cmd.ExecuteNonQuery();
                con.Close();
                Yenile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Delete * from Uyeler where UyeId=@UyeId";
                cmd.ExecuteNonQuery();
                con.Close();
                Yenile();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
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
                    cmd.Parameters.AddWithValue("@sifre", MD5.MD5Sifrele(bunifuMaterialTextbox6.Text));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Tebrikler başarıyla kayıt yapildi."); 
                    Yenile();
                   

                }
                else
                    MessageBox.Show("Lütfen girmiş olduğunuz bilgilerin uzunluğunu veya Doğum tarihinizi kontrol ediniz.");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Hide();
            new StaffAnaSayfa().Show();
        }
    }
}
