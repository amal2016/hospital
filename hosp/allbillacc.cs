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
    public partial class allbillacc : Form
    {

   static   string stringcon =  ConfigurationManager.ConnectionStrings["mystring"].ConnectionString;
      OracleConnection conn = new OracleConnection(stringcon);
 


        public allbillacc()
        {
            InitializeComponent();
        }

        private void allbillacc_Load(object sender, EventArgs e)
        {
            string str="select billno,patientid,billdate,amount,sfname||slname \"Employee\",eid \"ID\" from employee e inner join bill b on e.eid=b.addedby where addedby=:ad";
            conn.Open();
            OracleDataAdapter adapt = new OracleDataAdapter(str,conn);
            adapt.SelectCommand.Parameters.Add("ad", OracleDbType.Varchar2).Value = login.id.ToString();
                DataSet ds=new DataSet();
                adapt.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;

                conn.Close();




        }

        
    }
}
