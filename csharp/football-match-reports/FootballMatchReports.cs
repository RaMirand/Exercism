using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        switch (shirtNum)
        {
            case 1:
                return "goalie";
            case 2:
                return "leftback";
            case 3 or 4:
                return "center back";
            case 5:
                return "right back";
            case 6 or 7 or 8:
                return "midfielder";
            case 9:
                return "left wing";
            case 10:
                return "striker";
            case 11:
                return "right wing";
            default:
                throw new ArgumentOutOfRangeException($"Não foi encontrada a camiseta {shirtNum}!");
        }

        throw new ArgumentOutOfRangeException($"Não foi encontrada a camiseta {shirtNum}!");
    }

    public static string AnalyzeOffField(object report)
    {
        switch (report)
        {
            case int:
                return $"There are {report} supporters at the match.";
            case string:
                return report.ToString();
            case Foul:
                return "The referee deemed a foul.";
            case Injury injury:
                return $"Oh no! {injury.GetDescription()} Medics are on the field.";
            case Incident:
                return "An incident happened.";
            case Manager manager when manager.Club is null:
                return manager.Name;
            case Manager manager:
                return $"{manager.Name} ({manager.Club})";

            default:
                throw new ArgumentException();
        }

        throw new NotImplementedException($"Please implement the (static) PlayAnalyzer.AnalyzeOffField() method");
    }
}
