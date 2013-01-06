using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ReportGenerationTest
{
	public class ReportResourcesRepository
	{
		List<ReportResources> reports = null;
 
		public List<ReportResources> FindAllReports()
		{
			return reports ?? (reports = loadReportResources());
		}

		public ReportResources FindReport(string name)
		{
			return FindAllReports().FirstOrDefault(r => String.Compare(r.Name.ToLower(), name.ToLower(), StringComparison.OrdinalIgnoreCase) == 0);
		}


		List<ReportResources> loadReportResources()
		{
			var reports = new List<ReportResources>();
			var dir = new DirectoryInfo(ReportsDir);
			foreach (var folder in dir.GetDirectories())
			{
				var streamReader = new StreamReader(folder.FullName + "\\report.js");
				string scriptText = streamReader.ReadToEnd();
				streamReader.Close();

				var report = new ReportResources()
				    {
				        Name = folder.Name,
				        Script = scriptText,
						TemplatePath = "\\" + folder.Name + "\\template.html"
				    };
				// jch! - would want to load the theme css and parse images as well
				reports.Add(report);
			}
			return reports;
		}



		public static string ReportsDir
		{
			get
			{
				return projectDir + "\\Scripts\\Reports";
			}
		}

		static string themesDir
		{
			get
			{
				return projectDir + "\\Scripts\\Themes";
			}
		}

		static string projectDir
		{
			get
			{
				if (_projectDir == null)
				{
					string assemblyLocation = System.Reflection.Assembly.GetAssembly(typeof(JsFileLoader)).Location;
					string path = Uri.UnescapeDataString(new UriBuilder(assemblyLocation).Path);
					var debugDir = Path.GetDirectoryName(path);
					_projectDir = Directory.GetParent(debugDir).Parent.Parent.FullName + "\\ReportGenerationTest";
				}
				return _projectDir;
			}
		}

		private static string _projectDir { get; set; }
	}
}
