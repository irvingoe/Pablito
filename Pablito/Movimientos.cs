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
using Pablito.Model;

namespace Pablito
{
    public partial class Movimientos : Form
    {
        public static List<Movimiento> articulos = new List<Movimiento>();
        public static List<Movimiento> seleccionados = new List<Movimiento>();
        BindingSource bs = new BindingSource();

        public Movimientos()
        {
            InitializeComponent();
            InicializarCSV();
        }

        private void InicializarCSV()
        {
            string excelMarzam = Environment.CurrentDirectory + "\\MARZAM.xlsx";

            string csvArticuloMovimiento = Environment.CurrentDirectory + "\\ARTICULOS.csv";

            bool existeArticuloMovimiento = File.Exists(csvArticuloMovimiento);

            if (existeArticuloMovimiento)
            {
                articulos = Util.CrearListaArticuloMovimiento(csvArticuloMovimiento);
            }

            if (!existeArticuloMovimiento)
            {
                Util.CrearCSV(excelMarzam, csvArticuloMovimiento, "2,3,11", 7);
                articulos = Util.CrearListaArticuloMovimiento(csvArticuloMovimiento);
            }

        }

        private void txtProveedor_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text.Length > 3)
            {
                dgvArticulos.DataSource = Util.BuscarArticuloMovimiento(txtBusqueda.Text, articulos);
                dgvArticulos.AutoResizeColumns();
            }
        }

        private void dgvArticulos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bs.DataSource = seleccionados;
            dgvMovimientos.DataSource = bs;
            dgvMovimientos.AutoResizeColumns();
            int indiceCeldaSeleccionada = dgvArticulos.SelectedCells[0].RowIndex;
            Movimiento articuloSeleccionado = (Movimiento)dgvArticulos.Rows[indiceCeldaSeleccionada].DataBoundItem;

            if (!seleccionados.Contains(articuloSeleccionado))
            {
                seleccionados.Add(articuloSeleccionado);
                bs.ResetBindings(false);
                dgvMovimientos.AutoResizeColumns();
                dgvMovimientos.Columns[0].ReadOnly = true; //Codigo
                dgvMovimientos.Columns[1].ReadOnly = true; //Nombre
                dgvMovimientos.Columns[3].ReadOnly = true; //Unidad
                dgvMovimientos.Columns[5].ReadOnly = true; //Importe
            }
        }

        private void dgvMovimientos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            long newlong;
            decimal newDecimal;
            if (e.ColumnIndex == 2) //Valida si es costo o cantidad
            {
                if (!long.TryParse(e.FormattedValue.ToString(),
                    out newlong) || newlong < 0)
                {
                    e.Cancel = true;
                    dgvMovimientos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dgvMovimientos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                }
            }
            else if (e.ColumnIndex == 4) //Valida si es costo o cantidad
            {
                if (!decimal.TryParse(e.FormattedValue.ToString(),
                    out newDecimal) || newDecimal < 0)
                {
                    e.Cancel = true;
                    dgvMovimientos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dgvMovimientos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                }
            }
        }

        private void dgvMovimientos_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            decimal costo = decimal.Parse(dgvMovimientos.Rows[e.RowIndex].Cells[4].Value.ToString());
            int cantidad = int.Parse(dgvMovimientos.Rows[e.RowIndex].Cells[2].Value.ToString());
            dgvMovimientos.Rows[e.RowIndex].Cells[5].Value = costo * cantidad;
        }

        private void brnGuardar_Click(object sender, EventArgs e)
        {
            StringBuilder lineas = new StringBuilder();
            seleccionados.Select(s => string.Join("~", new string[] { s.Codigo, s.Descripcion, s.Cantidad + "", s.Unidad, s.Costo + "", s.Importe + "" }))
                .ForEach(s =>
                {
                    if (s.Length > 1)
                    {
                        lineas.AppendLine(s);
                    }
                });
            //bool existeMarzam = File.Exists(Environment.CurrentDirectory + excelMarzam);
            string rutaGuardar = Environment.CurrentDirectory + "\\BD\\" + (cmbMovimiento.SelectedIndex == 0 ? "(C)" : "(T)") + txtEnlace.Text + ".csv";
            System.IO.FileInfo file = new System.IO.FileInfo(rutaGuardar);
            file.Directory.Create(); // If the directory already exists, this method does nothing.

            if (rutaGuardar.Length > 1)
            {
                File.WriteAllText(rutaGuardar, lineas.ToString());
                Reset();
                MessageBox.Show("Completado.");
            }
            else
            {
                MessageBox.Show("No se selecciono el archivo de salida, intente de nuevo");
            }
        }

        private void cmbMovimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            switch (comboBox.SelectedIndex)
            {
                case 0: //Compra
                    lblDyn.Text = "Proveedor";
                    lblDescripcion.Text = "Compra";
                    txtProveedor.Text = "MARZAM";
                    txtAlmacen.Text = "MATRIZ";
                    txtProveedor.ReadOnly = true;
                    txtAlmacen.ReadOnly = true;
                    break;
                case 1: //Salida
                    lblDescripcion.Text = "Salida";
                    lblDyn.Text = "Destino";
                    txtProveedor.Text = "";
                    txtAlmacen.Text = "";
                    break;
                default:
                    break;
            }
        }

        private void txtEnlace_TextChanged(object sender, EventArgs e)
        {
            if (txtEnlace.Text.Length == 6)
            {
                string rutaArchivo = Environment.CurrentDirectory + "\\BD\\" + "(C)" + txtEnlace.Text + ".csv";
                bool existeFactura = File.Exists(rutaArchivo);
                if (existeFactura)
                {
                    seleccionados = Util.CrearListaMovimiento(rutaArchivo);
                    bs.DataSource = seleccionados;
                    dgvMovimientos.DataSource = bs;
                    dgvMovimientos.Columns[0].ReadOnly = true; //Codigo
                    dgvMovimientos.Columns[1].ReadOnly = true; //Nombre
                    dgvMovimientos.Columns[3].ReadOnly = true; //Unidad
                    dgvMovimientos.Columns[5].ReadOnly = true; //Importe
                    dgvMovimientos.AutoResizeColumns();
                }
            }
        }

        private void dgvMovimientos_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void dgvMovimientos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                int indiceCeldaSeleccionada = dgvMovimientos.SelectedCells[0].RowIndex;
                Movimiento movimientoSeleccionado = (Movimiento)dgvMovimientos.Rows[indiceCeldaSeleccionada].DataBoundItem;
                if (seleccionados.Contains(movimientoSeleccionado))
                {
                    seleccionados.Remove(movimientoSeleccionado);
                    bs.ResetBindings(false);
                }
            }
        }

        private void Reset()
        {
            txtEnlace.Text = "";
            txtProveedor.Text = "";
            txtAlmacen.Text = "";
            txtBusqueda.Text = "";
            dgvMovimientos.DataSource = null;
            dgvArticulos.DataSource = null;
            cmbMovimiento.SelectedIndex = -1;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
