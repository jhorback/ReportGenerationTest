using ReportGenerationTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ReportGenerationTestTest
{
    
    
    /// <summary>
    ///This is a test class for JavaScriptExecutorTest and is intended
    ///to contain all JavaScriptExecutorTest Unit Tests
    ///</summary>
	[TestClass()]
	public class JavaScriptExecutorTest
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
		///A test for ExecuteFunction
		///</summary>
		[TestMethod()]
		public void ExecuteFunction_generateReporCalled_returnValueIsCorrect()
		{
			JavaScriptExecutor target = new JavaScriptExecutor();
			string scriptName = "JsReport.js";
			string functionName = "generateReport"; // TODO: Initialize to an appropriate value


			var testContext = new JsTestContext()
				{
					Name = "Test Name",
					Description = "Test Description"
				};


			object[] args = new object[] { testContext, " stringVal ", 10 };
			object expected = "hello world - Test Name - Test Description - Modified: Test Description stringVal 10";
			object actual = target.ExecuteFunction(scriptName, functionName, args);
			Assert.AreEqual(expected, actual);
		}
	}



	// properties are prefixed with an _ and have get_PropertyName and set_PropertyName methods
	public class JsTestContext
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string GetModifiedDescription(string stringVal, int intVal)
		{
			return "Modified: " + Description + stringVal + intVal;
		}
	}

	// javascript representation of JsTestContext:
	/* "getClass: function getClass() {/*\njava.lang.Class getClass()\n* /}\n\n_Name: Test Name\nequals: function equals() {/*\nboolean equals(java.lang.Object)\n* /}\n\nset_Name: function set_Name() {/*\nvoid set_Name(java.lang.String)\n* /}\n\nclass: class cli.ReportGenerationTestTest.JsTestContext\nhashCode: function hashCode() {/*\nint hashCode()\n* /}\n\nGetType: function GetType() {/*\ncli.System.Type GetType()\n* /}\n\nwait: function wait() {/*\nvoid wait(long,int)\nvoid wait(long)\nvoid wait()\n* /}\n\nget_Name: function get_Name() {/*\njava.lang.String get_Name()\n* /}\n\nget_Description: function get_Description() {/*\njava.lang.String get_Description()\n* /}\n\nset_Description: function set_Description() {/*\nvoid set_Description(java.lang.String)\n* /}\n\nGetModifiedDescription: function GetModifiedDescription() {/*\njava.lang.String GetModifiedDescription()\n* /}\n\nnotify: function notify() {/*\nvoid notify()\n* /}\n\nToString: function ToString() {/*\njava.lang.String ToString()\n* /}\n\nEquals: function Equals() {/*\nboolean Equals(java.lang.Object)\n* /}\n\ntoString: function toString() {/*\njava.lang.String toString()\n* /}\n\nGetHashCode: function GetHashCode() {/*\nint GetHashCode()\n* /}\n\n_Description: Test Description\nnotifyAll: function notifyAll() {/*\nvoid notifyAll()\n* /}\n\n"*/
}
