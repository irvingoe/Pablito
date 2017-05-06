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
    public partial class Cotizacion : Form
    {
        public static List<oCotizacion> cotizacion = new List<oCotizacion>();
        public static List<oCotizacion> seleccionados = new List<oCotizacion>();
        BindingSource bs = new BindingSource();
        public Cotizacion()
        {
            InitializeComponent();
            InicializarCSV();
        }

        private void InicializarCSV()
        {
            string excelMarzam = Environment.CurrentDirectory + "\\MARZAM.xlsx";

            string csvCotizacion = Environment.CurrentDirectory + "\\COTIZACION.csv";

            bool existeCotizacion = File.Exists(csvCotizacion);
            bool InicializarCompletado = false;


            if (existeCotizacion)
            {
                InicializarCompletado = true;
                cotizacion = Util.CrearListaCotizacion(csvCotizacion);
            }

            if (!existeCotizacion)
            {
                /*
                   *B - CODIGO 2 > 1
                    C - NOMBRE 3 > 2
                    D - EXISTENCIA 4 > 3
                    E - LABORATORIO 5 > 4
                    H - FISCAL 8 > 5
                    I - DESCUENTO 9 > 6 
                    K - PRECIO FARMACIA 11 > 7 
                 */
                Util.CrearCSV(excelMarzam, csvCotizacion, "1,2,3,4,5,6,7", 7);
                cotizacion = Util.CrearListaCotizacion(csvCotizacion);
            }
            
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text.Length > 3)
            {
                dgvMain.DataSource = Util.BuscarMarzam(txtBusqueda.Text, cotizacion);
                dgvMain.AutoResizeColumns();
            }
        }

        private void dgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtBusqueda.Clear();
            bs.DataSource = seleccionados;
            dgvPreview.DataSource = bs;
            dgvPreview.AutoResizeColumns();
            int indiceCeldaSeleccionada = dgvMain.SelectedCells[0].RowIndex;
            oCotizacion articuloSeleccionado = (oCotizacion)dgvMain.Rows[indiceCeldaSeleccionada].DataBoundItem;

            if (!seleccionados.Contains(articuloSeleccionado))
            {
                seleccionados.Add(articuloSeleccionado);
                bs.ResetBindings(false);
                dgvPreview.AutoResizeColumns();
            }
        }

        private void Cotizacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Cotizacion");

            string[] titulos = { " # ","CODIGO", "NOMBRE", "EXISTENCIA", "LABORATORIO", "FISCAL", "DESCUENTO", "PRECIO FARMACIA", "PRECIO CEMAIN PF", "PRECIO PUBLICO PP" };
            for (int i = 0; i < titulos.Length; i++)
            {
                ws.Cell(1, (i + 1)).Value = titulos[i];
            }

            ws.Cell(2, 2).InsertData(seleccionados.AsEnumerable());
            ws.Columns().AdjustToContents();
            string rutaGuardar = Util.GuardarArchivo("Excel (*.xlsx)|*.xlsx");

            if (rutaGuardar.Length > 1)
            {
                wb.SaveAs(rutaGuardar);
                MessageBox.Show("Completado.");
            }
            else
            {
                MessageBox.Show("No se selecciono el archivo de salida, intente de nuevo");
            }
        }

        private void dgvPreview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int indiceCeldaSeleccionada = dgvPreview.SelectedCells[0].RowIndex;
            oCotizacion articuloSeleccionado = (oCotizacion)dgvPreview.Rows[indiceCeldaSeleccionada].DataBoundItem;
            if (seleccionados.Contains(articuloSeleccionado))
            {
                seleccionados.Remove(articuloSeleccionado);
                bs.ResetBindings(false);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.txtBusqueda.Clear();
            //this.dgvMain.ClearSelection();
            //this.dgvPreview.ClearSelection();
            dgvPreview.Rows.Clear();


        }

        private void Cotizacion_Load(object sender, EventArgs e)
        {

        }

        private void dgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
