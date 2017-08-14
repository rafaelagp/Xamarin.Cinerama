using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Cinerama.Helpers
{
	public static class Logger
	{
		public static void Log(Exception exception, [CallerMemberName] string memberName = "")
		{
			Debug.WriteLine($"{memberName} : {exception}");
			Console.WriteLine($"{memberName} : {exception}");
		}

		public static void Log(string message, [CallerMemberName] string memberName = "")
		{
			Debug.WriteLine($"{memberName} : {message}");
			Console.WriteLine($"{memberName} : {message}");
		}
	}
}
