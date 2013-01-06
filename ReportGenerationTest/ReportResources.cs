using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportGenerationTest
{
	public class ReportResources
	{
		public string Name { get; set; }

		public string Script { get; set; }

		/// <summary>
		/// jch! see if mindscape sass supports embedding binary in the css
		/// or just build a parser for url(name) and inserting the binary
		/// </summary>
		public string ThemeCSS { get; set; } // 


		public string TemplatePath { get; set; }
	}
}
