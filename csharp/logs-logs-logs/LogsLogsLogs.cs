using System;
using Xunit.Sdk;

public enum LogLevel : int
{
    Unknown = 0,
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42
}

static class LogLine
{

    public static LogLevel ParseLogLevel(string logLine)
    {
        string level = logLine.Substring(1, logLine.IndexOf(']') - 1);

        switch (level)
        {
            case "TRC":
                return LogLevel.Trace;
            case "DBG":
                return LogLevel.Debug;
            case "INF":
                return LogLevel.Info;
            case "WRN":
                return LogLevel.Warning;
            case "ERR":
                return LogLevel.Error;
            case "FTL":
                return LogLevel.Fatal;
            default:
                return LogLevel.Unknown;

        }
    }

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        switch (logLevel)
        {
            case (LogLevel)0:
                return $"{0}:{message}";
            case (LogLevel)1:
                return $"{1}:{message}";
            case (LogLevel)2:
                return $"{2}:{message}";
            case (LogLevel)4:
                return $"{4}:{message}";
            case (LogLevel)5:
                return $"{5}:{message}";
            case (LogLevel)6:
                return $"{6}:{message}";
            case (LogLevel)42:
                return $"{42}:{message}";
        }
        return message;

    }
}
