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
                return $@"'<img src=""products/{cell}"" width=""100"" height=""50""/>'";
            }
        }

        static string ParseExcelRow(string cell)
        {
            return cell.Replace("\n", "<br/>");
        }


        static string GetUrlData(ISheet sheet, int rowNum, int col)
        {
            StringBuilder sb = new StringBuilder("");
            for (int i = 0; i < MaxUrlCount; i++)
            {

                try
                {
                    ICell cell = sheet.GetRow(rowNum++).Cells[col];
                    if ((cell == null) || (cell.Hyperlink == null) || (string.IsNullOrWhiteSpace(cell.ToString())))
                    {
                        return sb.ToString();
                    }
                    sb.AppendLine($@"<a href='{cell.Hyperlink}'> {cell.ToString()}</a><br/>");
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    return sb.ToString();
                }
            }
            return sb.ToString();
        }

        static void Main(string[] args)
        {


           string header = @"<html xmlns = ""http://www.w3.org/1999/xhtml"">
<head>
    <meta http-equiv = ""Content-Type"" content=""text / html; charset = UTF-8"" />
                   <title> Product Comparison</title>
                      <link href = 'https://fonts.googleapis.com/css?family=Lato:400,700' rel = 'stylesheet' type = 'text/css' >
                      <link rel=""stylesheet"" href=""css/normalize.min.css"" >
                      <link rel=""stylesheet"" href=""css/animate.min.css"" >
                      <link rel=""stylesheet"" href=""css/comparison.css"" >
</head>
<body>
    <a id=""compare"" href=""#animatedModal"" disabled class=""compare-products"">Compare Products</a>
	<div class=""container"">";
            StringBuilder fileContents = new StringBuilder(header);


            XSSFWorkbook hssfwb;
            using (
                FileStream file =
                    new FileStream(@"..\..\..\..\DI Comparison Chart.xlsx",
                        FileMode.Open, FileAccess.Read))
            {

              
                hssfwb = new XSSFWorkbook(file);

                ISheet sheet = hssfwb[0];
                IRow firstRow = sheet.GetRow(0);
                int lastColNum = firstRow.Cells.Count(cell => !string.IsNullOrWhiteSpace(cell.ToString()));
                int i = 1;


                for (int col = 1; col < lastColNum; col++) //start at 1 to skip over labels
                {
                    int rowNum = 0;
                    StringBuilder sb = new StringBuilder($@"<div class=""product"" data-id=""{i++}"" ");
                    // IRow row = sheet.GetRow(rowNum++);
                    sb.AppendLine($@"data-title=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-model=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-vendor=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-technology=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-wavelength=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-depth=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-power=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-film=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-soldermask=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-speed=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-edge=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-positional=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-registration=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-line=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    string line2Img = ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString());
                    sb.AppendLine($@"data-line2={GetImage(line2Img)}");
                    sb.AppendLine($@"data-df=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-hole=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-hole2=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-sro=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-sr=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-address=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-min=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-max=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-panel=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-handling=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" "); 
                    sb.AppendLine($@"data-machine=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-models=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-double=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-expected=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-warranty=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-warranty2=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-mechanical=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-autofocus=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-panel2=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-non-linear=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}"" ");
                    sb.AppendLine($@"data-url=""{GetUrlData(sheet, rowNum, col)}""");
                    rowNum += MaxUrlCount;
                        //                    sb.AppendLine($@"data-url=""<a href='{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}'>Click Here</a>""");
                    sb.AppendLine($@"data-notes=""{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}""");
                    sb.AppendLine($@"data-video=""<a href='{ParseExcelRow(sheet.GetRow(rowNum++).Cells[col].ToString())}'>Click Here</a>""");
                    sb.AppendLine(@">");
                    sb.AppendLine($@"<button><div>+</div></button>");
                    sb.AppendLine($@"<img src = ""products/{sheet.GetRow(26).Cells[col]}"" onerror=""this.src='products/none.png'"" width=""250px"" height=""230px"" class=""product-image"" />");
                    sb.AppendLine($@"<h3 class=""text-center"">{ParseExcelRow(sheet.GetRow(0).Cells[col].ToString())}</h3>"); //machine
                    sb.AppendLine($@"<p class=""description"">{ParseExcelRow(sheet.GetRow(2).Cells[col].ToString())}</p>"); //vendor
 //                   sb.AppendLine($@"<p class=""description"">{sheet.GetRow(3).Cells[col]}</p>"); //technology
                    sb.AppendLine("</div>");
                    fileContents.Append(sb);
                }
            }


            string footer = @"<div id= ""animatedModal"">
					<div id = ""btn-close-modal"" class=""close-animatedModal"">
						CLOSE
                    </div>
					<div class=""modal-content"">
						<div class=""modal-inner"">
							<div class=""no-products"">Select some products to compare first</div>
							<div class=""modal-products""></div>
						</div>
					</div>
				</div>
				</div>
</body>
<script type = ""text/javascript"" src=""https://ajax.googleapis.com/ajax/libs/jquery/2.2.0/jquery.min.js""></script>
<script type = ""text/javascript"" src=""js/jquery.comparison.js""></script>
<script type = ""text/javascript"" src=""js/animatedModal.js""></script>
<script>
	$(""#compare"").animatedModal({

		animatedIn: 'lightSpeedIn',
		animatedOut: 'bounceOutDown',
		color: '#3498db',

	});

	$(document).ready(function ()
    {

		$('.product').compare({
            compareButton: '.compare-products'

        });


    });
</script>
<!-- Tutorial JS END -->
</html>";
            fileContents.Append(footer);
            File.WriteAllText(@"..\..\..\..\index.html", fileContents.ToString());
        }
    }
}