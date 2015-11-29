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
    public partial class allemp : Form
    {
        static string stringcon = ConfigurationManager.ConnectionStrings["mystring"].ConnectionString;
        OracleConnection conn = new OracleConnection(stringcon);
        public allemp()
        {
            InitializeComponent();
        }

        private void allemp_Load(object sender, EventArgs e)
        {
            string srch = "select * from employee";
            OracleDataAdapter adapt = new OracleDataAdapter(srch, conn);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            DataTable dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
        }
    }
}
