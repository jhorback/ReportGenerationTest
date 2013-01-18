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
			var process = new Process();
			process.StartInfo.UseShellExecute = true;

			var resultsDir = Path.Combine(GraphPkgInfo.ProjectDir, "results");
			if (Directory.Exists(resultsDir) == false)
			{
				Directory.CreateDirectory(resultsDir);
			}

			var resultFilePath = Path.Combine(resultsDir, "results.html");
			using (StreamWriter sw = File.CreateText(resultFilePath))
			{
				sw.Write(html);
			}

			process.StartInfo.FileName = resultFilePath;

			try
			{
				process.Start();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}
}
