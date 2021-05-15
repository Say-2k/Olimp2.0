using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Hotel_Administration
{
    public partial class migrants : Form
    {
        public migrants()
        {
            InitializeComponent();
        }

        private void migrants_Load(object sender, EventArgs e)
        {
            string sql = "SELECT FamiliyaImyaOtchestvo AS [ФИО клиента], CONCAT(Seriya, ', ', Nomer, ', ', VidDokumenta, ', ', Vidan, ', ', StranaVidachi) AS [Паспортные данные], " +
                "CONCAT(NomerKarti, ', ', Otkuda, ', ', PrebivanieS, ', ', PrebivaniePo, ', ', CelPoezdki) AS [Данные миграционной карты] " +
                "FROM ((Klient INNER JOIN Dogovor ON Klient.IdKlienta = Dogovor.IdKlienta) " +
                "INNER JOIN Pasport ON Klient.IdKlienta = Pasport.IdKlienta) " +
                "INNER JOIN MigracionnayaKarta ON Klient.IdKlienta = MigracionnayaKarta.IdKlienta " +
                "WHERE DataZaezda >= '" + dateTimePicker1.Value.Date + "' AND DataViezda <= '" + dateTimePicker2.Value.Date + "'";
            Connect.Table_Fill("InostrKli", sql);
            dataGridView1.DataSource = Connect.Ds.Tables["InostrKli"];
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.CurrentCell = null;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoResizeColumns();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.OnLoad(e);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            this.OnLoad(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook book = app.Workbooks.Add();
            Excel.Worksheet lst = book.Worksheets[1];
            lst.Name = "Иностранные клиенты";
            int i = 0, j = 0;
            for (i = 0; i < dataGridView1.ColumnCount; i++)
            {
                lst.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
            }
            for (i = 0; i < dataGridView1.RowCount; i++)
            {
                for (j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    lst.Cells[i + 2, j + 1] = dataGridView1[j, i].Value;
                }
            }
            lst.Range[lst.Cells[1, 1], lst.Cells[1, j + 1]].HorizontalAlignment = 3;
            lst.Cells.Columns.EntireColumn.AutoFit();
            lst.Range[lst.Cells[1, 1], lst.Cells[i + 1, j]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            lst.Rows[1].Insert();
            lst.Range[lst.Cells[1, 1], lst.Cells[1, j]].Merge();
            lst.Cells[1, 1] = "Период формирования отчёта с " + dateTimePicker1.Value.ToShortDateString() + " до " + dateTimePicker2.Value.ToShortDateString();
            lst.Cells[1, 1].HorizontalAlignment = 3;
        }
    }
}
