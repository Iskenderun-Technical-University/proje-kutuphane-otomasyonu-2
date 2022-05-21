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
    public partial class UyeKitap : Form
    {
        private SqlConnection con = new SqlConnection("Data Source=DESKTOP-VV7AEEN\\SQLEXPRESS;Initial Catalog=KutuphaneOtomasyon;Integrated Security=True");
        SqlDataReader dr;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        public UyeKitap()
        {
            InitializeComponent();
        }


      
        private void UyeKitap_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kutuphaneOtomasyonDataSet1.Kitaplar' table. You can move, or remove it, as needed.
            this.kitaplarTableAdapter.Fill(this.kutuphaneOtomasyonDataSet1.Kitaplar);

        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable tablo = new DataTable();
            bunifuMaterialTextbox1.Text = bunifuCustomDataGrid1.CurrentRow.Cells[1].Value.ToString();
            bunifuMaterialTextbox2.Text = bunifuCustomDataGrid1.CurrentRow.Cells[2].Value.ToString();
            bunifuMaterialTextbox3.Text = bunifuCustomDataGrid1.CurrentRow.Cells[4].Value.ToString();
            bunifuMaterialTextbox4.Text = bunifuCustomDataGrid1.CurrentRow.Cells[5].Value.ToString();
            bunifuMaterialTextbox5.Text = bunifuCustomDataGrid1.CurrentRow.Cells[6].Value.ToString();
            richTextBox1.Text = bunifuCustomDataGrid1.CurrentRow.Cells[7].Value.ToString();



        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            new KullanıcıAnasayfa().Show();
            this.Hide();
        }
    }
}
