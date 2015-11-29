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
using System.Text.RegularExpressions;
using System.Configuration;
namespace hosp
{
    public partial class adddoc : Form
    {
        string location;
        static string stringcon = ConfigurationManager.ConnectionStrings["mystring"].ConnectionString;
        OracleConnection conn = new OracleConnection(stringcon);
        public adddoc()
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
        private void adddoc_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
           
          
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
                    Char.IsLetter(e.KeyChar);
        }

        private void button1_Click_1(object sender, EventArgs e)
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
            cmd.CommandText = "doc_insrt";
            cmd.Parameters.Add("df", OracleDbType.Varchar2).Value = FNAMETXT.Text;
            cmd.Parameters.Add("dl", OracleDbType.Varchar2).Value = LNAMETXT.Text;
            cmd.Parameters.Add("gn", OracleDbType.Varchar2).Value = str;
            cmd.Parameters.Add("ad", OracleDbType.Varchar2).Value = ADDTXT.Text;
            cmd.Parameters.Add("did", OracleDbType.Int32).Value = Convert.ToInt32(comboBox2.SelectedValue.ToString());
            cmd.Parameters.Add("mob", OracleDbType.Varchar2).Value = MOBTXT.Text;
            cmd.Parameters.Add("dg", OracleDbType.Varchar2).Value = comboBox1.Text;
            cmd.Parameters.Add("dgd", OracleDbType.Date).Value = dgdate.Value;
            cmd.Parameters.Add("jd", OracleDbType.Date).Value = jdate.Value;
            cmd.Parameters.Add("pass", OracleDbType.Varchar2).Value = finalString.ToString();
            cmd.Parameters.Add("id", OracleDbType.Int32).Value = Convert.ToInt32(IDTXT.Text);
            cmd.Parameters.Add("dob", OracleDbType.Date).Value = sx;
            cmd.Parameters.Add("ml", OracleDbType.Varchar2).Value = emailtxt.Text;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("ok added");
                //  MessageBox.Show("his password is" + finalString);
            }
            catch
            {
                MessageBox.Show("error happen!!");
            }
            //send password to doctor via mail

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

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
            f2.Close();
          

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            openpic.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            //Showing the fileopen dialog box
            openpic.ShowDialog();
            //showing the image opened in the picturebox
            pictureBox1.BackgroundImage = new Bitmap(openpic.FileName);
            //storing the location of the pic in variable
            location = openpic.FileName;
        imgtxt.Text = location;
        }

       
        

      
    }
}
