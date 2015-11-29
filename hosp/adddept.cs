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
    public partial class adddept : Form
    {
        static string stringcon = ConfigurationManager.ConnectionStrings["mystring"].ConnectionString;
        OracleConnection conn = new OracleConnection(stringcon);
        public adddept()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = "dept_insrt";
         
            cmd.Parameters.Add("ns", OracleDbType.Varchar2).Value = textBox2.Text;
            cmd.Parameters.Add("des", OracleDbType.Varchar2).Value = textBox3.Text;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("ok added");
            }
            catch
            {
                MessageBox.Show("error happen!!");
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsPunctuation(e.KeyChar) ||
                   Char.IsSeparator(e.KeyChar) ||
                   Char.IsLetter(e.KeyChar);
        }

        void ClearAllText(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
                else
                    ClearAllText(c);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ClearAllText(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 ff = new Form2();
            this.Hide();
            ff.ShowDialog();
            ff.Close();
          
        }
    }
}
