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


    public partial class KitapEdit : Form
    {
        private SqlConnection con = new SqlConnection("Data Source=DESKTOP-VV7AEEN\\SQLEXPRESS;Initial Catalog=KutuphaneOtomasyon;Integrated Security=True");
        SqlDataReader dr;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;


        public KitapEdit()
        {
            InitializeComponent();
        }

        void Yenile()
        {

            da = new SqlDataAdapter("Select *From Kitaplar", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Kitaplar");
            bunifuCustomDataGrid1.DataSource = ds.Tables["Kitaplar"];
            con.Close();
        }


        private void KitapEdit_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kutuphaneOtomasyonDataSet1.Kitaplar' table. You can move, or remove it, as needed.
            this.kitaplarTableAdapter.Fill(this.kutuphaneOtomasyonDataSet1.Kitaplar);

        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable tablo = new DataTable();
            bunifuMaterialTextbox1.Text = bunifuCustomDataGrid1.CurrentRow.Cells[1].Value.ToString();
            bunifuMaterialTextbox2.Text = bunifuCustomDataGrid1.CurrentRow.Cells[2].Value.ToString();
            bunifuDatepicker1.Text = bunifuCustomDataGrid1.CurrentRow.Cells[4].Value.ToString();
            bunifuMaterialTextbox4.Text = bunifuCustomDataGrid1.CurrentRow.Cells[5].Value.ToString();
            bunifuMaterialTextbox5.Text = bunifuCustomDataGrid1.CurrentRow.Cells[6].Value.ToString();
            richTextBox1.Text = bunifuCustomDataGrid1.CurrentRow.Cells[7].Value.ToString();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Update Kitaplar set kitapAD=@kitapAD, kitapYazar=@kitapYazar, kitapBaskiYil=@kitapBaskiYil, SayfaSayi=@SayfaSayi, kitapDil=@kitapDil , yayinEvi=@yayinEvi, kitapAciklama=@kitapAciklama where UyeId=@UyeId";
                cmd.Parameters.AddWithValue("@kitapAD", bunifuMaterialTextbox1.Text);
                cmd.Parameters.AddWithValue("@kitapYazar", bunifuMaterialTextbox2.Text);
                cmd.Parameters.AddWithValue("@kitapBaskiYil", bunifuDatepicker1.Value.ToString());
                cmd.Parameters.AddWithValue("@SayfaSayi", bunifuMaterialTextbox4.Text);
                cmd.Parameters.AddWithValue("@kitapDil", bunifuMaterialTextbox5.Text);
                cmd.Parameters.AddWithValue("@yayinEvi", bunifuMaterialTextbox7.Text);
                cmd.Parameters.AddWithValue("@kitapAciklama", richTextBox1.Text);


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
                cmd.CommandText = "Delete * from Kitaplar where kitapID=@kitapID";
                cmd.ExecuteNonQuery();
                con.Close();
                Yenile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into  Kitaplar (kitapAD,kitapYazar,kitapBaskiYil,SayfaSayi,kitapDil,yayinEvi,@kitapAciklama) values (@kitapAD,@kitapYazar,@kitapBaskiYil,@SayfaSayi,@kitapDil,@yayinEvi,@kitapAciklama)";
                cmd.Parameters.AddWithValue("@kitapAD", bunifuMaterialTextbox1.Text);
                cmd.Parameters.AddWithValue("@kitapYazar", bunifuMaterialTextbox2.Text);
                cmd.Parameters.AddWithValue("@kitapBaskiYil", bunifuDatepicker1.Value.ToString());
                cmd.Parameters.AddWithValue("@SayfaSayi", bunifuMaterialTextbox4.Text);
                cmd.Parameters.AddWithValue("@kitapDil", bunifuMaterialTextbox5.Text);
                cmd.Parameters.AddWithValue("@yayinEvi", bunifuMaterialTextbox7.Text);
                cmd.Parameters.AddWithValue("@kitapAciklama", richTextBox1.Text);


                cmd.ExecuteNonQuery();
                con.Close();
                Yenile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
