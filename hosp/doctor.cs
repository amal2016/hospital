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
    public partial class doctor : Form
    {
        public static int x;
        public string _textBox
        {
            set { label6.Text = value; }
        }
        public doctor()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbname.Text = login.ss.ToString();
            DateTime dt = new DateTime();
            label3.Text = dt.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            x = int.Parse(label6.Text);
            changepass ch = new changepass();
            this.Hide();
            ch.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dailyreport df = new dailyreport();
            this.Hide();
            df.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_dignose ad = new add_dignose();
            ad.ShowDialog();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

       

       
    }
}
