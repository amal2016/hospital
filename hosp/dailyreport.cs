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
    public partial class dailyreport : Form
    {
        static string stringcon = ConfigurationManager.ConnectionStrings["mystring"].ConnectionString;
        OracleConnection conn = new OracleConnection(stringcon);
        public dailyreport()
        {
            InitializeComponent();
        }

        private void dailyreport_Load(object sender, EventArgs e)
        {
            string srch = "select digid,remark ,notes,fname||' '||lname \"patient\",pdob \"birth\",gender,mobile from dignostic d inner join patient p on d.PATIENTID=p.pid where drid=:doc order by digdate desc";
           
            OracleDataAdapter adapt=new OracleDataAdapter(srch,conn);
            adapt.SelectCommand.Parameters.Add("doc", OracleDbType.Int16).Value = login.id;
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            DataTable dt = ds.Tables[0];
            dataGridView1.DataSource = dt;



        }

        
    }
}
