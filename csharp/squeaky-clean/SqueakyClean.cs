using System;
using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        return CleanSpaces(CleanSpecialCharacters(CleanGreekCharacters(KebabToCamel(CleanCtrl(identifier)))));
    }

    public static string CleanSpaces(string identifier)
    {
        return identifier.Replace(" ", "_");
    }

    public static string KebabToCamel(string identifier)
    {
        StringBuilder stringBuilder = new StringBuilder();
        bool nextLetterIsUpper = false;

        foreach(char c in identifier)
        {
            if (c == '-')
            {
                nextLetterIsUpper = true;
            }
            else if (c != '-' && nextLetterIsUpper)
            {
                stringBuilder.Append(Char.ToUpper(c));
                nextLetterIsUpper = false;
            }
            else
            {
                stringBuilder.Append(c);
            }
        }

        return stringBuilder.ToString();
    }

    public static string CleanCtrl(string identifier)
    {
        return identifier.ToString().Replace("\0", "CTRL");
    }

    public static string CleanSpecialCharacters(string identifier)
    {
        StringBuilder stringBuilder = new StringBuilder();

        foreach (char c in identifier)
        {
            if (Char.IsLetter(c) || Char.IsWhiteSpace(c))
            {
                stringBuilder.Append(c);
            }
        }

        return stringBuilder.ToString();
    }

    public static string CleanGreekCharacters(string identifier)
    {
        StringBuilder stringBuilder = new StringBuilder();

        foreach (char c in identifier)
        {
            if(c != 'α' && c != 'β' && c != 'γ' && c != 'δ' && c != 'ε' && c != 'ζ' && 
                c != 'η' && c != 'θ' && c != 'ι' && c!= 'τ' && c != 'ω')
            {
                stringBuilder.Append(c);
            }
        }

        return stringBuilder.ToString();
    }


}
