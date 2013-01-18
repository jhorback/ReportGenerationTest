using System;
using System.IO;

namespace ReportGen
{
	public class JsLibRepository : IJsLibRepository
	{
		private JsLib jsLib = null;

		public JsLib GetJsLib()
		{
			if (jsLib == null)
			{
				var source = "";
				var dir = new DirectoryInfo(GraphPkgInfo.JsLibDir);
				foreach (var script in dir.GetFiles("*.js"))
				{
					var streamReader = new StreamReader(script.FullName);
					string scriptText = streamReader.ReadToEnd();
					streamReader.Close();
					source += ";" + scriptText;
				}

				jsLib = new JsLib {Source = source};
			}
			return jsLib;
		}
	}
}
