using System;
using System.Windows.Forms;

namespace Hotel_Administration
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
