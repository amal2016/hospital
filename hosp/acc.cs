using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hosp
{
    public partial class acc : Form
    {
        public acc()
        {
            InitializeComponent();
        }

        private void acc_Load(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bill bl = new bill();
            this.Hide();
            bl.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            allbillacc all = new allbillacc();
            this.Hide();
            all.ShowDialog();
            this.Close();
        }
    }
}
