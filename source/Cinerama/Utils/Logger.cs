using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Cinerama.Utils
{
	public static class Logger
	{
		/// <summary>
		/// Logs the specified exception and memberName.
		/// </summary>
		/// <param name="exception">The exception to log.</param>
		/// <param name="memberName">The caller method.</param>
		public static void Log(Exception exception, [CallerMemberName] string memberName = "")
		{
			Debug.WriteLine($"{memberName} : {exception}");
			Console.WriteLine($"{memberName} : {exception}");
		}
		/// <summary>
		/// Logs the specified message and memberName.
		/// </summary>
		/// <param name="message">The message to log.</param>
		/// <param name="memberName">The caller method.</param>
		public static void Log(string message, [CallerMemberName] string memberName = "")
		{
			Debug.WriteLine($"{memberName} : {message}");
			Console.WriteLine($"{memberName} : {message}");
		}
	}
}
