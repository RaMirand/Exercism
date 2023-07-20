using System;
using System.Linq;

static class LogLine
{
    public static string Message(string logLine)
    {
        string[] logMessage = logLine.Split(':');

        return logMessage.Last().Trim();
    }

    public static string LogLevel(string logLine)
    {
        char[] myChar = {'[',']'};
        string[] logMessage = logLine.Split(':');
        string alert = logMessage.First().TrimStart(myChar).TrimEnd(myChar).ToLower();

        return alert;
    }

    public static string Reformat(string logLine)
    {
        char[] myChar = {'[', ']'};
        string[] logMessage = logLine.Split(':');
        string alert = logMessage.First().TrimStart(myChar).TrimEnd(myChar);
        string messageReformated = logMessage.Last().Trim() + " (" + alert.ToLower() + ")";

        return messageReformated;

    }
}
