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
    public partial class KullaniciBilgi : Form
    {
        private SqlConnection con = new SqlConnection("Data Source=DESKTOP-VV7AEEN\\SQLEXPRESS;Initial Catalog=KutuphaneOtomasyon;Integrated Security=True");
        SqlDataReader dr;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;


        public KullaniciBilgi()
        {
            InitializeComponent();
        }

        private void KullaniciBilgi_Load(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = this.con;
          

        }
    }
}
