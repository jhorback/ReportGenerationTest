using System.Collections.Generic;
using System.IO;
using System.Linq;
using IniParser;

namespace ReportGen
{
	public class ReportRepository : IReportRepository
	{
		List<Report> reports = null;

		public List<Report> GetReports()
		{
			return getReports();
		}

		public Report GetReport(string key)
		{
			return getReports().FirstOrDefault(r => r.Key == key);
		}

		List<Report> getReports()
		{
			if (reports == null)
			{
				reports = new List<Report>();
				var dir = new DirectoryInfo(GraphPkgInfo.ReportsDir);
				foreach (var reportDir in dir.GetDirectories())
				{
					// parse the ini and create the report object
					var parser = new FileIniDataParser();
					var infoTxtPath = Path.Combine(reportDir.FullName, "info.txt");
					if (File.Exists(infoTxtPath) == false)
						continue;
					var infoData = parser.LoadFile(infoTxtPath, relaxedIniRead: true);
					var report = new Report
					    {
					        Key = reportDir.Name,
					        Name = getInfoData(infoData, "Name"),
					        Description = getInfoData(infoData, "Description"),
							ReportDir = reportDir.FullName
					    };
					report.ThemeFile = getInfoData(infoData, "Theme", report.ThemeFile);
					report.TemplateFile = getInfoData(infoData, "Template", report.TemplateFile);
					report.ScriptFile = getInfoData(infoData, "Script", report.ScriptFile);
					report.TemplateLayoutFile = getInfoData(infoData, "TemplateLayout", report.TemplateLayoutFile);
					reports.Add(report);
				}
			}
			return reports;
		}

		private string getInfoData(IniData infoData, string key, string defaultValue = "")
		{
			if (infoData.Global.ContainsKey(key))
				return infoData.Global.GetKeyData(key).Value;
			return defaultValue;
		}
	}
}
