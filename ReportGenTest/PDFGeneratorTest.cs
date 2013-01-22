using LaunchTechnologies.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReportGen;
using ReportGenTest.Mocks;

namespace ReportGenTest
{
    
    
    /// <summary>
    ///This is a test class for PDFGeneratorTest and is intended
    ///to contain all PDFGeneratorTest Unit Tests
    ///</summary>
	[TestClass()]
	public class PDFGeneratorTest
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
		///A test for GeneratPDF
		///</summary>
		[TestMethod()]
		public void GeneratPDF_HelloWorld_PdfIsGenerated()
		{
			var generator = new PDFGenerator();
			var pdfPath = ResultViewer.GetResultFilePath("pdftest.pdf");

			generator.GeneratPDF("Hello World", pdfPath);			

			Assert.IsTrue(true);
			ResultViewer.OpenResult(pdfPath);
		}


		[TestMethod()]
		public void GeneratPDF_FromGeneratedReport_PdfIsGenerated()
		{
			var generator = new PDFGenerator();
			var pdfPath = ResultViewer.GetResultFilePath("pdftest.pdf");

			IReportRepository reportRep = new ReportRepository();
			IAudit auditModel = new MockAudit();
			var repGen = new ReportGenerator(reportRep);
			var report = repGen.GetReportHtml("report1", auditModel);

			generator.GeneratPDF(report, pdfPath);

			Assert.IsTrue(true);
			ResultViewer.OpenResult(pdfPath);
		}
	}
}
