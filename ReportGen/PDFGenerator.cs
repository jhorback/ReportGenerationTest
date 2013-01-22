using System.Drawing;
using System.IO;
using System.Text;
using org.zefer.pd4ml;

namespace ReportGen
{
	public class PDFGenerator
	{
		public void GeneratPDF(string reportHTML, string outputFilePath)
		{
			var pd4ml = new PD4ML
			    {
			        HtmlWidth = 1024,
					PageSize = PD4Constants.A1,
					PageInsets = new Rectangle(0, 0, 0, 0)
			    };


			var instream = new MemoryStream(Encoding.ASCII.GetBytes(reportHTML));
			var outstream = new FileStream(outputFilePath, FileMode.Create);
			pd4ml.render(instream, outstream);
			instream.Close();
			outstream.Close();
		}
	}
}
