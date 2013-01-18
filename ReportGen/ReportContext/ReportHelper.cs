using System;
using LaunchTechnologies.Domain;

namespace ReportGen.ReportContext
{
	public class ReportHelper
	{
		// add helper util methods for use by JavaScript

		public string GetImageSrc(byte[] content)
		{
			return "data:image/png;base64," +
			  Convert.ToBase64String(content, Base64FormattingOptions.None);
		}
	}
}
