using System;
using System.IO;
using Commons.Collections;
using LaunchTechnologies.Domain;
using NVelocity.App;
using NVelocity.Runtime;
using ReportGen.ReportContext;

namespace ReportGen
{
	public class ReportGenerator
	{
		IReportRepository reportRep;
		IJsLibRepository jsLibRep;


		public ReportGenerator(IReportRepository reportRep, IJsLibRepository jsLibRep)
		{
			this.reportRep = reportRep;
			this.jsLibRep = jsLibRep;
		}


		public string GetReportHtml(string reportKey, IAudit auditModel)
		{
			var report = reportRep.GetReport(reportKey);
			var jsLib = jsLibRep.GetJsLib();
			var templateModel = new NormalizedVelocityContext();


			// add the layout to the template model
			templateModel.put("Layout", new Layout
			    {
			        Title = report.Name,
					CSS = GraphPkgResourceLoader.LoadResource(report.GetThemeResourcePath()),
					ReportTemplate = report.GetTemplateResourcePath()
			    });
			templateModel.put("Audit", auditModel);


			// create the context and execute the javascript
			var context = new ReportContext.Context(auditModel, templateModel);
			var jsExec = new JavaScriptExecutor();
			var allScripts = jsLib.Source + ";" + GraphPkgResourceLoader.LoadResource(report.GetScriptResourcePath());
			var jsRet = jsExec.ExecuteFunction(allScripts, "generateReport", new object[] { context });

			
			// setup the resource loader
			var props = new ExtendedProperties();
			props.AddProperty(RuntimeConstants.RESOURCE_LOADER, "ReportTemplate");
			props.AddProperty("ReportTemplate.resource.loader.description", "In memory report template.");
			props.AddProperty("ReportTemplate.resource.loader.class", "ReportGen.ReportTemplateResourceLoader;ReportGen");
			props.AddProperty("ReportTemplate.resource.loader.path", ".");
			props.AddProperty("ReportTemplate.resource.loader.cache", "false");
			props.AddProperty("ReportTemplate.resource.loader.modificationCheckInterval", "0");


			// generate the report
			var ve = new VelocityEngine();
			ve.Init(props);
			var writer = new StringWriter();
			var t = ve.GetTemplate(report.GetLayoutTemplateResourcePath());
			t.Merge(context.Template, writer);
			var reportHtml = writer.ToString();
			return reportHtml;
		}
	}
}
