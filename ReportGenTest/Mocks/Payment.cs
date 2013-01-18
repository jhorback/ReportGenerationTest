using System;
using System.Collections.Generic;
using LaunchTechnologies.Domain;

namespace ReportGenTest.Mocks
{
	public class Payment : IPayment
	{
		public string PaymentType { get; set; }
		public decimal Amount { get; set; }
		public string CheckNumber { get; set; }
		public DateTime Date { get; set; }
		public string AccountNumber { get; set; }
		public string ABANumber { get; set; }
		public List<IPaymentItem> Items { get; set; }
	}
}
