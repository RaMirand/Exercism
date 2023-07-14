using System;
using System.Linq;

public static class Bob
{
    public static string Response(string statement)
    {
        bool isQuestion = statement.TrimEnd().EndsWith("?");
        bool isYell = statement.Equals(statement.ToUpper());
        bool isLetter = statement.Any(char.IsLetter);
        bool isSilence = String.IsNullOrWhiteSpace(statement);

        if (isSilence) return "Fine. Be that way!";
        if (isYell && !isQuestion && isLetter) return "Whoa, chill out!";
        if (isYell && isQuestion && isLetter) return "Calm down, I know what I'm doing!";
        if (isQuestion) return "Sure.";

        return "Whatever.";

    }
}