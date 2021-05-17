using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hotel_Administration
{
    public partial class viselenie : Form
    {
        public viselenie()
        {
            InitializeComponent();
        }

        private void viselenie_Load(object sender, EventArgs e)
        {
            string sql = "SELECT GostinichniyNomer.CenaZaSutki, Klient.BonusnayaKarta, NomerDogovora AS [Номер договора], Dogovor.NomerPomesheniya AS [Номер помещения], CONCAT(Familiya, ' ', Imya, ' ', Otchestvo) AS [ФИО клиента], DataZaezda AS [Дата заезда], DataViezda AS [Дата выезда], Dogovor.SummaOplati " +
                "FROM (Dogovor INNER JOIN Klient ON Dogovor.IdKlienta = Klient.IdKlienta) " +
                "INNER JOIN GostinichniyNomer ON Dogovor.NomerPomesheniya = GostinichniyNomer.NomerPomesheniya " +
                "WHERE DataViezda = '" + dateTimePicker1.Value.Date + "' AND Status = 'занят' AND Dogovor.IdKlienta = GostinichniyNomer.IdKlienta";
            Connect.Table_Fill("Dogovor", sql);
            dataGridView1.DataSource = Connect.Ds.Tables["Dogovor"];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoResizeColumns();
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.CurrentCell = null;
            dataGridView1.ReadOnly = true;
            groupBox1.Enabled = false;
            button1.Enabled = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.OnLoad(e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox2.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox3.Text = dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();
            dateTimePicker2.Value = Convert.ToDateTime(dataGridView1[5, dataGridView1.CurrentRow.Index].Value);
            dateTimePicker3.Value = Convert.ToDateTime(dataGridView1[6, dataGridView1.CurrentRow.Index].Value);
            groupBox1.Enabled = true;
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker3.Value.Date == Convert.ToDateTime(dataGridView1[6, dataGridView1.CurrentRow.Index].Value))
            {
                string sql = "UPDATE GostinichniyNomer SET Status = 'свободен', IdKlienta = null WHERE NomerPomesheniya = " + textBox2.Text;
                Connect.Modification_Execute(sql);
                MessageBox.Show("Клиент выселился");
                this.OnLoad(e);
            }
            else
            {
                string sql = "UPDATE Dogovor SET DataViezda = '" + dateTimePicker3.Value.Date + "' WHERE NomerDogovora = " + textBox1.Text;
                Connect.Modification_Execute(sql);
                int span = dateTimePicker3.Value.Subtract(dateTimePicker2.Value.Date).Days;
                double procent = 0;
                if (dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString() == "платиновая")
                {
                    procent = 0.95;
                }
                else if (dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString() == "золотая")
                {
                    procent = 0.97;
                }
                else if (dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString() == "обычная")
                {
                    procent = 0.99;
                }
                else if (dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString() == "нет")
                {
                    procent = 1;
                }
                double plus = span * procent * Convert.ToDouble(dataGridView1[0, dataGridView1.CurrentRow.Index].Value);
                sql = "UPDATE Dogovor SET SummaOplati = " + plus + " WHERE NomerDogovora = " + textBox1.Text;
                Connect.Modification_Execute(sql);
                MessageBox.Show("Дата выезда клиента успешно перенесена");
                this.OnLoad(e);
            }
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker3.Value.Date == Convert.ToDateTime(dataGridView1[6, dataGridView1.CurrentRow.Index].Value))
            {
                button1.Text = "Выселить";
            }
            else
            {
                button1.Text = "Перенести";
            }
        }
    }
}
