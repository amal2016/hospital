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
    public partial class addpaatient : Form
    {
        static string stringcon = ConfigurationManager.ConnectionStrings["mystring"].ConnectionString;
        OracleConnection conn = new OracleConnection(stringcon);
        public addpaatient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ss = cmonth.Text + "/" + cday.Text + "/" + cyear.Text;
            DateTime sx = DateTime.Parse(ss);

            string gender = "";
            if (radioButton1.Checked)
            {
                gender = "male";
            }
            else
            {
                gender = "female";
            }

            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = "pat_insrt";
            cmd.Parameters.Add("id", OracleDbType.Int64).Value = Convert.ToInt64(textBox1.Text);
            cmd.Parameters.Add("fn", OracleDbType.Varchar2).Value = textBox2.Text;
            cmd.Parameters.Add("na", OracleDbType.Varchar2).Value = textBox3.Text;
            cmd.Parameters.Add("gn", OracleDbType.Varchar2).Value = gender;
            cmd.Parameters.Add("ad", OracleDbType.Varchar2).Value = textBox5.Text;
            cmd.Parameters.Add("mob", OracleDbType.Varchar2).Value = textBox6.Text;
            cmd.Parameters.Add("db", OracleDbType.Date).Value = sx;
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
        private void addpaatient_Load(object sender, EventArgs e)
        {
            load_date();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsPunctuation(e.KeyChar) ||
                     Char.IsSeparator(e.KeyChar) ||
                     Char.IsLetter(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsPunctuation(e.KeyChar) ||
                     Char.IsSeparator(e.KeyChar) ||
                     Char.IsNumber(e.KeyChar);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsPunctuation(e.KeyChar) ||
                     Char.IsSeparator(e.KeyChar) ||
                     Char.IsNumber(e.KeyChar);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsPunctuation(e.KeyChar) ||
                     Char.IsSeparator(e.KeyChar) ||
                     Char.IsLetter(e.KeyChar);
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

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            this.Hide();
            f.ShowDialog();
            f.Close();
           

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

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
