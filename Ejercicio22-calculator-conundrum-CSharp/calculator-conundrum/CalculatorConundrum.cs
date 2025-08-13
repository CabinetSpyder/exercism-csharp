public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {

        switch(operation)
        {
            case "+":
                return $"{operand1} + {operand2} = {SimpleOperation.Addition(operand1, operand2)}";
            
            case "*":
                return $"{operand1} * {operand2} = {SimpleOperation.Multiplication(operand1, operand2)}";
            
            case "/":
                if(operand2 == 0)
                {
                    return "Division by zero is not allowed.";
                }
                return $"{operand1} / {operand2} = {SimpleOperation.Division(operand1, operand2)}";
            
            case "": 
                throw new ArgumentException("Operation to perform cannot be empty");
            
            case null:
                throw new ArgumentNullException("Operation to perform cannot be null");
            
            default:
                throw new ArgumentOutOfRangeException("Not valid operation");
        }

    }
}
