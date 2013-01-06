using ReportGenerationTest.Domain;
using ReportGenerationTest.Scripts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ReportGenerationTest;

namespace ReportGenerationTestTest
{


	[TestClass()]
	public class ReportGeneratorTest
	{


		private TestContext testContextInstance;

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


		[TestMethod()]
		public void GetReportHtml_WithoutModel_ReportIsGenerated()
		{
			ReportResourcesRepository rep = new ReportResourcesRepository();
			ReportGenerator target = new ReportGenerator(rep);
			string reportName = "Report1";
			
			var result = target.GetReportHtml(null, reportName);
			
			// Assert.Inconclusive("Verify the correctness of this test method.");
		}

		[TestMethod()]
		public void GetReportHtml_WithModel_ReportIsGenerated()
		{
			ReportResourcesRepository rep = new ReportResourcesRepository();
			ReportGenerator target = new ReportGenerator(rep);
			string reportName = "CustomerReport";
			
			var customer = new CustomerRepository().GetCustomer();
			var result = target.GetReportHtml(customer, reportName);
			// Assert.Inconclusive("Verify the correctness of this test method.");
		}

		[TestMethod()]
		public void GetReportHtml_WithManipulatedModel_ReportIsGenerated()
		{
			ReportResourcesRepository rep = new ReportResourcesRepository();
			ReportGenerator target = new ReportGenerator(rep);
			string reportName = "CustomerReport2";
			
			var customer = new CustomerRepository().GetCustomer();
			var result = target.GetReportHtml(customer, reportName);
			// Assert.Inconclusive("Verify the correctness of this test method.");
		}
	}
}
