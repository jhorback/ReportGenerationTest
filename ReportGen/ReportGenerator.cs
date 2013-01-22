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

		public ReportGenerator(IReportRepository reportRep)
		{
			this.reportRep = reportRep;
		}

		public string GetReportHtml(string reportKey, Context context)
		{
			return GetReportHtml(reportKey, context.audit, context);			
		}

		public string GetReportHtml(string reportKey, IAudit auditModel)
		{
			var context = new ReportContext.Context(auditModel);
			return GetReportHtml(reportKey, auditModel, context);
		}

		public string GetReportHtml(string reportKey, IAudit auditModel, Context context)
		{
			var report = reportRep.GetReport(reportKey);


			// create the context and add layout info to the template
			context.template.put("Layout", new Layout
				{
					Title = report.Name,
					CSS = GraphPkgResourceLoader.LoadResource(report.GetThemeResourcePath()),
					ReportTemplate = report.GetTemplateResourcePath()
				});
			context.template.put("Audit", auditModel);
			
			
			// execute the JavaScript
			var jsExec = new JavaScriptExecutor();
			var allScripts = GraphPkgResourceLoader.LoadResource(report.GetScriptResourcePath());
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
			t.Merge(context.template, writer);
			var reportHtml = writer.ToString();
			return reportHtml;
		}
	}
}
