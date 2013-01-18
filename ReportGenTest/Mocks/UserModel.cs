using LaunchTechnologies.Domain;

namespace ReportGenTest.Mocks
{
	public class UserModel : IUser
	{
		public string ClientName { get; set; }
		public string Name { get; set; }
	}
}
