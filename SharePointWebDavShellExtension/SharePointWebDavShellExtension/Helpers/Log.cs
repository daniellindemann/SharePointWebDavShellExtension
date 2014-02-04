using System;
using System.Reflection;
using System.Windows.Forms;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace SharePointWebDavShellExtension.Helpers
{
	public static class Log
	{
		private static readonly Logger _logger;

		static Log()
		{
#if DEBUG
			SetupDebugLogging();
#endif

			_logger = LogManager.GetCurrentClassLogger();
		}

		private static void SetupDebugLogging()
		{
			var config = new LoggingConfiguration();

			// console target
			var consoleTarget = new ColoredConsoleTarget()
			{
				Layout = @"${date:format=HH\\:MM\\:ss} ${logger} ${message}"
			};
			config.AddTarget("console", consoleTarget);

			// debugger out target
			var debugOutTarget = new OutputDebugStringTarget()
			{
				Layout = @"[${logger} ${date:format=HH\\:MM\\:ss}] ${message}"
			};
			config.AddTarget("debug", debugOutTarget);

			// file target
			var fileTarget = new FileTarget()
			{
				FileName = "${basedir}/log.txt",
				DeleteOldFileOnStartup = true,
				EnableFileDelete = true,
				Layout = "${longdate} - ${message}"
			};
			config.AddTarget("file", fileTarget);

			var ruleConsole = new LoggingRule("*", LogLevel.Debug, consoleTarget);
			config.LoggingRules.Add(ruleConsole);

			var ruleDebugOut = new LoggingRule("*", LogLevel.Debug, debugOutTarget);
			config.LoggingRules.Add(ruleDebugOut);

			var ruleFile = new LoggingRule("*", LogLevel.Trace, fileTarget);
			config.LoggingRules.Add(ruleFile);

			LogManager.Configuration = config;
		}

		public static void Debug(string message)
		{
			_logger.Debug(message);
		}

		public static void Trace(string message)
		{
			_logger.Trace(message);
		}

		public static void Info(string message)
		{
			_logger.Info(message);
		}

		public static void Warn(string message)
		{
			_logger.Warn(message);
		}

		public static void Error(string message)
		{
			_logger.Error(message);
		}

		public static void Fatal(string message)
		{
			_logger.Fatal(message);
		}

		public static void Debug(string message, Exception ex)
		{
			_logger.DebugException(message, ex);
		}

		public static void Trace(string message, Exception ex)
		{
			_logger.TraceException(message, ex);
		}

		public static void Info(string message, Exception ex)
		{
			_logger.InfoException(message, ex);
		}

		public static void Warn(string message, Exception ex)
		{
			_logger.WarnException(message, ex);
		}

		public static void Error(string message, Exception ex)
		{
			_logger.ErrorException(message, ex);
		}

		public static void Fatal(string message, Exception ex)
		{
			_logger.FatalException(message, ex);
		}
	}
}