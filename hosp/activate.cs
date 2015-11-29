using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
namespace hosp
{
    public partial class activate : Form
    {
        static string stringcon = ConfigurationManager.ConnectionStrings["mystring"].ConnectionString;
        OracleConnection conn = new OracleConnection(stringcon);
        public activate()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string activ = "update doctor set status='active' where docid=:id ";
            OracleCommand cmd = new OracleCommand(activ, conn);
            cmd.Parameters.Add("id", OracleDbType.Int16).Value = int.Parse(textBox1.Text);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("updated");
            }
            catch
            {

                MessageBox.Show("no update try again");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsPunctuation(e.KeyChar) ||
                Char.IsSeparator(e.KeyChar) ||
                Char.IsLetter(e.KeyChar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            this.Hide();
           frm.ShowDialog();
            this.Close();
        }

        private void activate_Load(object sender, EventArgs e)
        {

        }
    }
}
