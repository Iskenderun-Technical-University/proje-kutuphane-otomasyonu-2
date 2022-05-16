using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneOtomasyon1
{
    public partial class uyeEdit : Form
    {
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
    }
}
