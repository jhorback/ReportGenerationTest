
namespace ReportGen
{
	public class Report
	{
		public Report()
		{
			ScriptFile = "report.min.js";
			TemplateFile = "report.html";
			TemplateLayoutFile = "/layouts/layout.html";
			ThemeFile = "/themes/default/theme.css";
		}

		public string Key { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string ReportDir { get; set; }

		/// <summary>
		/// The defualt is /themes/default/theme.css
		/// </summary>
		public string ThemeFile { get; set; }

		/// <summary>
		/// The default is report.js
		/// </summary>
		public string ScriptFile { get; set; }

		/// <summary>
		/// The default is report.html
		/// </summary>
		public string TemplateFile { get; set; }

		/// <summary>
		/// The default is /layouts/layout.html
		/// </summary>
		public string TemplateLayoutFile { get; set; }


		public string GetThemeResourcePath()
		{
			return ReportDir + ";" + ThemeFile;
		}

		public string GetScriptResourcePath()
		{
			return ReportDir + ";" + ScriptFile;
		}

		public string GetTemplateResourcePath()
		{
			return ReportDir + ";" + TemplateFile;
		}

		public string GetLayoutTemplateResourcePath()
		{
			return ReportDir + ";" + TemplateLayoutFile;
		}
	}
}
