using ReportGen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ReportGenTest
{
    
    
    /// <summary>
    ///This is a test class for JsLibRepositoryTest and is intended
    ///to contain all JsLibRepositoryTest Unit Tests
    ///</summary>
	[TestClass()]
	public class JsLibRepositoryTest
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
		///A test for GetJsLib
		///</summary>
		[TestMethod]
		public void GetJsLib_Exectue_SourceIsNotNullOrEmpty()
		{
			var target = new JsLibRepository();
			var actual = target.GetJsLib();
			Assert.IsTrue(string.IsNullOrEmpty(actual.Source) == false);
		}

		[TestMethod]
		public void GetJsLib_Exectue_SourceBeginsWithSemicolon()
		{
			var target = new JsLibRepository();
			var actual = target.GetJsLib();
			Assert.IsTrue(actual.Source.IndexOf(';') == 0);
		}
	}
}
