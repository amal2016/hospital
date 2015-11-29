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
    public partial class changepass : Form
    {
        static string stringcon = ConfigurationManager.ConnectionStrings["mystring"].ConnectionString;
        OracleConnection conn = new OracleConnection(stringcon);
        public changepass()
        {
            InitializeComponent();
        }

        private void changepass_Load(object sender, EventArgs e)
        {
            label1.Text = doctor.x.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == textBox2.Text)
            {
                string str = "update doctor set password=:pass where docid=:id";
                OracleCommand cmd = new OracleCommand(str, conn);
                cmd.Parameters.Add("pass", OracleDbType.NVarchar2).Value = textBox1.Text;
                cmd.Parameters.Add("id", OracleDbType.Int16).Value = int.Parse(label1.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("updated");
                conn.Close();
                doctor f1 = new doctor();
                this.Hide();
                f1.ShowDialog();
                this.Close();

            }
            else
            {
                MessageBox.Show("you must enter the same password!!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            doctor dc = new doctor();
            this.Hide();
            dc.ShowDialog();
            this.Close();
        }
    }
}
