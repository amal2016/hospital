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
    public partial class login : Form
    {
        public static string ss;
        public static string id;
        public string _textBox1
        {
            get { return textBox1.Text; }
        }
        static string stringcon = ConfigurationManager.ConnectionStrings["mystring"].ConnectionString;
        OracleConnection conn = new OracleConnection(stringcon);

        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            conn.Open();
            string strdr = "select * from doctor where docid=:id and password=:pass and status='active'";
        
            OracleCommand cmd = new OracleCommand(strdr, conn);
            cmd.Parameters.Add("id", textBox1.Text.ToString());
            cmd.Parameters.Add("pass", textBox2.Text.ToString());
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                ss = (dr["DFNAME"].ToString());
                id = (dr["docid"].ToString());
                this.Hide();
                doctor f1 = new doctor();
                f1._textBox = _textBox1;
               
                f1.ShowDialog();
            }
            string stremp = "select * from employee where eid=:id and password=:pass and emprule!='no'";
            OracleCommand cmdemp = new OracleCommand(stremp, conn);
            cmdemp.Parameters.Add("id", textBox1.Text.ToString());
            cmdemp.Parameters.Add("pass", textBox2.Text.ToString());
            OracleDataReader dremp = cmdemp.ExecuteReader();
            if (dremp.Read())
            {
                id = (dremp["eid"].ToString());
                if ((dremp["emprule"].ToString()) == "admin")
                {
                    this.Hide();
                    Form2 F2 = new Form2();
                    F2.Show();
                }
                else
                {
                    this.Hide();
                    acc ac = new acc();
                    ac.ShowDialog();


                }
            }

            conn.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsPunctuation(e.KeyChar) ||
                   Char.IsSeparator(e.KeyChar) ||
                   Char.IsLetter (e.KeyChar);
        }

        private void login_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label7.Text = dt.ToString();
            master ms = new master();
            Control[] ct = ms.Controls.Find("Label1", true);
            if (ct.Length > 0)
            {
                Label lbl = (Label)ct[0];
                lbl.Text = "Hello";
            }


        }
    }
}
