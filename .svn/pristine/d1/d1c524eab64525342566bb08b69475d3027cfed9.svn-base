using ClosedXML.Excel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace FuncionesCore
{
    public class FExportar
    {
        public static System.IO.MemoryStream ExportarExcel<T>(List<T> datos) where T : new()
        {
            var stream = new System.IO.MemoryStream();
            var workbook = new XLWorkbook();
            //Esto esta porque el nombre de la worksheet no puede tener mas de 31 caracteres
            string worksheetName = "";
            if (new T().GetType().Name.Length > 31)
            {
                worksheetName = new T().GetType().Name.Substring(0, 31);
            }
            else
            {
                worksheetName = new T().GetType().Name;
            }
           

            workbook.AddWorksheet(worksheetName);
            var ws = workbook.Worksheet(worksheetName);

            //inmovilizo la primer fila
            ws.SheetView.FreezeRows(1);

            var properties = new T().GetType().GetProperties().Where(x => x.PropertyType.Name != typeof(List<>).Name);

            //creo los encabezados
            int row = 1;
            int col = 0;
            foreach (PropertyInfo prop in properties)
            {
                if (col < 26)
                {
                    ws.Cell(System.Char.ConvertFromUtf32('A' + col) + "1").Value = prop.Name;
                    ws.Cell(System.Char.ConvertFromUtf32('A' + col) + "1").Style.Fill.BackgroundColor = XLColor.Navy;
                    ws.Cell(System.Char.ConvertFromUtf32('A' + col) + "1").Style.Font.Bold = true;
                    ws.Cell(System.Char.ConvertFromUtf32('A' + col) + "1").Style.Font.FontColor = XLColor.White;
                }
                else
                {
                    if (col < 52)
                    {
                        ws.Cell("A" + System.Char.ConvertFromUtf32('A' + col - 52) + "1").Value = prop.Name;
                        ws.Cell("A" + System.Char.ConvertFromUtf32('A' + col - 52) + "1").Style.Fill.BackgroundColor = XLColor.Navy;
                        ws.Cell("A" + System.Char.ConvertFromUtf32('A' + col - 52) + "1").Style.Font.Bold = true;
                        ws.Cell("A" + System.Char.ConvertFromUtf32('A' + col - 52) + "1").Style.Font.FontColor = XLColor.White;
                    }
                    else
                    {
                        ws.Cell("A" + System.Char.ConvertFromUtf32('A' + col - 26) + "1").Value = prop.Name;
                        ws.Cell("A" + System.Char.ConvertFromUtf32('A' + col - 26) + "1").Style.Fill.BackgroundColor = XLColor.Navy;
                        ws.Cell("A" + System.Char.ConvertFromUtf32('A' + col - 26) + "1").Style.Font.Bold = true;
                        ws.Cell("A" + System.Char.ConvertFromUtf32('A' + col - 26) + "1").Style.Font.FontColor = XLColor.White;
                    }
                 
                }
                col++;
            }

            //lleno cada fila
            row = 2;
            foreach (T item in datos)
            {
                col = 0;
                foreach (PropertyInfo prop in properties)
                {
                    string value = "";
                    if (prop.GetValue(item) != null)
                    {
                        value = prop.GetValue(item).ToString();
                    }

                    if (col < 26)
                    {
                        ws.Cell(System.Char.ConvertFromUtf32('A' + col) + row.ToString()).Value = value;
                    }
                    else
                    {
                        ws.Cell("A" + System.Char.ConvertFromUtf32('A' + col - 26) + row.ToString()).Value = value;
                    }

                    col++;
                }
                row++;
            }

            //Ajusto las columnas al ancho del contenido
            ws.Columns().AdjustToContents();

            workbook.SaveAs(stream);
            //workbook.SaveAs("test.xlsx");

            return stream;
        }

        public static ExcellData ImportarExcel(string pPath,int pFilas, int pColumnas)
        {
            ExcellData data = new ExcellData(pFilas+1, pColumnas+1);
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

            int rowCounter = 2;
            int columnCounter = 1;
            bool emptyRow = false;
            bool emptyCell = false;
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
                            if (cell.Value.ToString() != "")
                            {
                                data.Set(rowCounter, columnCounter, cell.Value.ToString());
                            }
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

        public class ExcellData
        {
            public ExcellData(int pRows, int pColumns)
            {
                _data = new string[pRows,pColumns];
            }

            private string[,] _data { get; set; }
           

            public void Set(int row, int column,string data)
            {
                _data[row,column] = data;
            }

            public string Get(int row, int column)
            {
                return _data[row,column];
            }
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


    }


}
