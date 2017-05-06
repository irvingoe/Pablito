using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.IO;

namespace Pablito
{
    public partial class Busqueda : Form
    {
        public static List<Articulo> articulos = new List<Articulo>();
        public static List<Articulo> seleccionados = new List<Articulo>();
        public static List<ArticuloDetalle> ventas = new List<ArticuloDetalle>();
        public static List<ArticuloDetalle> marzam = new List<ArticuloDetalle>();
        BindingSource bs = new BindingSource();
        public Busqueda()
        {


            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Hide();
            backgroundWorker.RunWorkerAsync();
        }

        private bool InicializarArchivos(BackgroundWorker worker)
        {
            string excelMarzam = "\\MARZAM.xlsx";
            string excelCatalogo = "\\CAT.xlsx";
            string excelVentas = "\\VEN.xlsx";

            
            bool InicializarCompletado = false;
            worker.ReportProgress(10);

            do
            {
                bool existeMarzam = File.Exists(Environment.CurrentDirectory + excelMarzam);
                bool existeCatalogo = File.Exists(Environment.CurrentDirectory + excelCatalogo);
                bool existeVentas = File.Exists(Environment.CurrentDirectory + excelVentas);
                if (existeMarzam && existeCatalogo && existeVentas)
                {
                    worker.ReportProgress(50);
                    InicializarCompletado = InicializarCSV(worker);
                }
                else if (!existeMarzam)
                {
                    MessageBox.Show("El archivo " + excelMarzam + " no existe en el directorio " + Environment.CurrentDirectory);
                    InicializarCompletado = false;
                }
                else if (!existeCatalogo)
                {
                    MessageBox.Show("El archivo " + excelCatalogo + " no existe en el directorio " + Environment.CurrentDirectory);
                    InicializarCompletado = false;
                }
                else if (!existeVentas)
                {
                    MessageBox.Show("El archivo " + excelVentas + " no existe en el directorio " + Environment.CurrentDirectory);
                    InicializarCompletado = false;
                }
            } while (InicializarCompletado == false);

            worker.ReportProgress(0);
            return InicializarCompletado;
        }


        private bool InicializarCSV(BackgroundWorker worker)
        {
            string excelMarzam = Environment.CurrentDirectory + "\\MARZAM.xlsx";
            string excelCatalogo = Environment.CurrentDirectory + "\\CAT.xlsx";
            string excelVentas = Environment.CurrentDirectory + "\\VEN.xlsx";

            string csvMarzam = Environment.CurrentDirectory + "\\MARZAM.csv";
            string csvCatalogo = Environment.CurrentDirectory + "\\CAT.csv";
            string csvVentas = Environment.CurrentDirectory + "\\VEN.csv";

            bool existeMarzam = File.Exists(csvMarzam);
            bool existeCatalogo = File.Exists(csvCatalogo);
            bool existeVentas = File.Exists(csvVentas);
            bool InicializarCompletado = false;


            if (existeMarzam && existeCatalogo && existeVentas)
            {
                InicializarCompletado = true;
                worker.ReportProgress(99);
            }

            if (!existeMarzam)
            {
                Util.CrearCSV(excelMarzam, csvMarzam, "2,8,9,11", 7);
                worker.ReportProgress(66);
            }
            if (!existeCatalogo)
            {
                Util.CrearCSV(excelCatalogo, csvCatalogo, "2,3,4", 2);
                worker.ReportProgress(77);
            }
            if (!existeVentas)
            {
                worker.ReportProgress(88);
                Util.CrearCSV(excelVentas, csvVentas, "2,3", 2);
            }

            return InicializarCompletado;
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            //Solo intentaremos buscar cuando metas al menos 4 caracteres sino que hueva estar buscando a lo pendejo
            if (txtBusqueda.Text.Length > 3)
            {
                dataGridView1.DataSource = Util.Buscar(txtBusqueda.Text, articulos);
                dataGridView1.AutoResizeColumns();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bs.DataSource = seleccionados;
            dataGridView2.DataSource = bs;
            dataGridView2.AutoResizeColumns();
            int indiceCeldaSeleccionada = dataGridView1.SelectedCells[0].RowIndex;
            Articulo articuloSeleccionado = (Articulo)dataGridView1.Rows[indiceCeldaSeleccionada].DataBoundItem;

            if (!seleccionados.Contains(articuloSeleccionado))
            {
                seleccionados.Add(articuloSeleccionado);
                bs.ResetBindings(false);
                dataGridView2.AutoResizeColumns();
            }

        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //BindingSource bs = new BindingSource();
            //bs.DataSource = seleccionados;
            //dataGridView2.DataSource = bs;
            int indiceCeldaSeleccionada = dataGridView2.SelectedCells[0].RowIndex;
            Articulo articuloSeleccionado = (Articulo)dataGridView2.Rows[indiceCeldaSeleccionada].DataBoundItem;
            if (seleccionados.Contains(articuloSeleccionado))
            {
                seleccionados.Remove(articuloSeleccionado);
                bs.ResetBindings(false);
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            var nombres = seleccionados.Select(s => s.Nombre).ToList();
            var nuevos = ventas.Where(w => nombres.Contains(w.Nombre))
                  .Select(s => new ArticuloDetalle
                  {
                      Articulo = seleccionados.Where(w => w.Nombre == s.Nombre).Select(q => q.WClave).FirstOrDefault(),
                      Codigo = seleccionados.Where(w => w.Nombre == s.Nombre).Select(q => q.CodigoBarras).FirstOrDefault(),
                      Nombre = seleccionados.Where(w => w.Nombre == s.Nombre).Select(q => q.Nombre).FirstOrDefault(),
                      Venta = s.Venta
                  }).ToList();

            var codigos = nuevos.Select(s => s.Codigo).ToList();
            var detalle = marzam.Where(w => codigos.Contains(w.Codigo))
                            .Select(s => new ArticuloDetalle
                            {
                                Articulo = nuevos.Where(w => w.Codigo == s.Codigo).FirstOrDefault().Articulo,
                                Codigo = s.Codigo,
                                Nombre = nuevos.FirstOrDefault(w => w.Codigo == s.Codigo).Nombre,
                                Venta = nuevos.FirstOrDefault(w => w.Codigo == s.Codigo).Venta,
                                Fiscal = marzam.Where(w => w.Codigo == s.Codigo).Select(q => q.Fiscal).FirstOrDefault(),
                                Descuento = marzam.Where(w => w.Codigo == s.Codigo).Select(q => q.Descuento).FirstOrDefault(),
                                PrecioFarmacia = marzam.Where(w => w.Codigo == s.Codigo).Select(q => q.PrecioFarmacia).FirstOrDefault()
                            }).ToList();
            BindingSource bind = new BindingSource();
            bind.DataSource = detalle;
            dataGridView3.DataSource = bind;
            dataGridView3.AutoResizeColumns();

            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Hoja 1");

            //Insertando Titulos
            string[] titulos = {"ARTICULO", "CODIGO", "NOMBRE", "VENTA", "P. FARMACIA", "FISCAL", "DESC", "COSTO", "OFERTA", "P. FINAL", "CANTIDAD", "TOTAL" };
            for(int i = 0; i < titulos.Length; i++)
            {
                ws.Cell(1, (i + 1)).Value = titulos[i];
            }

            //Insertando Datos
            ws.Cell(2, 1).InsertData(detalle.AsEnumerable());
            
            ws.Columns().AdjustToContents();

            //Insertando Formulas
            //Formula de Precio Final
            ws.CellsUsed()
                .Where(cell => cell.Address.ColumnLetter == "J" && cell.Address.RowNumber > 1)
                .ForEach(cell => cell.FormulaA1 = String.Format("H{0}-($H${0}*$I${0})", cell.Address.RowNumber));

            //Formula de Total
            ws.CellsUsed()
                .Where(cell => cell.Address.ColumnLetter == "L" && cell.Address.RowNumber > 1)
                .ForEach(cell => cell.FormulaA1 = String.Format("J{0}*$K${0}", cell.Address.RowNumber));

            //Aplicando Formato de %
            ws.CellsUsed()
                .Where(cell => (cell.Address.ColumnLetter == "I" || cell.Address.ColumnLetter == "G") && cell.Address.RowNumber > 1)
                .ForEach(cell => cell.Style.NumberFormat.NumberFormatId = 10);

            string rutaGuardar = Util.GuardarArchivo("Excel (*.xlsx)|*.xlsx");

            if (rutaGuardar.Length > 1)
            {
                wb.SaveAs(rutaGuardar);
                MessageBox.Show("Completado.");
            }
            else {
                MessageBox.Show("No se selecciono el archivo de salida, intente de nuevo");
            }

            
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            // Assign the result of the computation
            // to the Result property of the DoWorkEventArgs
            // object. This is will be available to the 
            // RunWorkerCompleted eventhandler.
            //e.Result = ComputeFibonacci((int)e.Argument, worker, e);

            InicializarArchivos(worker);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ((Jarvis)this.MdiParent).progressBar.Value = e.ProgressPercentage;

            switch (e.ProgressPercentage)
            {
                case 10:
                    ((Jarvis)MdiParent).status.Text = "Verificando archivos Excel...";
                    break;
                case 50:
                    ((Jarvis)this.MdiParent).status.Text = "Archivos Excel verificados";
                    break;
                case 66:
                    ((Jarvis)this.MdiParent).status.Text = "Creando MARZAM.csv";
                    break;
                case 77:
                    ((Jarvis)this.MdiParent).status.Text = "Creando CAT.csv";
                    break;
                case 88:
                    ((Jarvis)this.MdiParent).status.Text = "Creando VEN.csv";
                    break;
                case 99:
                    ((Jarvis)this.MdiParent).status.Text = "Verificacion completada";
                    break;
                case 0:
                    ((Jarvis)this.MdiParent).status.Text = "";
                    break;
                default:
                    ((Jarvis)this.MdiParent).status.Text = "Woops?";
                    break;
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ((Jarvis)this.MdiParent).progressBar.Value = 0;
            ((Jarvis)this.MdiParent).status.Text = "";

            string csvMarzam = Environment.CurrentDirectory + "\\MARZAM.csv";
            string csvCatalogo = Environment.CurrentDirectory + "\\CAT.csv";
            string csvVentas = Environment.CurrentDirectory + "\\VEN.csv";

            articulos = Util.CrearListaArticulo(csvCatalogo);
            ventas = Util.CrearListaVenta(csvVentas);
            marzam = Util.CrearListaMarzam(csvMarzam);
            this.Show();
        }
    }
}
