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

        }
    }
}
