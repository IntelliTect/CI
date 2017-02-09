using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;


namespace GenerateHtml
{
    class Program
    {
        private static int MaxUrlCount = 6;

        static string GetImage(string cell)
        {
            if (string.IsNullOrWhiteSpace(cell))
            {
                return @"""""";
            }
            else
            {
                return $@"'<img src=""products/{cell}"" width=""200"" height=""100""/>'";
            }
        }

        static string ParseExcelRow(string cell)
        {
            return cell.Replace("\n", "</br>").Replace("\"", "\\\"");
        }

        static string ParseUrl(ICell cell)
        {
            if ((cell == null) || (cell.Hyperlink == null) || (string.IsNullOrWhiteSpace(cell.ToString())))
            {
                return null;
            }
            return $@"<a href='{cell.Hyperlink.Address}'> {cell.ToString()}</a><br/>";
        }

        static void Main(string[] args)
        {
            string excelFile = @"..\..\..\..\DI Comparison Chart.xlsx";
            if (args.Length > 0)
            {
                excelFile = args[0];
            }
            Console.WriteLine("using excel file: " + excelFile);


            var data = new StringBuilder();

            XSSFWorkbook hssfwb;
            using (
                FileStream file =
                    new FileStream(excelFile,
                        FileMode.Open, FileAccess.Read))
            {

              
                hssfwb = new XSSFWorkbook(file);

                ISheet sheet = hssfwb[0];
                IRow firstRow = sheet.GetRow(0);
                int lastColNum = firstRow.Cells.Count(cell => !string.IsNullOrWhiteSpace(cell.ToString()));
                int i = 1;

                int lastRow = sheet.LastRowNum; 

                data.AppendLine("var headers = [");

                for (int row = 0; row < lastRow; row++)
                {
                    data.Append('"');
                    data.Append(ParseExcelRow(sheet.GetRow(row).Cells[0].ToString()));
                    data.AppendLine("\",");
                }
                data.Append("];");
                data.AppendLine();
                data.AppendLine();

                data.Append("var products = [");

                for (int col = 1; col < lastColNum; col++) //start at 1 to skip over labels
                {
                    data.Append("{ checked: ko.observable(false), data: [");

                    for (int row = 0; row < lastRow; row++)
                    {
                        //var rowName = sheet.GetRow(row).Cells[0].ToString();
                        //if (rowName == "URL")
                        //{

                        //}

                        data.Append('"');

                        var cell = sheet.GetRow(row).GetCell(col);
                        if (cell == null)
                        {
                            // output nothing
                        }
                        else
                        {
                            var url = ParseUrl(cell);
                            if (url != null)
                            {
                                data.Append(url);
                            }
                            else
                            {
                                var contents = ParseExcelRow(cell.ToString());
                                data.Append(contents);
                            }
                        }

                        data.AppendLine("\",");
                    }

                    data.AppendLine("]},");
                }

                data.AppendLine("];");

                data.AppendLine(@"
                    model = {headers: headers, products: products};
                ");
            }

            File.WriteAllText(@"..\..\..\..\data.js", data.ToString());
        }
    }
}