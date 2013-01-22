using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using ReportGen;

namespace ReportGenTest
{
	public class ResultViewer
	{
		public static void ViewResult(string html)
		{
			var resultFilePath = GetResultFilePath("results.html");
			using (StreamWriter sw = File.CreateText(resultFilePath))
			{
				sw.Write(html);
			}

			OpenResult(resultFilePath);
		}

		public static void OpenResult(string filePath)
		{
			// return;
			var process = new Process();
			process.StartInfo.UseShellExecute = true;
			process.StartInfo.FileName = filePath;
			try
			{
				process.Start();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		public static string GetResultFilePath(string filename)
		{
			return Path.Combine(GraphPkgInfo.ProjectDir, "results", filename);
		}
	}
}
