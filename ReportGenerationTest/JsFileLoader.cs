using System;
using System.IO;

namespace ReportGenerationTest
{
	public class JsFileLoader
	{
		public string JsFile(string name)
		{
			var scriptPath = string.Format("{0}/Scripts/{1}", ProjectDir, name);
			var streamReader = new StreamReader(scriptPath);
			string text = streamReader.ReadToEnd();
			streamReader.Close();
			return text;
		}

		static public string ProjectDir
		{
			get
			{
				string codeBase = System.Reflection.Assembly.GetAssembly(typeof(JsFileLoader)).Location;
				UriBuilder uri = new UriBuilder(codeBase);
				string path = Uri.UnescapeDataString(uri.Path);
				var debugDir = Path.GetDirectoryName(path);
				var projectDir = Directory.GetParent(debugDir).Parent.Parent.FullName;
				return projectDir + "\\ReportGenerationTest";
			}
		}
	}
}
