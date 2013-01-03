using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using org.mozilla.javascript;

namespace ReportGenerationTest
{
	public class JavaScriptExecutor
	{
		public object ExecuteFunction(string scriptName, string functionName, object[] args)
		{
			var scriptText = new JsFileLoader().JsFile(scriptName);
			Context cx = Context.enter();
			try
			{
				cx.setClassShutter(new ClassShutter());
				Scriptable scope = cx.initStandardObjects();
				cx.evaluateString(scope, scriptText, "<cmd>", 1, null);
				

				Function jsFunction = (Function)scope.get(functionName, scope);
				object result = jsFunction.call(cx, scope, scope, args);
				return result;
			}
			finally
			{
				Context.exit();
			}

			return null;
		}

		/// <summary>
		/// Implements security by restricting which classes can be used in JavaScript
		/// </summary>
		private class ClassShutter : org.mozilla.javascript.ClassShutter
		{
			public bool visibleToScripts(string str)
			{
				//if (str == "cli.ReportGenerationTestTest.JsTestContext")
				//    return true;
				return true;
			}
		}
	}
}
