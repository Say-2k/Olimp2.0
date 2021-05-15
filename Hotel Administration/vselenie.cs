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
    public partial class vselenie : Form
    {
        public vselenie()
        {
            InitializeComponent();
        }

        private void vselenie_Load(object sender, EventArgs e)
        {
            string sql = "SELECT IdKlienta, FamiliyaImyaOtchestvo AS [ФИО клиента], BonusnayaKarta AS [Вид бонусной карты] FROM Klient";
            Connect.Table_Fill("Klient", sql);
            dataGridView1.DataSource = Connect.Ds.Tables["Klient"];
            dataGridView1.Columns["IdKlienta"].Visible = false;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.CurrentCell = null;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            ///
            sql = "SELECT NomerPomesheniya, Oboznachenie AS [Обозначение категории], Opisanie AS [Описание номера], CenaZaSutki AS [Цена за сутки], KolichestvoMest AS [Количество мест] " +
                "FROM GostinichniyNomer INNER JOIN Kategoriya ON GostinichniyNomer.IdKategorii = Kategoriya.IdKategorii WHERE Status = 'свободен'";
            Connect.Table_Fill("Nomer", sql);
            dataGridView2.DataSource = Connect.Ds.Tables["Nomer"];
            dataGridView2.Columns["NomerPomesheniya"].Visible = false;
            dataGridView2.AutoResizeColumns();
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.ReadOnly = true;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.CurrentCell = null;
            dataGridView2.BackgroundColor = SystemColors.Control;
            dataGridView2.BorderStyle = BorderStyle.None;
            ///
            sql = "SELECT * FROM Dogovor";
            Connect.Table_Fill("Dogovor", sql);
            ///
            sql = "SELECT * FROM Kategoriya";
            Connect.Table_Fill("Kategoriya", sql);
            for (int i = 0; i < Connect.Ds.Tables["Kategoriya"].Rows.Count; i++)
            {
                comboBox1.Items.Add(Connect.Ds.Tables["Kategoriya"].Rows[i]["Oboznachenie"].ToString());
            }
            ///
            button1.Enabled = false;
        }

        private static int k = 0, n = 0;

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            Connect.Ds.Tables["Klient"].DefaultView.RowFilter = "[ФИО клиента] LIKE '" + textBox1.Text + "*'";
        }

        private void found()
        {
            string str = "";
            if (comboBox1.Text != "")
            {
                str = "[Обозначение категории] = '" + comboBox1.Text + "'";
            }
            if (textBox5.Text != "" && str != "")
            {
                str += " AND [Цена за сутки] <= " + textBox5.Text;
            }
            else if (str == "" && textBox5.Text != "")
            {
                str += "[Цена за сутки] <= " + textBox5.Text;
            }
            if (numericUpDown1.Value != 0 && str != "")
            {
                str += " AND [Количество мест] <= " + numericUpDown1.Value;
            }
            else if (str == "" && numericUpDown1.Value != 0)
            {
                str += "[Количество мест] = " + numericUpDown1.Value;
            }
            Connect.Ds.Tables["Nomer"].DefaultView.RowFilter = str;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            found();
        }

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            found();
        }

        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            found();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            found();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            n = dataGridView2.CurrentRow.Index;
            n = Convert.ToInt32(dataGridView2[0, n].Value);
            if (dataGridView1.CurrentRow != null)
            {
                Sum();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            k = dataGridView1.CurrentRow.Index;
            textBox2.Text = dataGridView1[1, k].Value.ToString();
            textBox3.Text = dataGridView1[2, k].Value.ToString();
            k = Convert.ToInt32(dataGridView1[0, k].Value);
            if (dataGridView2.CurrentRow != null)
            {
                Sum();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null && dataGridView1.CurrentRow != null)
            {
                Sum();
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null && dataGridView1.CurrentRow != null)
            {
                Sum();
            }
        }

        private decimal sum = 0;

        private void Sum()
        {
            int day = dateTimePicker2.Value.Date.Subtract(dateTimePicker1.Value.Date).Days;
            if (textBox3.Text == "платиновая")
            {
                sum = Convert.ToDecimal(Convert.ToDouble(dataGridView2[3, dataGridView2.CurrentRow.Index].Value) * day * 0.95);
            }
            else if (textBox3.Text == "золотая")
            {
                sum = Convert.ToDecimal(Convert.ToDouble(dataGridView2[3, dataGridView2.CurrentRow.Index].Value) * day * 0.97);
            }
            else if (textBox3.Text == "обычная")
            {
                sum = Convert.ToDecimal(Convert.ToDouble(dataGridView2[3, dataGridView2.CurrentRow.Index].Value) * day * 0.99);
            }
            else if (textBox3.Text == "нет")
            {
                sum = Convert.ToDecimal(Convert.ToDouble(dataGridView2[3, dataGridView2.CurrentRow.Index].Value) * day);
            }
            textBox4.Text = sum.ToString();
            if (textBox4.Text != "" && textBox4.Text != "0")
            {
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (Connect.Ds.Tables["Dogovor"].Compute("MAX(NomerDogovora)", "").ToString() == "")
            {
                id = 1;
            }
            else
            {
                id = 1 + Convert.ToInt32(Connect.Ds.Tables["Dogovor"].Compute("MAX(NomerDogovora)", ""));
            }
            string sql = "INSERT INTO Dogovor VALUES (" + id + ", '" + DateTime.Now.Date + "', " + k + ", " + n + "," +
                " '" + dateTimePicker1.Value.Date + "', '" + dateTimePicker2.Value.Date + "', " + sum.ToString().Replace(",",".") + ", '" + comboBox2.Text + "')";
            Connect.Modification_Execute(sql);
            sql = "UPDATE GostinichniyNomer SET Status = 'занят' WHERE NomerPomesheniya = " + n;
            Connect.Modification_Execute(sql);
            MessageBox.Show("Операция выполнена успешно!");
            this.OnLoad(e);
        }
    }
}
