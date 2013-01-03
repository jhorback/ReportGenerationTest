using System;
using org.mozilla.javascript;

namespace TestRhino
{
	public class FirstTest
	{
		private const string script =
			@"
			function calledWithState()
			{
			   return _CalledWithState(me);
			}
			
			function foo(x)
			{
			   return calledWithState() + 
					  fromCSharp(321.9) + x + ""!!!         "";
			}
			";

		public static string FromCSharp(java.lang.Double i)
		{
			return string.Format("  {0}   the ", i);
		}

		private string State = "the state";

		public string CalledWithState()
		{
			return State + "\n";
		}

		public static string CalledWithState(object fromJS)
		{
			if (fromJS is FirstTest)
				return ((FirstTest)fromJS).CalledWithState();
			else
				throw new Exception("Wrong class");
		}

		public static void Main()
		{
			Context cx = Context.enter();

			try
			{
				cx.setClassShutter(new ClassShutter());
				Scriptable scope = cx.initStandardObjects();

				java.lang.Class myJClass = typeof(FirstTest);


				// Makes a C# method avaiable in JavaScript
				// FromCSharp
				java.lang.reflect.Member method = myJClass.getMethod("FromCSharp", typeof(java.lang.Double));
				Scriptable function = new FunctionObject("fromCSharp", method, scope);
				scope.put("fromCSharp", scope, function);

				// Me
				ScriptableObject.putProperty(scope, "me", new FirstTest()); //wrappedMe);

				// CalledWithState
				method = myJClass.getMethod("CalledWithState", typeof(object));
				function = new FunctionObject("_CalledWithState", method, scope);
				scope.put("_CalledWithState", scope, function);


				// evaluates/executes the JavaScript
				cx.evaluateString(scope, script, "<cmd>", 1, null);


				// executes a JavaScript function
				object fooFunctionObj = scope.get("foo", scope);

				if (!(fooFunctionObj is Function))
					Console.WriteLine("Foo isn't a function");
				else
				{
					Function fooFunction = (Function)fooFunctionObj;
					object result = fooFunction.call(cx, scope, scope, new object[] { "bar" });
					Console.WriteLine(result);
				}

				// this is just testing the visibleToScripts ClassShutter
				try
				{
					cx.evaluateString(scope,
					  "java.lang.System.out.println(\"Security Error!!!\")",
					  "<cmd>", 1, null);
				}
				catch (Exception e)
				{
					Console.WriteLine("Couldn't call a Java method");
					Console.WriteLine(e.ToString());
				}
			}
			finally
			{
				Context.exit();
			}

			// Console.ReadKey();
		}

		/// <summary>
		/// Implements security by restricting which classes can be used in JavaScript
		/// </summary>
		private class ClassShutter : org.mozilla.javascript.ClassShutter
		{
			public bool visibleToScripts(string str)
			{
				Console.WriteLine("Class used in JavaScript: {0}", str);
				return false;
			}
		}
	}
}