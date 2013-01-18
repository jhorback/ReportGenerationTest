
using System;
using System.IO;
using LaunchTechnologies.Domain;
using ReportGen;

namespace ReportGenTest.Mocks
{
	public class MockAudit : AuditModel
	{
		public MockAudit()
		{
			DealerDBAName = "Acura North Scottsdale";
			Street1 = "7007 E CHAUNCEY LANE";
			City = "PHOENIX";
			State = "AZ";
			Zip = "85054";
			WorkPhone = "(480) 538-6833";

			DealerContactName = "Cheryl Ochoa";
			DealerContactTitle = "";

			IsComplete = false;
			// CompletedDate = 
			CompletedUser = new UserModel {ClientName = "Launch Technologies", Name = "Joe Philbin"};



			/*		 
				public int UnitCount { get; set; }
				public System.Collections.IEnumerable Units { get; set; } // IAuditUnit
				public IEnumerable<INonInventoryUnit> NonInventoryUnits { get; set; }
				public List<IPayment> Payments { get; set; }
				public IList<IAuditCharge> AuditCharges { get; set; }
				public decimal TotalPaymentsForAuditCharges { get; set; }
				public IEnumerable<Guid> CommentIds { get; set; }			 
			 * */
		}

		public AuditSignature GetSignature()
		{
			var sigPath = Path.Combine(GraphPkgInfo.ProjectDir, "SASS", "images", "default", "signature.png");
			var fs = new FileStream(sigPath, FileMode.Open, FileAccess.Read);
			var filebytes = new byte[fs.Length];
			fs.Read(filebytes, 0, Convert.ToInt32(fs.Length));
			fs.Close();

			var sig = new AuditSignature
			{
				Content = filebytes
			};
			return sig;
		}
	}
}
