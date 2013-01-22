using System;
using System.Collections.Generic;
using LaunchTechnologies.Domain;

namespace ReportGenTest.Mocks
{
	public class AuditModel : IAudit
	{
		public Guid AssignmentTypeGuid { get; set; }
		public string ClientName { get; set; }

		// dealer info
		public string DealerDBAName { get; set; }
		public string Street1 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
		public string WorkPhone { get; set; }
		public string DealerContactName { get; set; }
		public string DealerContactTitle { get; set; }
		
		// auditor info
		public bool IsComplete { get; set; }		
		public DateTime CompletedDate { get; set; }
		public IUser CompletedUser { get; set; }

		// audit info
		public int UnitCount { get; set; }
		public System.Collections.IEnumerable Units { get; set; } // IAuditUnit
		public IEnumerable<INonInventoryUnit> NonInventoryUnits { get; set; }
		public List<IPayment> Payments { get; set; }
		public IList<IAuditCharge> AuditCharges { get; set; }
		public decimal TotalPaymentsForAuditCharges { get; set; }
		public IEnumerable<Guid> CommentIds { get; set; }
		


		#region methods
		public string GetNodeName(Guid nodeId)
		{
			throw new NotImplementedException();
		}

		public string GetNodeValue(Guid nodeId)
		{
			throw new NotImplementedException();
		}

		public AuditSignature GetSignature(Guid nodeId)
		{
			throw new NotImplementedException();
		}

		public bool TryGetNodeValue(Guid nodeId, out string value)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}
