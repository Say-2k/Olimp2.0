using System;
using System.Windows.Forms;

namespace Hotel_Administration
{
    public partial class auth : Form
    {
        public auth()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connect.Table_Fill("Users", "SELECT * FROM Users");
            for (int i = 0; i < Connect.Ds.Tables["Users"].Rows.Count; i++)
            {
                if ((textBox1.Text == Connect.Ds.Tables["Users"].Rows[i][1].ToString()) && (textBox2.Text == Connect.Ds.Tables["Users"].Rows[i][2].ToString()))
                {
                    if (Connect.Ds.Tables["Users"].Rows[i][3].ToString() == "Администратор")
                    {
                        Hide();
                        admin admin = new admin();
                        admin.ShowDialog();
                        this.Close();
                    }
                    else if (Connect.Ds.Tables["Users"].Rows[i][3].ToString() == "Управляющий")
                    {
                        Hide();
                        uprav uprav = new uprav();
                        uprav.ShowDialog();
                        this.Close();
                    }
                }
            }
            MessageBox.Show("Неверно введены логин или пароль!", "Ошибка");
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
