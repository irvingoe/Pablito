using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace Pablito
{
    public partial class Ultron : Form
    {
        public Ultron()
        {
            InitializeComponent();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "E://SampleProjects";
            openFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx";
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog1.FileName;
                archivoOrigenRuta.Text = FileName;
            }
        }

        private void Go_Click(object sender, EventArgs e)
        {
            //Este es un estilo "Default" aplicado a todo el archivo
            //al chile nomas le puse el numero de letra por que luego se puede sobreescribir alguna propiedad como los bordes y creo que truena a chsm
            var style = XLWorkbook.DefaultStyle;
            style.Font.FontSize = 9;

            var workbook = new XLWorkbook();

            var worksheet = workbook.Worksheets.Add("Inventario");
            worksheet.PageSetup.Margins.Top = .5;
            worksheet.PageSetup.Margins.Bottom = .5;
            worksheet.PageSetup.Margins.Left = 0.5;
            worksheet.PageSetup.Margins.Right = 0.75;
            worksheet.PageSetup.Margins.Footer = 0.15;
            worksheet.PageSetup.Margins.Header = 0.30;

            //El Split busca comas en el texto y crea un arreglo de elementos delimitados por la coma
            //var ejemplo = "1,2,3,4,5,6"
            //ejemplo.Split(',')
            //resultado = {[1],[2], ...}
            var filtro = textFiltro.Text.Split(',');
            int min = 0, max = 0;
            if (textFiltro2.Text != "")
            {
                var filtro2 = textFiltro2.Text.Split('-');
                min = int.Parse(filtro2[0]);
                max = int.Parse(filtro2[1]);
            }

            if (archivoOrigenRuta.Text.Length > 0)
            {
                var ArchivoExcel = new XLWorkbook(archivoOrigenRuta.Text);
                var Hoja1 = ArchivoExcel.Worksheet(1);
                var PrimeraFila = Hoja1.FirstRow().RowUsed(); //Esto son los titulos
                var SiguienteFila = PrimeraFila.RowBelow();
                int FilaActual = 2;
                bool hiceAlgo = false;

                while (!SiguienteFila.IsEmpty())
                {
                    var CeldaActual = SiguienteFila.Cell(1);
                    /*
                     * Aqui usare el "filtro" leyendo la primera celda (Articulo, pero solo tomo los primeros 2 digitos) 
                     * y checando si en el arreglo filtro existe ese valor con el metodo contains
                     * ejemplo...
                     * valor de Celda = "010000XXX" tomo los dos caracteres
                     * 2digitos = "01"
                     * {[01],[02], ...} Contiene a "01"?, en caso verdadero haz todo tu desmadre
                     * sino pues cortatela y siguele con la siguiente fila
                     */   //(filtro2.Contains(CeldaActual.GetValue<String>().Substring(3, 7))) 
                    if (filtro.Contains(CeldaActual.GetString().Substring(0, 2)))
                    {
                        if (textFiltro2.Text != "")
                        {
                            //Inicio filtro2 logic
                            if (CeldaActual.GetString().Substring(0, 2) == "03")
                            {
                                var cincoNumeros = CeldaActual.GetString().Substring(2, 5);
                                var iCinco = int.Parse(cincoNumeros);
                                if (!(iCinco >= min && iCinco <= max))
                                {
                                    //Esta condicion es para omitir este valor y saltar a la siguiente fila
                                    SiguienteFila = SiguienteFila.RowBelow();
                                    continue;
                                }
                            }
                        }
                        hiceAlgo = true;
                        FilaActual += 1;
                        while (!CeldaActual.CellRight().IsEmpty() && CeldaActual.Address.ColumnNumber < 4)
                        {
                            var Celda = CeldaActual;
                            var valorCeldaActual = Celda.GetValue<String>();
                            if (Celda.Address.ColumnNumber == 1) //Si es la primera columna aka Articulo
                            {
                                //este codigo ya no sera necesario pero lo dejare como referencia
                                //if (FilaActual.RowNumber() == 1)
                                //{
                                //    worksheet.Cell("A" + FilaActual.RowNumber()).Value = "SUBFAMILIA";
                                //    worksheet.Cell(FilaActual.RowNumber(), CeldaActual.Address.ColumnNumber).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                                //}
                                //else
                                //{

                                //}
                                worksheet.Cell("A" + FilaActual).Value = valorCeldaActual.Substring(0, 7);
                                worksheet.Cell(FilaActual, CeldaActual.Address.ColumnNumber).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                                worksheet.Cell("A" + FilaActual).DataType = XLCellValues.Text;
                            }

                            //Aqui empiezas a hacer tu desmadre con la informacion
                            var DatosCelda = valorCeldaActual;
                            worksheet.Cell(FilaActual, CeldaActual.Address.ColumnNumber + 1).Value = DatosCelda;
                            worksheet.Cell(FilaActual, CeldaActual.Address.ColumnNumber + 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            worksheet.Cell(FilaActual, CeldaActual.Address.ColumnNumber + 1).DataType = XLCellValues.Text;

                            CeldaActual = CeldaActual.CellRight();
                        }

                    }
                    SiguienteFila = SiguienteFila.RowBelow();
                }
                //wea pa guardar el archivo en un lugar que tu le digas :D
                if (hiceAlgo)
                {
                    SaveFileDialog saveFileDialog2 = new SaveFileDialog();
                    saveFileDialog2.FileName = "*";
                    saveFileDialog2.DefaultExt = "xlsx";
                    saveFileDialog2.ValidateNames = true;
                    saveFileDialog2.Filter = "Excel File (.xlsx|*.xlsx";
                    openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
                    if (saveFileDialog2.ShowDialog(this) == DialogResult.OK)
                    {
                        string FileName = saveFileDialog2.FileName;
                        archivoDestinoRuta.Text = FileName;

                        //Ancho de columnas
                        worksheet.Columns(1, 2).Width = 12;
                        worksheet.Column(3).Width = 55;
                        worksheet.Columns(4, 7).Width = 6;

                        //Ordenado
                        //1,3 significa...
                        //Ordena basandote en la primera columna (SUBFAMILIA) y despues ordena el resultado basado en la tercera columna (DESCRIPCION)
                        //Ascending signfica orden ascendente 1, 2, 3... A, B, C...
                        worksheet.Sort("1, 3", XLSortOrder.Ascending);

                        //Footer aka pie de pagina
                        // Let's put the current page number and total pages on the center of every footer:
                        worksheet.PageSetup.Footer.Center.AddText(XLHFPredefinedText.PageNumber, XLHFOccurrence.AllPages);
                        worksheet.PageSetup.Footer.Center.AddText(" de ", XLHFOccurrence.AllPages);
                        worksheet.PageSetup.Footer.Center.AddText(XLHFPredefinedText.NumberOfPages, XLHFOccurrence.AllPages);
                        // Let's put the full path to the file on the right footer of every odd page:
                        worksheet.PageSetup.Footer.Right.AddText("This is a Jarvis creation.");
                        worksheet.Column("A").Delete(); // Range starts on C2
                                                        //worksheet.Column(3).InsertColumnsAfter(3); // Range starts on C2

                        //Insertar titulos
                        worksheet.Cell(2, 1).Value = "ARTICULO";
                        worksheet.Cell(2, 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell(2, 2).Value = "NOMBRE";
                        worksheet.Cell(2, 2).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell(2, 3).Value = "EX";
                        worksheet.Cell(2, 3).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                        System.Globalization.DateTimeFormatInfo FormatInfo = new System.Globalization.DateTimeFormatInfo();
                        worksheet.Cell(2, 4).Value = FormatInfo.GetAbbreviatedMonthName(DateTime.Now.AddMonths(1).Month).Substring(0, 3).ToUpper();
                        worksheet.Cell(2, 4).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell(2, 5).Value = FormatInfo.GetAbbreviatedMonthName(DateTime.Now.AddMonths(2).Month).Substring(0, 3).ToUpper();
                        worksheet.Cell(2, 5).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell(2, 6).Value = FormatInfo.GetAbbreviatedMonthName(DateTime.Now.AddMonths(3).Month).Substring(0, 3).ToUpper();
                        worksheet.Cell(2, 6).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                        worksheet.CellsUsed().Style.Border.OutsideBorder = XLBorderStyleValues.Thin;


                        //Insertar encabezados
                        worksheet.Cell(1, 1).Value = textEncabezado.Text;
                        worksheet.Range("A1:C1").Row(1).Merge();
                        worksheet.Cell("A1").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        worksheet.Cell("A1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        worksheet.Cell(1, 4).Value = "CADUCIDAD";
                        worksheet.Range("D1:F1").Row(1).Merge();
                        worksheet.Cell("D1").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        worksheet.Cell("D1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        worksheet.RowsUsed()
                            .Select(r => r.Cells(1, 6))
                            .ForEach(c => c.Style.Border.OutsideBorder = XLBorderStyleValues.Thin);

                        workbook.SaveAs(FileName);
                        MessageBox.Show("Completado exitosamente.");
                    }
                    //opcional lo de arriba

                }
                else
                {
                    MessageBox.Show("No se realizo ninguna operacion, no se encontraron coincidencias con el filtro seleccionado");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un archivo antes de continuar :D");
            }

        }

        //Test("03", 1, 100, "C:\Carpeta\Archivo Origen.xlsx", "C:\Carpeta\Archivo Destino.xlsx")
        private void Test(string valorFiltro1, int min, int max, string archivoOrigen, string archivoDestino)
        {
            //filtro 1 (separado por comas) = 03
            //filtro 2 = 0-54...
            //archivoOrigen = string
            //archivoDestino = string


            //Este es un estilo "Default" aplicado a todo el archivo
            //al chile nomas le puse el numero de letra por que luego se puede sobreescribir alguna propiedad como los bordes y creo que truena a chsm
            var style = XLWorkbook.DefaultStyle;
            style.Font.FontSize = 9;

            var workbook = new XLWorkbook();

            var worksheet = workbook.Worksheets.Add("Inventario");
            worksheet.PageSetup.Margins.Top = .5;
            worksheet.PageSetup.Margins.Bottom = .5;
            worksheet.PageSetup.Margins.Left = 0.5;
            worksheet.PageSetup.Margins.Right = 0.75;
            worksheet.PageSetup.Margins.Footer = 0.15;
            worksheet.PageSetup.Margins.Header = 0.30;

            var ArchivoExcel = new XLWorkbook(archivoOrigen);
            var Hoja1 = ArchivoExcel.Worksheet(1);
            var PrimeraFila = Hoja1.FirstRow().RowUsed(); //Esto son los titulos
            var SiguienteFila = PrimeraFila.RowBelow();
            int FilaActual = 2;
            bool hiceAlgo = false;

            while (!SiguienteFila.RowBelow().IsEmpty() && !SiguienteFila.IsEmpty())
            {
                var CeldaActual = SiguienteFila.Cell(1);
                /*
                 * Aqui usare el "filtro" leyendo la primera celda (Articulo, pero solo tomo los primeros 2 digitos) 
                 * y checando si en el arreglo filtro existe ese valor con el metodo contains
                 * ejemplo...
                 * valor de Celda = "010000XXX" tomo los dos caracteres
                 * 2digitos = "01"
                 * {[01],[02], ...} Contiene a "01"?, en caso verdadero haz todo tu desmadre
                 * sino pues cortatela y siguele con la siguiente fila
                 */   //(filtro2.Contains(CeldaActual.GetValue<String>().Substring(3, 7))) 
                if (CeldaActual.GetString().Substring(0, 2) == valorFiltro1)
                {
                    var cincoNumeros = CeldaActual.GetString().Substring(2, 5);
                    var iCinco = int.Parse(cincoNumeros);
                    if (!(iCinco >= min && iCinco <= max))
                    {
                        //Esta condicion es para omitir este valor y saltar a la siguiente fila
                        SiguienteFila = SiguienteFila.RowBelow();
                        continue;
                    }
                    hiceAlgo = true;
                    FilaActual += 1;
                    while (!CeldaActual.CellRight().IsEmpty() && CeldaActual.Address.ColumnNumber < 4)
                    {
                        var Celda = CeldaActual;
                        var valorCeldaActual = Celda.GetValue<String>();
                        if (Celda.Address.ColumnNumber == 1) //Si es la primera columna aka Articulo
                        {
                            //este codigo ya no sera necesario pero lo dejare como referencia
                            //if (FilaActual.RowNumber() == 1)
                            //{
                            //    worksheet.Cell("A" + FilaActual.RowNumber()).Value = "SUBFAMILIA";
                            //    worksheet.Cell(FilaActual.RowNumber(), CeldaActual.Address.ColumnNumber).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            //}
                            //else
                            //{

                            //}
                            worksheet.Cell("A" + FilaActual).Value = valorCeldaActual.Substring(0, 7);
                            worksheet.Cell(FilaActual, CeldaActual.Address.ColumnNumber).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            worksheet.Cell("A" + FilaActual).DataType = XLCellValues.Text;
                        }

                        //Aqui empiezas a hacer tu desmadre con la informacion
                        var DatosCelda = valorCeldaActual;
                        worksheet.Cell(FilaActual, CeldaActual.Address.ColumnNumber + 1).Value = DatosCelda;
                        worksheet.Cell(FilaActual, CeldaActual.Address.ColumnNumber + 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell(FilaActual, CeldaActual.Address.ColumnNumber + 1).DataType = XLCellValues.Text;

                        CeldaActual = CeldaActual.CellRight();
                    }

                }
                SiguienteFila = SiguienteFila.RowBelow();
            }
            //wea pa guardar el archivo en un lugar que tu le digas :D
            if (hiceAlgo)
            {

                string FileName = archivoDestino;
                archivoDestinoRuta.Text = FileName;

                //Ancho de columnas
                worksheet.Columns(1, 2).Width = 12;
                worksheet.Column(3).Width = 55;
                worksheet.Columns(4, 7).Width = 6;

                //Ordenado
                //1,3 significa...
                //Ordena basandote en la primera columna (SUBFAMILIA) y despues ordena el resultado basado en la tercera columna (DESCRIPCION)
                //Ascending signfica orden ascendente 1, 2, 3... A, B, C...
                worksheet.Sort("1, 3", XLSortOrder.Ascending);

                //Footer aka pie de pagina
                // Let's put the current page number and total pages on the center of every footer:
                worksheet.PageSetup.Footer.Center.AddText(XLHFPredefinedText.PageNumber, XLHFOccurrence.AllPages);
                worksheet.PageSetup.Footer.Center.AddText(" de ", XLHFOccurrence.AllPages);
                worksheet.PageSetup.Footer.Center.AddText(XLHFPredefinedText.NumberOfPages, XLHFOccurrence.AllPages);
                // Let's put the full path to the file on the right footer of every odd page:
                worksheet.PageSetup.Footer.Right.AddText("This is a Jarvis creation.");
                worksheet.Column("A").Delete(); // Range starts on C2
                                                //worksheet.Column(3).InsertColumnsAfter(3); // Range starts on C2

                //Insertar titulos
                worksheet.Cell(2, 1).Value = "ARTICULO";
                worksheet.Cell(2, 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(2, 2).Value = "NOMBRE";
                worksheet.Cell(2, 2).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(2, 3).Value = "EX";
                worksheet.Cell(2, 3).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                System.Globalization.DateTimeFormatInfo FormatInfo = new System.Globalization.DateTimeFormatInfo();
                worksheet.Cell(2, 4).Value = FormatInfo.GetAbbreviatedMonthName(DateTime.Now.AddMonths(1).Month).Substring(0, 3).ToUpper();
                worksheet.Cell(2, 4).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(2, 5).Value = FormatInfo.GetAbbreviatedMonthName(DateTime.Now.AddMonths(2).Month).Substring(0, 3).ToUpper();
                worksheet.Cell(2, 5).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(2, 6).Value = FormatInfo.GetAbbreviatedMonthName(DateTime.Now.AddMonths(3).Month).Substring(0, 3).ToUpper();
                worksheet.Cell(2, 6).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                worksheet.CellsUsed().Style.Border.OutsideBorder = XLBorderStyleValues.Thin;


                //Insertar encabezados
                //worksheet.Cell(1, 1).Value = Button.Text;
                worksheet.Cell(1, 1).Value = textEncabezado.Text;
                worksheet.Range("A1:C1").Row(1).Merge();
                worksheet.Cell("A1").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                worksheet.Cell("A1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                worksheet.Cell(1, 4).Value = "CADUCIDAD";
                worksheet.Range("D1:F1").Row(1).Merge();
                worksheet.Cell("D1").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                worksheet.Cell("D1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.RowsUsed()
                    .Select(r => r.Cells(1, 6))
                    .ForEach(c => c.Style.Border.OutsideBorder = XLBorderStyleValues.Thin);

                workbook.SaveAs(FileName);
                MessageBox.Show("Completado exitosamente.");

                //opcional lo de arriba
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {

        }

        private void minombreClick(object sender, EventArgs e)
        {

        }

        private void archivoOrigenRuta_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void archivoDestinoRuta_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.archivoOrigenRuta.Clear();
            this.textFiltro.Clear();
            this.textEncabezado.Clear();
            this.archivoDestinoRuta.Clear();
        }

        private void textFiltro_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Test("03", 1, 84, "C:\\Users\\JP\\Documents\\Visual Studio 2015\\Projects\\Pablito\\Pablito\\bin\\Debug\\EXISTENCIAS C1.xlsx", String.Format("C:\\Users\\JP\\Documents\\Visual Studio 2015\\Projects\\Pablito\\Pablito\\bin\\Debug\\INV C1 HELEN {0:dd'-'MM'-'yyyy}.xlsx", DateTime.Now));
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Test("03", 85, 230, "C:\\Users\\JP\\Documents\\Visual Studio 2015\\Projects\\Pablito\\Pablito\\bin\\Debug\\EXISTENCIAS C1.xlsx", String.Format("C:\\Users\\JP\\Documents\\Visual Studio 2015\\Projects\\Pablito\\Pablito\\bin\\Debug\\INV C1 NERY {0:dd'-'MM'-'yyyy}.xlsx", DateTime.Now));
            //Environment.CurrentDirectory;
            
    }

    }
}

