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
    public partial class Form2 :Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addpaatient pt = new addpaatient();
            this.Hide();
            pt.ShowDialog();
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            adddoc dc = new adddoc();
            this.Hide();
            dc.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            today_pat td = new today_pat();
            this.Hide();
            td.ShowDialog();
            this.Close();
          

        }

      

        private void button4_Click(object sender, EventArgs e)
        {
            emp emm = new emp();
            this.Hide();
            emm.ShowDialog();
            this.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            adddept add = new adddept();
            this.Hide();
            add.ShowDialog();
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            deactivatedoctor de = new deactivatedoctor();
            this.Hide();
            de.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

    

        private void button8_Click(object sender, EventArgs e)
        {
            allemp all = new allemp();
            this.Hide();
            all.ShowDialog();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
