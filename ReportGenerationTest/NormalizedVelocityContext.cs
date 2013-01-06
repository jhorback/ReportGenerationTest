using System.Collections.Generic;
using NVelocity;

namespace ReportGenerationTest
{
	public class NormalizedVelocityContext : VelocityContext
	{
		public object put(string key, object value)
		{
			return this.Put(key, value);
		}

		public object get(string key)
		{
			return this.Get(key);
		}

		public NormalizedDictionary GetNewViewModel()
		{
			var nvm = new NormalizedDictionary();
			return nvm;
		}
	}

	public class NormalizedDictionary : Dictionary<string, object>
	{
		public object put(string key, object value)
		{
			this.Add(key, value);
			return value;
		}

		public object get(string key)
		{
			return this[key];
		}
	}
}
