using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Olimp2._0
{
    public partial class uprav : Form
    {
        public uprav()
        {
            InitializeComponent();
        }

        private void выселениеКлиентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viselenie viselenie = new viselenie();
            viselenie.Show();
        }

        private void отчётОПостоянныхКлиентахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            postklients postklients = new postklients();
            postklients.Show();
        }

        private void отчётОбИностранныхКлиентахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            migrants migrants = new migrants();
            migrants.Show();
        }
    }
}
