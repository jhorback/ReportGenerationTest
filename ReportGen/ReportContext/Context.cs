using System.Collections.Generic;
using LaunchTechnologies.Domain;

namespace ReportGen.ReportContext
{
	public class Context
	{
		public Context(IAudit audit)
		{
			helper = new ReportHelper();
			this.audit = audit;
			template = new NormalizedVelocityContext();
			logger = new Logger();
		}

		public IAudit audit { get; set; }
		public ReportHelper helper { get; set; }
		public NormalizedVelocityContext template { get; set; }
		public Logger logger { get; set; }
	}

	public class Logger
	{
		List<string> messages = new List<string>();

		public void log(string message)
		{
			messages.Insert(0, message);
		}

		public List<string> getLog()
		{
			return messages;
		}
	}
}
