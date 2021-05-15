using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Administration
{
    public partial class reg : Form
    {
        public reg()
        {
            InitializeComponent();
        }

        private void reg_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Klient";
            Connect.Table_Fill("Klient", sql);
            ///
            groupBox2.Enabled = false;
            textBox4.ReadOnly = true;
            comboBox2.Text = "Паспорт РФ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && maskedTextBox1.Text != "" && maskedTextBox2.Text != "")
            {
                int id = Convert.ToInt32(Connect.Ds.Tables["Klient"].Compute("MAX(IdKlienta)", "")) + 1;
                string sql = "INSERT INTO Klient VALUES (" + id + ", '" + textBox1.Text + "', '" + comboBox1.Text + "', '" + dateTimePicker1.Value.Date + "', '" + comboBox3.Text + "')";
                Connect.Modification_Execute(sql);
                sql = "INSERT INTO Pasport VALUES (" + id + ", '" + maskedTextBox1.Text + "', '" + maskedTextBox2.Text + "', '" + comboBox2.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "')";
                Connect.Modification_Execute(sql);
                if (comboBox2.Text == "Иностранный паспорт" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
                {
                    sql = "INSERT INTO MigracionnayaKarta VALUES (" + id + ", '" + textBox5.Text + "', '" + textBox6.Text + "', '" + dateTimePicker2.Value.Date + "', '" + dateTimePicker3.Value.Date + "', '" + textBox7.Text + "')";
                    Connect.Modification_Execute(sql);
                }
                MessageBox.Show("Клиент добавлен");
                this.OnLoad(e);
            }
            else
            {
                MessageBox.Show("Обязательное заполнение всех указанных полей", "Ошибка");
            }
        }

        private void ru_notru()
        {
            if (comboBox2.Text == "Иностранный паспорт")
            {
                textBox4.ReadOnly = false;
                groupBox2.Enabled = true;
            }
            else if (comboBox2.Text == "Паспорт РФ")
            {
                textBox4.ReadOnly = true;
                groupBox2.Enabled = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ru_notru();
        }

        private void comboBox2_KeyUp(object sender, KeyEventArgs e)
        {
            ru_notru();
        }
    }
}
