using NVelocity;

namespace ReportGen.ReportContext
{
	/// <summary>
	/// Adds lowercase methods to normalize with Java Velocity.
	/// </summary>
	public class NormalizedVelocityContext : VelocityContext
	{
		public object put(string key, object value)
		{
			return Put(key, value);
		}

		public object get(string key)
		{
			return Get(key);
		}
	}
}
