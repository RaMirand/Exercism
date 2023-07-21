using System;
using System.Threading;

public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string operation)
    {
        int result;

        if (operation is null)
        {
            throw new ArgumentNullException("Please, indicate if the operation is +, * or /");
        }
        if (operation == "")
        {
            throw new ArgumentException("Please, indicate if the operation is +, * or /");
        }

        switch (operation)
        {
            case "+":
                result = SimpleOperation.Addition(operand1, operand2);
                return Result(operand1, operand2, operation, result);
            case "*":
                result = SimpleOperation.Multiplication(operand1, operand2);
                return Result(operand1, operand2, operation, result);
            case "/":
                if (operand1 == 0 || operand2 == 0)
                {
                    return ("Division by zero is not allowed.");
                }
                result = SimpleOperation.Division(operand1, operand2);
                return Result(operand1, operand2, operation, result);
            default:
                throw new ArgumentOutOfRangeException("Unknown operation.");
        }
    }

    public static string Result(int operand1, int operand2, string operation, int result)
    {
        return $"{operand1} {operation} {operand2} = {result}";
    }
}
