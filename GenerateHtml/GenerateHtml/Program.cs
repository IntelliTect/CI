using System;
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

            Console.WriteLine(header);

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
                    sb.AppendLine($@"data-title=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-model=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-vendor=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-technology=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-wavelength=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-depth=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-power=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-film=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-soldermask=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-speed=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-edge=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-positional=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-registration=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-line=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    string line2Img = sheet.GetRow(rowNum++).Cells[col].ToString();
                    sb.AppendLine($@"data-line2={GetImage(line2Img)}");
                    sb.AppendLine($@"data-df=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-hole=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-hole2=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-sro=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-sr=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-address=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-min=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-max=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-panel=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-handling=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" "); 
                    sb.AppendLine($@"data-machine=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-models=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-double=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-expected=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-warranty=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-warranty2=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-mechanical=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-autofocus=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-panel2=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-non-linear=""{sheet.GetRow(rowNum++).Cells[col].ToString()}"" ");
                    sb.AppendLine($@"data-url=""<a href='{sheet.GetRow(rowNum++).Cells[col].ToString()}'>Click Here</a>""");
                    sb.AppendLine($@"data-notes=""{sheet.GetRow(rowNum++).Cells[col].ToString()}""");
                    sb.AppendLine($@"data-video=""<a href='{sheet.GetRow(rowNum++).Cells[col].ToString()}'>Click Here</a>""");
                    sb.AppendLine(@">");
                    sb.AppendLine($@"<button><div>+</div></button>");
                    sb.AppendLine($@"<img src = ""products/1.png"" class=""product-image"" />");
                    sb.AppendLine($@"<h3 class=""text-center"">{sheet.GetRow(0).Cells[col]}</h3>"); //machine
                    sb.AppendLine($@"<p class=""description"">{sheet.GetRow(2).Cells[col]}</p>"); //vendor
 //                   sb.AppendLine($@"<p class=""description"">{sheet.GetRow(3).Cells[col]}</p>"); //technology
                    sb.AppendLine("</div>");

                    Console.WriteLine(sb);
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
            Console.WriteLine(footer);
        }
    }
}