using System;
using System.IO;
using System.Reflection;

namespace ReportGen
{
	public class GraphPkgInfo
	{
		static string _projectDir;

		public static string GraphPkgDir
		{
			get { return Path.Combine(ProjectDir, "GraphPkg"); }
		}

		public static string JsLibDir
		{
			get { return Path.Combine(GraphPkgDir, "JsLib"); }
		}

		public static string ReportsDir
		{
			get { return Path.Combine(GraphPkgDir, "Reports"); }
		}

		public static string ThemesDir
		{
			get { return Path.Combine(GraphPkgDir, "Themes"); }
		}

		public static string LayoutsDir
		{
			get { return Path.Combine(GraphPkgDir, "Layouts"); }
		}

		public static string ProjectDir
		{
			get
			{
				if (_projectDir == null)
				{
					string assemblyLocation = Assembly.GetExecutingAssembly().Location;
					string path = Uri.UnescapeDataString(new UriBuilder(assemblyLocation).Path);
					var execDir = Path.GetDirectoryName(path);
					_projectDir = Path.Combine(Directory.GetParent(execDir).Parent.Parent.FullName, "ReportGen");
				}
				return _projectDir;
			}
		}
	}
}
