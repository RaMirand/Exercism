using System;
using System.Linq;

public static class LogAnalysis 
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string logLine, string delimiter)
    {
        string[] logMessage = logLine.Split(delimiter);

        return logMessage.Last();
    }

    // TODO: define the 'SubstringBetween()' extension method on the `string` type
    public static string SubstringBetween(this string logLine, string firstDelimiter, string secondDelimiter)
    {
        string[] logAlert = logLine.Split(firstDelimiter);
        string[] alert = logAlert.Last().Split(secondDelimiter);

        return alert.First();
    }
    
    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message (this string logLine)
    {
        string[] message = logLine.Split(':');

        return message.Last().Trim();
    }

    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel(this string logLine)
    {
        string[] log = logLine.Split("]");
        string logLevel = log.First().Trim('[');

        return logLevel;
    }
}