using ReportGenerationTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ReportGenerationTestTest
{
    
    
    /// <summary>
    ///This is a test class for JsFileLoaderTest and is intended
    ///to contain all JsFileLoaderTest Unit Tests
    ///</summary>
	[TestClass()]
	public class JsFileLoaderTest
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
		///A test for JsFile
		///</summary>
		[TestMethod]
		public void JsFile_fileExists_scriptTextReturned()
		{
			JsFileLoader target = new JsFileLoader();
			string name = "test.js";
			string expected = "foo";
			string actual = target.JsFile(name);
			Assert.AreEqual(expected, actual);
		}
	}
}
