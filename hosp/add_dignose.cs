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
    public partial class add_dignose : Form
    {
        static string stringcon = ConfigurationManager.ConnectionStrings["mystring"].ConnectionString;
        OracleConnection conn = new OracleConnection(stringcon);
        public add_dignose()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            string insrtdig = "insert into Dignostic(patientid,remark,notes,drid,digid)values(:pid,:rm,:nt,:drid,id.nextval)";
            OracleCommand insrtdigcommand = new OracleCommand(insrtdig, conn);
            insrtdigcommand.Parameters.Add("pid", OracleDbType.Int16).Value = int.Parse(comboBox1.SelectedValue.ToString());
            insrtdigcommand.Parameters.Add("rm", OracleDbType.Varchar2).Value = txtdignose.Text;
            insrtdigcommand.Parameters.Add("nt", OracleDbType.Varchar2).Value = txtnotes.Text;
            insrtdigcommand.Parameters.Add("drid", OracleDbType.Int16).Value = int.Parse(login.id);
            try
            {
                insrtdigcommand.ExecuteNonQuery();
                MessageBox.Show("added");
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Error Happens Check data and try again");
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


        private void button3_Click(object sender, EventArgs e)
        {
            doctor dc = new doctor();
            this.Hide();
            dc.ShowDialog();
            this.Close();
        }

        private void add_dignose_Load(object sender, EventArgs e)
        {
            OracleCommand patcmd = new OracleCommand("select PID from PATIENT", conn);
            DataTable dt = new DataTable();
            conn.Open();
            OracleDataReader dr = patcmd.ExecuteReader();
            dt.Load(dr);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "PID";
            comboBox1.ValueMember = "PID";
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearAllText(this);
        }
    }
}
