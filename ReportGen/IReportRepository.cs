using System.Collections.Generic;

namespace ReportGen
{
	public interface IReportRepository
	{
		List<Report> GetReports();
		Report GetReport(string key);
	}
}
