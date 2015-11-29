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
    public partial class today_pat : Form
    {
        static string stringcon = ConfigurationManager.ConnectionStrings["mystring"].ConnectionString;
        OracleConnection conn = new OracleConnection(stringcon);
        public today_pat()
        {
            InitializeComponent();
        }

        private void today_pat_Load(object sender, EventArgs e)
        {
            string srch = "select digid,remark ,notes,fname||lname \"patient\",pdob \"birth\",gender,mobile from dignostic d inner join patient p on d.PATIENTID=p.pid where to_date(digdate)=to_date(sysdate) order by digdate desc";
            OracleDataAdapter adapt = new OracleDataAdapter(srch, conn);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            DataTable dt = ds.Tables[0];
            dataGridView1.DataSource = dt;

        }
    }
}
