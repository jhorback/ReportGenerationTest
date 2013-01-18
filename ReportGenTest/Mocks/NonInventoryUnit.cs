using System;
using LaunchTechnologies.Domain;

namespace ReportGenTest.Mocks
{
	public class NonInventoryUnit : INonInventoryUnit
	{
		public IUser ModifiedUser { get; set; }
		public Guid InternalId { get; set; }
		public string SerialNumber { get; set; }
		public string StockId { get; set; }
		public string Year { get; set; }
		public string Make { get; set; }
		public string Model { get; set; }
		public string Locale { get; set; }
		public string Usage { get; set; }
		public string Condition { get; set; }
		public bool? Crated { get; set; }
		public string Comment { get; set; }
	}
}
