using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace Pablito
{
    public partial class CsvConverter : Form
    {
        public CsvConverter()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string rutaExcel = Util.AbrirArchivo("Excel (*.xlsx)|*.xlsx");
            string rutaCsv = Util.GuardarArchivo("csv (*.csv)|*.csv");
            txtExcel.Text = rutaExcel;
            txtCsv.Text = rutaCsv;
            Util.CrearCSV(rutaExcel, rutaCsv, txtColumna.Text, int.Parse(txtFila.Text));
            MessageBox.Show("Ya :D");
        }
    }
}
