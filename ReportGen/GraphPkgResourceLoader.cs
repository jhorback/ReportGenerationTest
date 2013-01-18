using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ReportGen
{
	public class GraphPkgResourceLoader
	{
		/// <summary>
		/// Loads the resource after determining the resource path using GetResourcePath(path).
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static string LoadResource(string path)
		{
			var resourcePath = GetResourcePath(path);
			if (File.Exists(resourcePath) == false)
				return null;

			string resource;
			using (var streamReader = new StreamReader(resourcePath))
			{
				resource = streamReader.ReadToEnd();
			}
			return resource;
		}

		/// <summary>
		/// The path can be in the form of "RootPath;FilePath" or just "FilePath"
		/// If there is no RootPath it is assumed to be the GraphPkgDir.
		/// If the file path begins with "/" the GraphPkgDir will be assumed the root path.
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static string GetResourcePath(string path)
		{
			string rootPath = null;
			string filePath = null;

			var pathParts = path.Split(';');
			if (pathParts.Length == 1)
			{
				rootPath = GraphPkgInfo.GraphPkgDir;
				filePath = pathParts[0].Replace("/", "\\");
				if (filePath.IndexOf("\\", System.StringComparison.Ordinal) != 0)
					filePath = "\\" + filePath;
			}
			else
			{
				rootPath = pathParts[0];
				filePath = pathParts[1];
				filePath = filePath.Replace("/", "\\");
				if (filePath.IndexOf("\\", System.StringComparison.Ordinal) == 0)
					rootPath = GraphPkgInfo.GraphPkgDir;
				else filePath = "\\" + filePath;
			}

			var resourcePath = rootPath + filePath;
			return resourcePath;
		}
	}
}
