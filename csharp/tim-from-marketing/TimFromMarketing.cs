using System;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string? departmentFormatted = department?.ToUpper();

        if (department == null) return OwnerBadge(id, name);
        if (id == null && department != null) return NewEmployeeBadge(name, departmentFormatted);

        return EmployeeBadge(id, name, departmentFormatted);

    }

    public static string IdFormat(int? id)
    {
        string idFormatted = $"[{id.ToString()}]";

        return idFormatted; 
    }

    private static string EmployeeBadge(int? id, string name, string department)
    {
        return $"{IdFormat(id)} - {name} - {department}";
    }

    private static string NewEmployeeBadge(string name, string department)
    {
        return $"{name} - {department}";
    }

    private static string OwnerBadge(int? id, string name)
    {
        switch (id == null)
        {
            case true:
                return $"{name} - OWNER";
            case false:
                return $"{IdFormat(id)} - {name} - OWNER";
        }
    }
}
