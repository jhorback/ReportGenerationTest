using System.IO;
using Commons.Collections;
using NVelocity.App;
using NVelocity.Runtime;

namespace ReportGenerationTest
{
	public class ReportGenerator
	{
		ReportResourcesRepository rep;

		public ReportGenerator(ReportResourcesRepository rep)
		{
			this.rep = rep;
		}

		public string GetReportHtml(object modelContext, string reportName)
		{
			var resources = rep.FindReport(reportName);

			var ve = new VelocityEngine();
			var props = new ExtendedProperties();
			props.AddProperty(RuntimeConstants.FILE_RESOURCE_LOADER_PATH, ReportResourcesRepository.ReportsDir);
			ve.Init(props);

			var viewContext = new NormalizedVelocityContext();
			var jsExec = new JavaScriptExecutor();
			var jsRet = jsExec.ExecuteFunction(resources.Script, "generateReport", new object[] { modelContext, viewContext });


			var writer = new StringWriter();
			var t = ve.GetTemplate(resources.TemplatePath);
			t.Merge(viewContext, writer);
			var report = writer.ToString();
			return report;
		}
	}
}
