using System;
using System.Drawing;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Hotel_Administration
{
    public partial class postklients : Form
    {
        public postklients()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.OnLoad(e);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            this.OnLoad(e);
        }

        private void postklients_Load(object sender, EventArgs e)
        {
            string sql = "SELECT Dogovor.IdKlienta, CONCAT(Familiya, ' ', Imya, ' ', Otchestvo) AS [ФИО клиента], BonusnayaKarta AS [Вид бонусной карты], COUNT(*) AS [Количество договоров за указанный период], SUM(SummaOplati) AS [Общая сумма оплаты] " +
                "FROM Dogovor INNER JOIN Klient ON Dogovor.IdKlienta = Klient.IdKlienta " +
                "WHERE DataDogovora >= '" + dateTimePicker1.Value.Date + "' AND DataDogovora <= '" + dateTimePicker2.Value.Date + "'" +
                "GROUP BY Dogovor.IdKlienta, Familiya, Imya, Otchestvo, BonusnayaKarta " +
                "HAVING COUNT(*) >= 3";
            Connect.Table_Fill("postklients", sql);
            dataGridView1.DataSource = Connect.Ds.Tables["postklients"];
            dataGridView1.Columns["IdKlienta"].Visible = false;
            dataGridView1.CurrentCell = null;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoResizeColumns();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook book = app.Workbooks.Add();
            Excel.Worksheet lst = book.Sheets[1];
            lst.Name = "Постоянные клиенты";
            int i = 0, j = 0;
            for (i = 1; i < dataGridView1.ColumnCount; i++)
            {
                lst.Cells[1, i] = dataGridView1.Columns[i].HeaderText;
            }
            for (i = 0; i < dataGridView1.RowCount; i++)
            {
                for (j = 1; j < dataGridView1.ColumnCount; j++)
                {
                    lst.Cells[i + 2, j] = dataGridView1[j, i].Value;
                }
            }
            lst.Range[lst.Cells[1, 1], lst.Cells[1, j]].HorizontalAlignment = 3;
            lst.Cells.Columns.EntireColumn.AutoFit();
            lst.Range[lst.Cells[1, 1], lst.Cells[i + 1, j - 1]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            lst.Rows[1].Insert();
            lst.Range[lst.Cells[1, 1], lst.Cells[1, j - 1]].Merge();
            lst.Cells[1, 1] = "Период формирования отчёта с " + dateTimePicker1.Value.ToShortDateString() + " по " + dateTimePicker2.Value.ToShortDateString();
            lst.Cells[1, 1].HorizontalAlignment = 3;
        }
    }
}
