using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReportGen;

namespace ReportGenTest
{
    
    
    /// <summary>
    ///This is a test class for ReportRepositoryTest and is intended
    ///to contain all ReportRepositoryTest Unit Tests
    ///</summary>
	[TestClass()]
	public class ReportRepositoryTest
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
		///A test for GetReports
		///</summary>
		[TestMethod]
		public void GetReports_Execute_AtLeastOneReportExists()
		{
			var target = new ReportRepository();
			var actual = target.GetReports();
			Assert.IsTrue(actual.Count > 0);
		}

		/// <summary>
		///A test for GetReport
		///</summary>
		[TestMethod]
		public void GetReport_GetReport1_ReportPropertiesAreCorrect()
		{
			var target = new ReportRepository();
			var report = target.GetReport("report1");
			Assert.IsNotNull(report);
			Assert.AreEqual("Audit Recap Report", report.Name);
			Assert.IsTrue(string.IsNullOrEmpty(report.Description) == false);
			Assert.AreEqual("/themes/default/theme.css", report.ThemeFile);
			Assert.IsTrue(string.IsNullOrEmpty(report.ScriptFile) == false);
			Assert.IsTrue(string.IsNullOrEmpty(report.TemplateLayoutFile) == false);
		}
	}
}
