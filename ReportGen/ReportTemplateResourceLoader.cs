using System.IO;
using System.Text;
using Commons.Collections;
using NVelocity.Runtime.Resource;
using NVelocity.Runtime.Resource.Loader;

namespace ReportGen
{
	public class ReportTemplateResourceLoader : ResourceLoader
	{
		public override Stream GetResourceStream(string path)
		{
			var template = GraphPkgResourceLoader.LoadResource(path);
			
			if (template == null)
				return null;

			var byteArray = Encoding.ASCII.GetBytes(template);
			var stream = new MemoryStream(byteArray);
			return stream;
		}

		public override long GetLastModified(Resource resource) { return 0; }
		public override bool IsSourceModified(Resource resource) { return false; }
		public override void Init(ExtendedProperties configuration) { }
	}
}
