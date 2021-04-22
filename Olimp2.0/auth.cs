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
    public partial class auth : Form
    {
        public auth()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                Hide();
                admin admin = new admin();
                admin.ShowDialog();
                this.Close();
            }
            else if (textBox1.Text == "manager" && textBox2.Text == "manager")
            {
                Hide();
                uprav uprav = new uprav();
                uprav.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверно введены логин или пароль!", "Ошибка");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void auth_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            checkBox1.Checked = true;
        }
    }
}
