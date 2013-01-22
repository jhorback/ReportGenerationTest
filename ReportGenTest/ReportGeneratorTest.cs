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
	}
}
