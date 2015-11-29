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
    public partial class emp : Form
    {
        static string stringcon = ConfigurationManager.ConnectionStrings["mystring"].ConnectionString;
        OracleConnection conn = new OracleConnection(stringcon);
        public emp()
        {
            InitializeComponent();
        }
        private void load_date()
        {
            int yyr = 0;

            int yer = Convert.ToInt32(DateTime.Now.Year.ToString());
            for (int x = 1; x < 90; x++)
            {
                yyr = yer - x;
                cyear.Items.Add(yyr.ToString());
            }
            for (int z = 1; z < 12; z++)
            {
                cmonth.Items.Add(z.ToString());
            }

        }
        private void emp_Load(object sender, EventArgs e)
        {
            load_date();
            conn.Open();
            OracleCommand deptcommand = new OracleCommand("select deptid,deptname from department", conn);
            DataTable dt = new DataTable();
            OracleDataReader dr = deptcommand.ExecuteReader();
            dt.Load(dr);

            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "deptname";
            comboBox2.ValueMember = "deptid";
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //generate password
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            string str;
            if (rmale.Checked)
            {
                str = "male";
            }
            else
            {
                str = "female";
            }
            string ss = cmonth.Text + "/" + cday.Text + "/" + cyear.Text;
            DateTime sx = DateTime.Parse(ss);


            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = "emp_insrt";
            cmd.Parameters.Add("d", OracleDbType.Int32).Value = Convert.ToInt32(IDTXT.Text);
            cmd.Parameters.Add("fn", OracleDbType.Varchar2).Value = FNAMETXT.Text;
            cmd.Parameters.Add("lm", OracleDbType.Varchar2).Value = LNAMETXT.Text;
            cmd.Parameters.Add("db", OracleDbType.Date).Value = sx;
            cmd.Parameters.Add("sd", OracleDbType.Varchar2).Value = ADDTXT.Text;
            cmd.Parameters.Add("sm", OracleDbType.Varchar2).Value = MOBTXT.Text;
            cmd.Parameters.Add("dbt", OracleDbType.Int32).Value= Convert.ToInt32(comboBox2.SelectedValue);
            cmd.Parameters.Add("jd", OracleDbType.Date).Value = jdate.Value;
            cmd.Parameters.Add("pass", OracleDbType.Varchar2).Value = finalString;
            cmd.Parameters.Add("em", OracleDbType.Varchar2).Value = emailtxt.Text;
            cmd.Parameters.Add("gnd", OracleDbType.Varchar2).Value = str;
            cmd.Parameters.Add("rol", OracleDbType.Varchar2).Value = combrole.ValueMember;
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

        private void cmonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            cday.Items.Clear();
            if (cmonth.Text == "2") //feb month
            {

                for (int i = 1; i < 30; i++)
                {
                    cday.Items.Add(i.ToString());
                }
            }
            else
            {

                for (int i = 1; i < 32; i++)
                {
                    cday.Items.Add(i.ToString());
                }
            }
        }

        private void IDTXT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsPunctuation(e.KeyChar) ||
                     Char.IsSeparator(e.KeyChar) ||
                     Char.IsLetter(e.KeyChar);
        }

        private void FNAMETXT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsPunctuation(e.KeyChar) ||
                      Char.IsSeparator(e.KeyChar) ||
                      Char.IsNumber(e.KeyChar);

        }

        private void LNAMETXT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsPunctuation(e.KeyChar) ||
                   Char.IsSeparator(e.KeyChar) ||
                   Char.IsNumber(e.KeyChar);
        }

        private void MOBTXT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsPunctuation(e.KeyChar) ||
                   Char.IsSeparator(e.KeyChar) ||
                   Char.IsNumber(e.KeyChar);
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
        private void button2_Click(object sender, EventArgs e)
        {
            ClearAllText(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 fh = new Form2();
            this.Hide();
            fh.ShowDialog();
            this.Close();
        }

        
    }
}
