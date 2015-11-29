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
    public partial class deactivatedoctor : Form
    {
        static string stringcon = ConfigurationManager.ConnectionStrings["mystring"].ConnectionString;
        OracleConnection conn = new OracleConnection(stringcon);
        public deactivatedoctor()
        {
            InitializeComponent();
        }

        private void deactivatedoctor_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsPunctuation(e.KeyChar) ||
                 Char.IsSeparator(e.KeyChar) ||
                 Char.IsLetter(e.KeyChar);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string deactiv = "update doctor set status='unactive' where docid=:id ";
            OracleCommand cmd = new OracleCommand(deactiv, conn);
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

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 fg = new Form2();
            this.Hide();
            fg.ShowDialog();
            this.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}