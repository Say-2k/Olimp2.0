using System;
using System.Windows.Forms;

namespace Hotel_Administration
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
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

        private void менеджерПаролейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            passwordManager password = new passwordManager();
            password.Show();
        }
    }
}
