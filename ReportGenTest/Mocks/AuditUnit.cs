using System;
using System.Collections.Generic;
using LaunchTechnologies.Domain;

namespace ReportGenTest.Mocks
{
	public class AuditUnit : IAuditUnit
	{
		public string ClientCode { get; set; }
		public string Color { get; set; }
		public IEnumerable<Guid> CommentIds { get; set; }
		public IUser CompletedUser { get; set; }
		public string Description { get; set; }
		public string FloorPlanCode { get; set; }
		public Guid InternalId { get; set; }
		public DateTime? InvoiceDate { get; set; }
		public string InvoiceNumber { get; set; }
		public bool IsComplete { get; set; }
		public decimal? LoanAmount { get; set; }
		public decimal? LoanAmountRemaining { get; set; }
		public DateTime? LoanMaturityDate { get; set; }
		public string Make { get; set; }
		public string Model { get; set; }
		public double PercentComplete { get; set; }
		public string ProductLine { get; set; }
		public string ProductLineCategory { get; set; }
		public string ProductLineDescription { get; set; }
		public Guid RootElementId { get; set; }
		public string SerialNumber { get; set; }
		public Status Status { get; set; }
		public string StockId { get; set; }
		public decimal TotalPaymentAmount { get; set; }
		public string Year { get; set; }


		public decimal GetSumOfChargesToDate(DateTime asOfDate)
		{
			throw new NotImplementedException();
		}

		public string GetAllChildData(Guid nodeId, bool htmlEncoded)
		{
			throw new NotImplementedException();
		}

		public string GetNodeName(Guid nodeId)
		{
			throw new NotImplementedException();
		}

		public string GetNodeValue(Guid nodeId)
		{
			throw new NotImplementedException();
		}
		
		public bool TryGetNodeValue(Guid nodeId, out string value)
		{
			throw new NotImplementedException();
		}
	}
}
