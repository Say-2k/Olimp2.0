using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Olimp2._0
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        public static SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-NNTMJTC; Initial Catalog = Olimp2; Integrated Security = True");

        public static DataSet ds = new DataSet();

        public static void Table_Fill(string name, string sql)
        {
            if (ds.Tables[name] != null)
            {
                ds.Tables[name].Clear();
            }
            conn.Open();
            SqlDataAdapter dat = new SqlDataAdapter(sql, conn);
            dat.Fill(ds, name);
            conn.Close();
        }

        public static bool Modification_Execute(string sql)
        {
            SqlCommand comm = new SqlCommand(sql, conn);
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            return true;
        }

        private void регистрацияКлиентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reg reg = new reg();
            reg.Show();
        }

        private void вселениеКлиентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vselenie vselenie = new vselenie();
            vselenie.Show();
        }
    }
}
