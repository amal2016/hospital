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
    public partial class master : Form
    {
        public master()
        {
            InitializeComponent();
        }

       

        private void master_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            
            label3.Text = dt.ToString();


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       

      
    }
}
