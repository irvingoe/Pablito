using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public static string AbrirArchivo(string Extension, string descripcion = "")
        {
            System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            //openFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx";
            openFileDialog1.Filter = Extension;
            openFileDialog1.Title = descripcion;
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

            // Create a fileItem to write to.
            File.WriteAllLines(rutaCSV, buffer.ToString().Split('\n').ToArray(), Encoding.UTF8);
        }

        public static void TestMethod()
        {
            //string currentMonthFolder = "";
            //using (FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog())
            //{
            //    folderBrowserDialog1.Description = "Selecciona la carpeta del mes deseado.";
            //    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            //    {
            //        currentMonthFolder = folderBrowserDialog1.SelectedPath;
            //    }
            //}

            List<VentasArticulo> itemList;
            VentasArticulo item;
            List<ArticuloInventario> inventarioList = new List<ArticuloInventario>();
            ArticuloInventario inventarioItem;
            string mesFile = AbrirArchivo("Excel Files (*.xlsx)|*.xlsx", "");
            //            string currentArticulo = Path.GetFileNameWithoutExtension(mesFile);
            string currentFolder = Path.GetDirectoryName(mesFile);
            var itemFiles = Directory.GetFiles(currentFolder, "*.xlsx", SearchOption.TopDirectoryOnly);
            var existenciasFiles = Directory.GetFiles(currentFolder + "\\EXISTENCIAS", "*.xlsx", SearchOption.TopDirectoryOnly);
            using (var excelWorkbook = new XLWorkbook(mesFile))
            {
                //var nonEmptyDataRows = excelWorkbook.Worksheet(1).RowsUsed();
                var nonEmptyDataRows = excelWorkbook.Worksheet(1).RangeUsed().RowsUsed().Skip(1);

                foreach (var dataRow in nonEmptyDataRows)
                {
                    inventarioItem = new ArticuloInventario();
                    string idArticulo = dataRow.Cell("C").Value.ToString();
                    string nombreArticulo = dataRow.Cell("D").Value.ToString();
                    int cantidadRegular = Convert.ToInt32(dataRow.Cell("E").Value);
                    inventarioItem.IdArticulo = idArticulo;
                    inventarioItem.NombreArticulo = nombreArticulo;
                    inventarioItem.CantidadRegular = cantidadRegular;
                    inventarioList.Add(inventarioItem);
                }
            }
            foreach (var fileItem in itemFiles)
            {
                if (fileItem == mesFile) continue;
                string currentArticulo = Path.GetFileNameWithoutExtension(fileItem);
                itemList = new List<VentasArticulo>();
                using (var excelWorkbook = new XLWorkbook(fileItem))
                {
                    //var nonEmptyDataRows = excelWorkbook.Worksheet(1).RowsUsed();
                    var nonEmptyDataRows = excelWorkbook.Worksheet(1).RangeUsed().RowsUsed().Skip(1);
                    foreach (var dataRow in nonEmptyDataRows)
                    {
                        string descripcionAlmacen = dataRow.Cell("L").Value.ToString();
                        int idAlmacen = GetIdAlmacen(descripcionAlmacen);
                        string idArticulo = dataRow.Cell("C").Value.ToString();
                        int cantidadRegular = Convert.ToInt32(dataRow.Cell("E").Value);
                        DateTime fecha = Convert.ToDateTime(dataRow.Cell("A").Value);
                        item = new VentasArticulo(idAlmacen, idArticulo, cantidadRegular, fecha, descripcionAlmacen);
                        itemList.Add(item);
                    }
                }
                int mo = 0;
                int c1 = 0;
                int ae = 0;
                int nt = 0;
                int lp = 0;
                int c2 = 0;
                mo = itemList.Where(x => x.DescripcionAlmacen == "De La Cruz").Sum(x => x.CantidadRegular);
                c1 = itemList.Where(x => x.DescripcionAlmacen == "Cemain").Sum(x => x.CantidadRegular);
                ae = itemList.Where(x => x.DescripcionAlmacen == "Aeropuerto").Sum(x => x.CantidadRegular);
                nt = itemList.Where(x => x.DescripcionAlmacen == "Nuevo Tampico").Sum(x => x.CantidadRegular);
                lp = itemList.Where(x => x.DescripcionAlmacen == "LAGUNA DE LA PUERTA").Sum(x => x.CantidadRegular);
                c2 = itemList.Where(x => x.DescripcionAlmacen == "CEMAIN 2").Sum(x => x.CantidadRegular);
                var ultimaVenta = itemList.OrderByDescending(x => x.Fecha).FirstOrDefault();
                var tempItem = inventarioList.FirstOrDefault(x => x.IdArticulo == currentArticulo);
                tempItem.TotalVentasMO = mo;
                tempItem.TotalVentasC1 = c1;
                tempItem.TotalVentasAE = ae;
                tempItem.TotalVentasNT = nt;
                tempItem.TotalVentasLP = lp;
                tempItem.TotalVentasC2 = c2;
                tempItem.FechaUltimaVenta = ultimaVenta.Fecha.ToShortDateString();
                tempItem.SucursalUltimaVenta = ultimaVenta.DescripcionAlmacen;

            }
            //end foreach archivos articulos

            foreach (var fileExistencia in existenciasFiles)
            {
                using (var excelWorkbook = new XLWorkbook(fileExistencia))
                {
                    //var nonEmptyDataRows = excelWorkbook.Worksheet(1).RowsUsed();
                    var nonEmptyDataRows = excelWorkbook.Worksheet(1).RangeUsed().RowsUsed().Skip(1);
                    foreach (var dataRow in nonEmptyDataRows)
                    {
                        int idAlmacen = Convert.ToInt32(dataRow.Cell("D").Value);
                        string idArticulo = dataRow.Cell("A").Value.ToString();
                        int existencia = Convert.ToInt32(dataRow.Cell("C").Value);
                        if (inventarioList.Select(x => x.IdArticulo).Contains(idArticulo))
                        {
                            var temp = inventarioList.FirstOrDefault(x => x.IdArticulo == idArticulo);
                            switch (idAlmacen)
                            {
                                case 2:
                                    temp.TotalExistenciasMO = existencia;
                                    break;
                                case 3:
                                    temp.TotalExistenciasC1 = existencia;
                                    break;
                                case 5:
                                    temp.TotalExistenciasAE = existencia;
                                    break;
                                case 6:
                                    temp.TotalExistenciasNT = existencia;
                                    break;
                                case 8:
                                    temp.TotalExistenciasLP = existencia;
                                    break;
                                case 9:
                                    temp.TotalExistenciasC2 = existencia;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            //end foreach archivos existencias

            Console.WriteLine();
            string archivoResultado = currentFolder + "\\RESULTADO\\FORMAT-" + Path.GetFileName(mesFile);
            Directory.CreateDirectory(Path.GetDirectoryName(archivoResultado));
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add(Path.GetFileNameWithoutExtension(mesFile));

            string[] titulos = { "ARTICULO", "NOMBRE", "CANT", "V. MO", "V. C1", "V. AE", "V. NT", "V. LP", "V. C2", "EX. MO", "EX. C1", "EX. AE", "EX. NT", "EX. LP", "EX. C2", "FECHA ULTIMA VENTA", "SUCURSAL ULTIMA VENTA" };
            for (int i = 0; i < titulos.Length; i++)
            {
                ws.Cell(1, (i + 1)).Value = titulos[i];
            }

            ws.Cell(2, 1).InsertData(inventarioList.AsEnumerable());
            ws.Columns().AdjustToContents();
            wb.SaveAs(archivoResultado);
        }

        public static int GetIdAlmacen (string nombreAlmacen)
        {
            int IdAlmacen = 0;
            switch (nombreAlmacen)
            {
                case "De La Cruz":
                    IdAlmacen = 2;
                    break;
                case "Cemain":
                    IdAlmacen = 3;
                    break;
                case "Aeropuerto":
                    IdAlmacen = 5;
                    break;
                case "Nuevo Tampico":
                    IdAlmacen = 6;
                    break;
                case "LAGUNA DE LA PUERTA":
                    IdAlmacen = 8;
                    break;
                case "CEMAIN 2":
                    IdAlmacen = 9;
                    break;

            }
            return IdAlmacen;
        }

    }
}
