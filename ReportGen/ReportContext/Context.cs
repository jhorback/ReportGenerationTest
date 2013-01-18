using LaunchTechnologies.Domain;

namespace ReportGen.ReportContext
{
	public class Context
	{
		public Context(IAudit audit, NormalizedVelocityContext templateModel)
		{
			Helper = new ReportHelper();
			Audit = audit;
			Template = templateModel;
		}

		public IAudit Audit { get; set; }
		public ReportHelper Helper { get; set; }
		public NormalizedVelocityContext Template { get; set; }
	}
}
