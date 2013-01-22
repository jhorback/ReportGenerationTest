using System;
using System.Diagnostics;
using System.IO;
using ReportGen;

namespace ReportGenTest
{
	public class ResultViewer
	{
		/// <summary>
		/// Creates the file content in the results dir with the given file name and returns the path to the file.
		/// </summary>
		/// <param name="fileContent"> </param>
		/// <param name="fileName"></param>
		/// <returns></returns>
		public static string CreateResult(string fileContent, string fileName)
		{
			var resultFilePath = GetResultFilePath(fileName);
			using (StreamWriter sw = File.CreateText(resultFilePath))
			{
				sw.Write(fileContent);
			}
			return resultFilePath;
		}

		public static void ViewResult(string html)
		{
			var resultFilePath = CreateResult(html, "results.html");
			OpenResult(resultFilePath);
		}

		public static void OpenResult(string filePath)
		{
			//return;
			var process = new Process();
			process.StartInfo.UseShellExecute = true;
			process.StartInfo.FileName = filePath;
			try
			{
				process.Start();
				process.WaitForExit();
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
