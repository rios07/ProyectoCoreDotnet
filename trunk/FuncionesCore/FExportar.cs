using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClosedXML.Excel;

namespace FuncionesCore
{
    public class FExportar
    {
        public static MemoryStream ExportarExcel<T>(List<T> datos) where T : new()
        {
            var stream = new MemoryStream();
            var workbook = new XLWorkbook();
            //Esto esta porque el nombre de la worksheet no puede tener mas de 31 caracteres
            var worksheetName = "";
            if (new T().GetType().Name.Length > 31)
                worksheetName = new T().GetType().Name.Substring(0, 31);
            else
                worksheetName = new T().GetType().Name;


            workbook.AddWorksheet(worksheetName);
            var ws = workbook.Worksheet(worksheetName);

            //inmovilizo la primer fila
            ws.SheetView.FreezeRows(1);

            var properties = new T().GetType().GetProperties().Where(x => x.PropertyType.Name != typeof(List<>).Name);

            //creo los encabezados
            var row = 1;
            var col = "A";
            foreach (var prop in properties)
            {

                ws.Cell(col + "1").Value = prop.Name;
                ws.Cell(col + "1").Style.Fill.BackgroundColor = XLColor.Navy;
                ws.Cell(col + "1").Style.Font.Bold = true;
                ws.Cell(col + "1").Style.Font.FontColor = XLColor.White;

                col = FStrings.IncrementString(col);
            }

            //lleno cada fila
            row = 2;
            foreach (var item in datos)
            {
                col = "A";
                foreach (var prop in properties)
                {
                    var value = "";
                    if (prop.GetValue(item) != null) value = prop.GetValue(item).ToString();


                    ws.Cell(col + row).Value = value;

                    col = FStrings.IncrementString(col);
                }

                row++;
            }

            //Ajusto las columnas al ancho del contenido
            ws.Columns().AdjustToContents();

            workbook.SaveAs(stream);
            //workbook.SaveAs("test.xlsx");

            return stream;
        }

        public static ExcellData ImportarExcel(string pPath, int pFilas, int pColumnas)
        {
            var data = new ExcellData(pFilas + 1, pColumnas + 1);
            var workbook = new XLWorkbook(pPath);
            var worksheet = workbook.Worksheet(1);
            //for (int r = 2; r < 19; r++)
            //{
            //    var row = worksheet.Row(r);
            //    for (int c = 1; c < 14; c++)
            //    {
            //        var cell = row.Cell(c);
            //        if (cell.Value.ToString() != "")
            //        {
            //            data.Set(r, c, cell.Value.ToString());
            //        }
            //    }
            //}

            var rowCounter = 2;
            var columnCounter = 1;
            var emptyRow = false;
            var emptyCell = false;
            while (!emptyRow)
            {
                var row = worksheet.Row(rowCounter);
                if (row.IsEmpty())
                {
                    emptyRow = true;
                }
                else
                {
                    while (!emptyCell)
                    {
                        var cell = row.Cell(columnCounter);
                        if (cell.IsEmpty())
                        {
                            emptyCell = true;
                        }
                        else
                        {
                            if (cell.Value.ToString() != "") data.Set(rowCounter, columnCounter, cell.Value.ToString());
                            columnCounter++;
                        }
                    }

                    columnCounter = 1;
                    emptyCell = false;
                    rowCounter++;
                }
            }

            return data;
        }

        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public class ExcellData
        {
            public ExcellData(int pRows, int pColumns)
            {
                _data = new string[pRows, pColumns];
            }

            private string[,] _data { get; }


            public void Set(int row, int column, string data)
            {
                _data[row, column] = data;
            }

            public string Get(int row, int column)
            {
                return _data[row, column];
            }
        }
    }
}