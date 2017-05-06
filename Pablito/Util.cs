using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Pablito.Model;

namespace Pablito
{
    public static class Util
    {
        public static string[] LeerArchivo(string rutaArchivo)
        {
            return System.IO.File.ReadAllLines(rutaArchivo);
        }

        public static List<Articulo> CrearListaArticulo(string rutaArchivo)
        {
            List<Articulo> articulos = new List<Articulo>();
            foreach (var linea in LeerArchivo(rutaArchivo))
            {
                if (linea.Length > 1) // que la linea no venga vacia wey!
                {
                    var campos = linea.Split('~');
                    //campo 1 = WClave
                    //campo 2 = Codigo Barras
                    //campo 3 = Nombre
                    articulos.Add(new Articulo(campos[0], campos[1], campos[2])); 
                }
            }
            return articulos;
        }

        public static List<ArticuloDetalle> CrearListaVenta(string rutaArchivo)
        {
            List<ArticuloDetalle> articulos = new List<ArticuloDetalle>();
            foreach (var linea in LeerArchivo(rutaArchivo))
            {
                if (linea.Length > 1) // que la linea no venga vacia wey!
                {
                    var campos = linea.Split('~');
                    //campo 1 = Nombre
                    //campo 2 = Venta
                    //
                    ArticuloDetalle articulo = new ArticuloDetalle();
                    articulo.Nombre = campos[0];
                    articulo.Venta = int.Parse(campos[1]);
                    articulos.Add(articulo);
                }
            }
            return articulos;
        }

        public static List<ArticuloDetalle> CrearListaMarzam(string rutaArchivo)
        {
            List<ArticuloDetalle> articulos = new List<ArticuloDetalle>();
            foreach (var linea in LeerArchivo(rutaArchivo))
            {
                if (linea.Length > 1) // que la linea no venga vacia wey!
                {
                    var campos = linea.Split('~');
                    //campo 1 = Codigo Barra
                    //campo 2 = FIscal
                    //campo 3 = Porcentaje Limitado
                    //campo 4 = Precio Farmacia
                    //
                    ArticuloDetalle articulo = new ArticuloDetalle();
                    articulo.Codigo = campos[0];
                    articulo.Fiscal = campos[1];
                    articulo.Descuento = decimal.Parse(campos[2] == "" ? "0" : campos[2]);
                    articulo.PrecioFarmacia = decimal.Parse(campos[3]);
                    articulos.Add(articulo);
                }
            }
            return articulos;
        }

        public static List<oCotizacion> CrearListaCotizacion(string rutaArchivo)
        {
            List<oCotizacion> cotizaciones = new List<oCotizacion>();
            foreach (var linea in LeerArchivo(rutaArchivo))
            {
                if (linea.Length > 1) // que la linea no venga vacia wey!
                {
                    var campos = linea.Split('~');

                    /*
                   1  * B - CODIGO 2
                    2C - NOMBRE 3 
                    3D - EXISTENCIA 4
                    4F - LABORATORIO 6
                    5H - FISCAL 8
                    6I - DESCUENTO 9  
                    7K - PRECIO FARMACIA 11
                    ---Extra---
                    8Precio Publico (Calculada)
                     * */
                    oCotizacion cotizacion = new oCotizacion();
                    cotizacion.Codigo = campos[0];
                    cotizacion.Nombre = campos[1];
                    cotizacion.Existencia = int.Parse(campos[2]);
                    cotizacion.Laboratorio = campos[3];
                    cotizacion.Fiscal = campos[4];
                    cotizacion.Descuento = decimal.Parse(campos[5] == "" ? "0" : campos[5]);
                    cotizacion.PrecioFarmacia = decimal.Parse(campos[6]);
                    cotizaciones.Add(cotizacion);
                }
            }
            return cotizaciones;
        }

        public static List<Movimiento> CrearListaArticuloMovimiento(string rutaArchivo)
        {
            List<Movimiento> cotizaciones = new List<Movimiento>();
            foreach (var linea in LeerArchivo(rutaArchivo))
            {
                if (linea.Length > 1) // que la linea no venga vacia wey!
                {
                    var campos = linea.Split('~');

                    /*
                   1  * B - CODIGO 1
                    2C - NOMBRE 2 
                    7K - PRECIO FARMACIA 3
                    ---Extra---
                    8Precio Publico (Calculada)
                     * */
                    Movimiento articuloMovimiento = new Movimiento();
                    articuloMovimiento.Codigo = campos[0];
                    articuloMovimiento.Descripcion = campos[1];
                    articuloMovimiento.Costo = decimal.Parse(campos[2]);
                    articuloMovimiento.Unidad = "PZA";
                    cotizaciones.Add(articuloMovimiento);
                }
            }
            return cotizaciones;
        }

        public static List<Movimiento> CrearListaMovimiento(string rutaArchivo)
        {
            List<Movimiento> movimientos = new List<Movimiento>();
            foreach (var linea in LeerArchivo(rutaArchivo))
            {
                if (linea.Length > 1) // que la linea no venga vacia wey!
                {
                    var campos = linea.Split('~');

                    /*
                   1  * B - CODIGO 1
                    2C - NOMBRE 2 
                    7K - PRECIO FARMACIA 3
                    ---Extra---
                    8Precio Publico (Calculada)
                     * */
                    Movimiento movimiento = new Movimiento();
                    movimiento.Codigo = campos[0];
                    movimiento.Descripcion = campos[1];
                    movimiento.Cantidad = int.Parse(campos[2]);
                    movimiento.Unidad = campos[3];
                    movimiento.Costo = decimal.Parse(campos[4]);
                    movimiento.Importe = decimal.Parse(campos[5]);
                    movimientos.Add(movimiento);
                }
            }
            return movimientos;
        }

        public static List<Articulo> Buscar(string busqueda, List<Articulo> fuente)
        {
            return fuente.Where(q => q.Nombre.Contains(busqueda)).ToList<Articulo>();
        }

        public static List<oCotizacion> BuscarMarzam(string busqueda, List<oCotizacion> fuente)
        {
            return fuente.Where(q => q.Nombre.Contains(busqueda)).ToList<oCotizacion>();
        }

        public static List<Movimiento> BuscarArticuloMovimiento(string busqueda, List<Movimiento> fuente)
        {
            return fuente.Where(q => q.Descripcion.Contains(busqueda) || q.Codigo.Contains(busqueda)).ToList<Movimiento>();
        }

        public static List<String> GetCodigoBarras(List<Articulo> fuente)
        {
            return fuente.Select(q => q.CodigoBarras).ToList();
        }

        public static string AbrirArchivo(string Extension)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            //openFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx";
            openFileDialog1.Filter = Extension;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return openFileDialog1.FileName;
            }
            else
            {
                return "";
            }
        }

        public static string GuardarArchivo(string Extension)
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog2.FileName = "*";
            saveFileDialog2.DefaultExt = Extension.Split('*')[Extension.Split('*').Length - 1];
            saveFileDialog2.ValidateNames = true;
            saveFileDialog2.Filter = Extension;
            saveFileDialog2.InitialDirectory = Environment.CurrentDirectory;
            if (saveFileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return saveFileDialog2.FileName;
            }
            else
            {
                return "";
            }
        }

        public static void CrearCSV(string rutaExcel, string rutaCSV, string filtroColumna, int FilaInicio)
        {
            StringBuilder buffer = new StringBuilder();
            var ArchivoExcel = new XLWorkbook(rutaExcel);
            var Hoja1 = ArchivoExcel.Worksheet(1);
            Hoja1.RowsUsed()
                .Select(
                    row => 
                        string.Join("~"
                        , row.Cells(1, row.LastCellUsed(false).Address.ColumnNumber)
                            .Where(cell => filtroColumna.Split(',').ToList().Contains("" + cell.Address.ColumnNumber) && cell.Address.RowNumber >= FilaInicio)
                            .Select(cell => cell.GetValue<string>()))
            )
            .ForEach(s =>
            {
                if (s.Length > 1)
                {
                    buffer.AppendLine(s);
                }
            });

            // Create a file to write to.
            File.WriteAllLines(rutaCSV, buffer.ToString().Split('\n').ToArray(), Encoding.UTF8);
        }

    }
}
