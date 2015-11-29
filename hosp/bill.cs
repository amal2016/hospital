using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Types;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
namespace hosp
{
    public partial class bill : Form
    {
        static string stringcon = ConfigurationManager.ConnectionStrings["mystring"].ConnectionString;
        OracleConnection conn = new OracleConnection(stringcon);
        public bill()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsPunctuation(e.KeyChar) ||
                  Char.IsSeparator(e.KeyChar) ||
                  Char.IsLetter(e.KeyChar);
        }

        private void bill_Load(object sender, EventArgs e)
        {
            lbdate.Text = DateTime.Now.ToString();
            OracleCommand patcmd= new OracleCommand("select PID from PATIENT", conn);
            DataTable dt = new DataTable();
            conn.Open();
            OracleDataReader dr = patcmd.ExecuteReader();
            dt.Load(dr);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "PID";
            comboBox1.ValueMember = "PID";
              OracleCommand deptcommand = new OracleCommand("select deptid,deptname from department", conn);
            DataTable dt2 = new DataTable();
            OracleDataReader dr2 = deptcommand.ExecuteReader();
            dt2.Load(dr2);

            comboBox2.DataSource = dt2;
            comboBox2.DisplayMember = "deptname";
            comboBox2.ValueMember = "deptid";
            conn.Close();
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string insrtpatnt = "insert into bill(billno,patientid,deptid,amount,addedby) values(billno.nextval,:id,:pd,:am,:ad)";
            OracleCommand orcmd = new OracleCommand(insrtpatnt, conn);
            orcmd.Parameters.Add("id", OracleDbType.Int16).Value =int.Parse(comboBox1.SelectedValue.ToString());
            orcmd.Parameters.Add("pd", OracleDbType.Int16).Value = int.Parse(comboBox2.SelectedValue.ToString());
            orcmd.Parameters.Add("am", OracleDbType.Int16).Value = int.Parse(textBox1.Text);
            orcmd.Parameters.Add("ad", OracleDbType.NVarchar2).Value = login.id.ToString();
            try
            {
                conn.Open();
                orcmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("bill added");
            }
            catch
            {
                MessageBox.Show("error happen try again");
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            acc ac = new acc();
            this.Hide();
            ac.ShowDialog();
            this.Close();
        }
    }
}
