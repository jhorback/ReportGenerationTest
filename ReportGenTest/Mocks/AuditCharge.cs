using System;
using LaunchTechnologies.Domain;

namespace ReportGenTest.Mocks
{
	public class AuditCharge : IAuditCharge
	{
		public Guid Id { get; set; }
		public decimal Amount { get; set; }
		public string Description { get; set; }
	}
}
