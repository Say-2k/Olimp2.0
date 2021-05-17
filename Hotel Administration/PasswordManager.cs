using System;
using System.Windows.Forms;

namespace Hotel_Administration
{
    public partial class passwordManager : Form
    {
        public passwordManager()
        {
            InitializeComponent();
        }

        private void PasswordManager_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Connect.Ds.Tables["Users"].Rows.Count; i++)
            {
                comboBox1.Items.Add(Connect.Ds.Tables["Users"].Rows[i][1].ToString());
            }
            textBox2.UseSystemPasswordChar = true;
            checkBox1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Connect.Ds.Tables["Users"].Rows.Count; i++)
            {
                if (Connect.Ds.Tables["Users"].Rows[i][1].ToString() == comboBox1.Text)
                {
                    string sql = "UPDATE Users SET Password = '" + textBox2.Text + "' WHERE Login = '" +
                                 comboBox1.Text + "'";
                    Connect.Modification_Execute(sql);
                    MessageBox.Show("Изменение пароля прошло успешно");
                    return;
                }
            }
            MessageBox.Show("Ошибка ввода логина");
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
    }
}
