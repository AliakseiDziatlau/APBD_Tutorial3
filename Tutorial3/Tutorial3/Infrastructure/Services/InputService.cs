namespace Tutorial3.Infrastructure.Services;

public static class InputService
{
    public static int? ReadInt(string prompt, string errorMessage)
    {
        Console.Write(prompt);
        var input = Console.ReadLine();
        if (!int.TryParse(input, out int result))
        {
            Console.WriteLine(errorMessage);
            return null;
        }
        return result;
    }
    
    public static double? ReadDouble(string prompt, string errorMessage)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();
        return double.TryParse(input, out double value) ? value : Error<double?>(errorMessage);
    }

    public static string? ReadString(string prompt)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();
        return string.IsNullOrWhiteSpace(input) ? null : input;
    }

    public static bool ValidateNotNull(params object?[] values)
    {
        if (values.Any(v => v == null))
        {
            Console.WriteLine("Invalid input");
            return false;
        }
        return true;
    }
    
    private static T Error<T>(string message)
    {
        Console.WriteLine(message);
        return default!;
    }
}