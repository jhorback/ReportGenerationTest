using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using LaunchTechnologies.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReportGen;
using ReportGen.ReportContext;
using ReportGenTest.Mocks;

namespace ReportGenTest
{
	/// <summary>
	///This is a test class for ReportGeneratorTest and is intended
	///to contain all ReportGeneratorTest Unit Tests
	///</summary>
	[TestClass()]
	public class ReportGeneratorTest
	{
		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		// 
		//You can use the following additional attributes as you write your tests:
		//
		//Use ClassInitialize to run code before running the first test in the class
		//[ClassInitialize()]
		//public static void MyClassInitialize(TestContext testContext)
		//{
		//}
		//
		//Use ClassCleanup to run code after all tests in a class have run
		//[ClassCleanup()]
		//public static void MyClassCleanup()
		//{
		//}
		//
		//Use TestInitialize to run code before running each test
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{
		//}
		//
		//Use TestCleanup to run code after each test has run
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{
		//}
		//
		#endregion


		/// <summary>
		///A test for GetReportHtml
		///</summary>
		[TestMethod]
		public void GetReportHtml_Execute_HtmlReturned()
		{
			IReportRepository reportRep = new ReportRepository();
			IAudit auditModel = new MockAudit();
			var generator = new ReportGenerator(reportRep);

			var report = generator.GetReportHtml("report1", auditModel);
			
			Assert.IsTrue(string.IsNullOrEmpty(report) == false);
			ResultViewer.ViewResult(report);
		}
		

		[TestMethod]
		public void GetReportHtml_ExecuteWithException_ExceptionHandled()
		{
			IReportRepository reportRep = new ReportRepository();
			IAudit auditModel = new MockAudit();
			var generator = new ReportGenerator(reportRep);

			var context = new Context(auditModel);
			context.template.put("GenerateError", true);
			var report = generator.GetReportHtml("report1", context);

			var expected = "An error occured during report generation: Testing errors caused by report generation.";
			var actual = context.logger.getLog()[0];

			Assert.AreEqual(expected, actual);
		}


		[TestMethod]
		public void GetReportHtml_RenderWithWkhtmltopdf()
		{
			
			IReportRepository reportRep = new ReportRepository();
			IAudit auditModel = new MockAudit();
			var generator = new ReportGenerator(reportRep);

			var report = generator.GetReportHtml("report1", auditModel);

			var wkPath = Path.Combine(GraphPkgInfo.ProjectDir, "..", "lib", "wkhtmltopdf", "wkhtmltopdf.exe");
			var htmlFilePath = ResultViewer.CreateResult(report, "results.html");
			var pdfFilePath = ResultViewer.GetResultFilePath("wkhtmltopdf-test.pdf");
			if (File.Exists(pdfFilePath)) File.Delete(pdfFilePath);


			var args = new List<string>();
			args.Add("--margin-left 0 --margin-right 0 --margin-top 0 --margin-bottom 0");
			args.Add(htmlFilePath);
			args.Add(pdfFilePath);

			//http://code.google.com/p/wkhtmltopdf/wiki/Usage - some examples of use with streams
			var proc = new Process();
			proc.StartInfo.UseShellExecute = false;
			proc.StartInfo.CreateNoWindow = true;
			proc.StartInfo.FileName = wkPath;
			proc.StartInfo.Arguments = string.Join(" ", args);
			proc.StartInfo.RedirectStandardOutput = true;
			proc.StartInfo.RedirectStandardError = true;
			
			try
			{
				proc.Start();
				proc.WaitForExit();
			}
			catch (System.Exception e)
			{
				Assert.Fail(e.Message);
			}

			Assert.IsTrue(File.Exists(pdfFilePath));
			ResultViewer.OpenResult(pdfFilePath);
		}
	}
}
