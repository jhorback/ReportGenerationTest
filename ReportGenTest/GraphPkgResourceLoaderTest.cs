using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReportGen;

namespace ReportGenTest
{
    
    
    /// <summary>
    ///This is a test class for GraphPkgResourceLoaderTest and is intended
    ///to contain all GraphPkgResourceLoaderTest Unit Tests
    ///</summary>
	[TestClass()]
	public class GraphPkgResourceLoaderTest
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
		///A test for GetResourcePath
		///</summary>
		[TestMethod]
		public void GetResourcePath_RelativePath_CorrectPathReturned()
		{
			string path = "relative/path.txt";
			
			var resourcePath = GraphPkgResourceLoader.GetResourcePath(path);

			Assert.AreEqual(GraphPkgInfo.GraphPkgDir + "\\relative\\path.txt", resourcePath);
		}


		[TestMethod]
		public void GetResourcePath_AbsolutePath_CorrectPathReturned()
		{
			string path = "/absolute/path.txt";

			var resourcePath = GraphPkgResourceLoader.GetResourcePath(path);

			Assert.AreEqual(GraphPkgInfo.GraphPkgDir + "\\absolute\\path.txt", resourcePath);
		}

		[TestMethod]
		public void GetResourcePath_RelativePathWithRoot_CorrectPathReturned()
		{
			string path = "root;relative/path.txt";

			var resourcePath = GraphPkgResourceLoader.GetResourcePath(path);

			Assert.AreEqual("root\\relative\\path.txt", resourcePath);
		}


		[TestMethod]
		public void GetResourcePath_AbsolutePathWithRoot_CorrectPathReturned()
		{
			string path = "root;/absolute/path.txt";

			var resourcePath = GraphPkgResourceLoader.GetResourcePath(path);

			Assert.AreEqual(GraphPkgInfo.GraphPkgDir + "\\absolute\\path.txt", resourcePath);
		}
	}
}
